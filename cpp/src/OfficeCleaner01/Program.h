#include "RobotCleaner.h"
#include <iostream>
#include <vector>
#include <string>
#include <cstdlib>
namespace OfficeCleaner01 {
    int OfficeCleaner1Main() {
        std::string firstLine;
        std::getline(std::cin, firstLine);
        int commandNum = std::stoi(firstLine);

        std::vector<std::string> inputCommands;
        inputCommands.push_back(firstLine); // Add the number of commands as the first element

        std::string secondLine;
        std::getline(std::cin, secondLine);
        inputCommands.push_back(secondLine); // Add the starting position as the second element

        RobotCleaner mainRobot;

        for (int count = 0; count < commandNum; ++count) {
            std::string command;
            std::getline(std::cin, command);
            inputCommands.push_back(command); // Add each subsequent command
        }

        if (!mainRobot.parseInput(inputCommands)) {
            std::cout << "There was an error. Please check the logs";
        } else {
            std::cout << "=> Cleaned: " << mainRobot.getVisitedPositions();
        }

        return 0;
    }
}
