#ifndef ROBOTCLEANER_H
#define ROBOTCLEANER_H

#include "RobotCleanerParser.h"
#include <unordered_map>
#include <map>
#include <functional>
#include <vector>
#include <string>

namespace OfficeCleaner01 {

    class RobotCleaner {
    private:
        RobotCleanerParser cleanerParser;
        Coordinate position = Coordinate(0, 0);
        std::unordered_map<std::string, int> coordHashSet;

        static North north;
        static South south;
        static East east;
        static West west;

        static const std::string northString;
        static const std::string southString;
        static const std::string eastString;
        static const std::string westString;

        static std::vector<std::string> moveList;
        static std::map<std::string, std::function<void(Coordinate &)>> directionTable;

    public:
        RobotCleaner() : cleanerParser(moveList) {
            coordHashSet.clear();
        }

        int getVisitedPositions() {
            return coordHashSet.size();
        }

        bool parseInput(const std::vector<std::string> &input) {
            coordHashSet.clear();
            if (!cleanerParser.parse(input)) {
                return false;
            }

            position = cleanerParser.getStartPosition();
            coordHashSet[position.ToString()] = 0;

            for (const auto &command: cleanerParser.getCommands()) {
                if (command.empty()) {
                    continue;
                }
                std::istringstream commandParts(command);
                std::string direction;
                int iterations;
                commandParts >> direction >> iterations;

                auto move = directionTable[direction];
                for (int count = 0; count < iterations; count++) {
                    move(position);
                    coordHashSet[position.ToString()] = 0;
                }
            }

            return true;
        }
    };

// Static members initialization
    North RobotCleaner::north = North();
    South RobotCleaner::south = South();
    East RobotCleaner::east = East();
    West RobotCleaner::west = West();

    const std::string RobotCleaner::northString = "N";
    const std::string RobotCleaner::southString = "S";
    const std::string RobotCleaner::eastString = "E";
    const std::string RobotCleaner::westString = "W";

    std::vector<std::string> RobotCleaner::moveList = {northString, southString, eastString, westString};

    std::map<std::string, std::function<void(Coordinate &)>> RobotCleaner::directionTable = {
            {northString, [](Coordinate &c) { north.move(c); }},
            {southString, [](Coordinate &c) { south.move(c); }},
            {eastString,  [](Coordinate &c) { east.move(c); }},
            {westString,  [](Coordinate &c) { west.move(c); }}
    };
}
#endif // ROBOTCLEANER_H
