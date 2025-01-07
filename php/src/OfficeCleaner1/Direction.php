<?php

namespace OfficeCleaner1;

// A class to keep track of the X and Y positions

// This is an object oriented design that's way too much
// For an initial cut.

// But I wanted to demonstrate how to get away from
// switch(char x)
//     case 'N':
// This way is extensible and object oriented.

interface Direction {
    public function move(Coordinate $coord);
}