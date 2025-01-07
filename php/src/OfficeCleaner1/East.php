<?php

namespace OfficeCleaner1;

class East implements Direction {
    public function move(Coordinate $coord)
    {
        $coord->x++;
    }
}