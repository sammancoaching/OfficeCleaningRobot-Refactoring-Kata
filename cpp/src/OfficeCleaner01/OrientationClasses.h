#ifndef OFFICECLEANER1_H
#define OFFICECLEANER1_H

#include <iostream>
#include <string>
#include <memory>
namespace OfficeCleaner01 {
// A class to keep track of the X and Y positions
    class Coordinate {
    public:
        int x;
        int y;

        Coordinate(int horiz, int vert) : x(horiz), y(vert) {}

        std::string ToString() const {
            return std::to_string(x) + "," + std::to_string(y);
        }
    };

// This is an object-oriented design that's way too much for an initial cut.
// But it demonstrates how to move away from switch-case structures in an extensible and object-oriented way.

    class Direction {
    public:
        virtual void move(Coordinate &coord) = 0;

        virtual ~Direction() = default;
    };

    class East : public Direction {
    public:
        void move(Coordinate &coord) override {
            coord.x++;
        }
    };

    class West : public Direction {
    public:
        void move(Coordinate &coord) override {
            coord.x--;
        }
    };

    class North : public Direction {
    public:
        void move(Coordinate &coord) override {
            coord.y--;
        }
    };

    class South : public Direction {
    public:
        void move(Coordinate &coord) override {
            coord.y++;
        }
    };
}
#endif // OFFICECLEANER1_H
