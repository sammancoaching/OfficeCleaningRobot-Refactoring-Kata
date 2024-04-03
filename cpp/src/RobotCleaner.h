#ifndef OFFICECLEANINGROBOT_ROBOTCLEANER_H
#define OFFICECLEANINGROBOT_ROBOTCLEANER_H

#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <set>
#include <utility>

class RobotCleaner {
private:

public:
    std::set<std::pair<int, int>> visitedPlaces;
    void StartAt(int x, int y) ;

    void CleanFloor(char direction, int steps);

    void PrintVisitedPlaces();

};


#endif //OFFICECLEANINGROBOT_ROBOTCLEANER_H
