#ifndef OFFICECLEANER9_H
#define OFFICECLEANER9_H

#include <iostream>
#include <sstream>
#include <vector>
#include <unordered_set>
#include <string>

class RobotCleaner {
private:
    std::unordered_set<std::string> visitedPlaces;
    int x = 0, y = 0;

    std::string GetKey(int x, int y) {
        return std::to_string(x) + "," + std::to_string(y);
    }

public:
    RobotCleaner() = default;

    void StartAt(int x, int y) {
        this->x = x;
        this->y = y;
        visitedPlaces.insert(GetKey(x, y));
    }

    void CleanFloor(char direction, int steps) {
        switch (direction) {
            case 'N': for (int i = 0; i < steps; ++i) visitedPlaces.insert(GetKey(x, ++y)); break;
            case 'S': for (int i = 0; i < steps; ++i) visitedPlaces.insert(GetKey(x, --y)); break;
            case 'E': for (int i = 0; i < steps; ++i) visitedPlaces.insert(GetKey(++x, y)); break;
            case 'W': for (int i = 0; i < steps; ++i) visitedPlaces.insert(GetKey(--x, y)); break;
        }
    }

    void PrintVisitedPlaces() const {
        for (const auto& place : visitedPlaces) {
            std::cout << place << std::endl;
        }
    }

    size_t VisitedPlacesCount() const {
        return visitedPlaces.size();
    }
};

void OfficeCleaner9Main() {
    int noCommands;
    std::cin >> noCommands;
    if (noCommands < 0 || noCommands > 10000) {
        return;
    }

    int startX, startY;
    std::cin >> startX >> startY;

    RobotCleaner robot;
    robot.StartAt(startX, startY);

    std::cin.ignore(); // Ignore newline after reading startY

    for (int i = 0; i < noCommands; ++i) {
        std::string command;
        std::getline(std::cin, command);
        std::istringstream iss(command);
        char direction;
        int steps;
        iss >> direction >> steps;

        robot.CleanFloor(direction, steps);
    }

    robot.PrintVisitedPlaces();
    std::cout << "=> Cleaned: " << robot.VisitedPlacesCount() << std::endl;
}

#endif // OFFICECLEANER9_H
