<?php

namespace OfficeCleaner1;

class West implements Direction {
    public function move(Coordinate $coord)
    {
        $coord->x--;
    }
}