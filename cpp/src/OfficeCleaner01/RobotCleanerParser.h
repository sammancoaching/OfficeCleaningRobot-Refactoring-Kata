#ifndef ROBOTCLEANERPARSER_H
#define ROBOTCLEANERPARSER_H

#include "OrientationClasses.h"
#include <vector>
#include <string>
#include <algorithm>
#include <stdexcept>
#include <cstdlib>
#include <sstream>
namespace OfficeCleaner01 {
    class RobotCleanerParser {
    private:
        static const int MINIMUM_NUM_ENTRIES = 2; // Must at least be #steps, position, 0..n moves.
        static const int COMMAND_OVERHEAD = 2; // # steps, position
        static const int MINIMUM_NUM_STEPS = 0; // minimum number of steps
        static const int MAXIMUM_NUM_STEPS = 100000; // maximum number of steps
        std::vector<std::string> moves;
        Coordinate startPosition = Coordinate(0, 0);
        std::vector<std::string> supportedMoves;

    public:
        RobotCleanerParser(const std::vector<std::string> &supportedMoves) {
            if (supportedMoves.empty())
                throw std::invalid_argument("Empty list passed to Robot Parser Constructor");

            this->supportedMoves = supportedMoves;
        }

        Coordinate getStartPosition() const {
            return startPosition;
        }

        std::vector<std::string> getCommands() const {
            return moves;
        }

    private:
        void visit() {
            moves.clear();
            // Assuming default initialization of startPosition is acceptable for "null" representation
            startPosition = Coordinate(0, 0);
        }

    public:
        bool parse(const std::vector<std::string> &commands) {
            // OMITTED: The logging statements that should precede return false;
            // perform visit
            visit();

            // first, ensure not null or incorrect number of elements
            if (commands.size() < MINIMUM_NUM_ENTRIES)
                return false;

            // next, evaluate the number of steps
            int numberOfSteps = std::atoi(commands[0].c_str());
            if (numberOfSteps < 0)
                return false;

            // parse the initial position and store it
            std::istringstream tokens(commands[1]);
            std::string token;
            getline(tokens, token, ' ');
            int x = std::atoi(token.c_str());
            getline(tokens, token, ' ');
            int y = std::atoi(token.c_str());

            startPosition = Coordinate(x, y);

            std::vector<std::string> remainingCommands(commands.begin() + 2, commands.end());

            // for each command, parse and ensure that it matches the pattern direction[space]steps
            for (const auto &s: remainingCommands) {
                std::istringstream commandLineItemParts(s);
                std::string direction;
                commandLineItemParts >> direction;

                if (std::find(supportedMoves.begin(), supportedMoves.end(), direction) == supportedMoves.end())
                    return false;

                std::string stepsStr;
                commandLineItemParts >> stepsStr;
                int steps = std::atoi(stepsStr.c_str());
                if (steps < MINIMUM_NUM_STEPS || steps > MAXIMUM_NUM_STEPS)
                    return false;
            }

            // appears to check out
            moves = remainingCommands;

            return true;
        }
    };
}
#endif // ROBOTCLEANERPARSER_H
