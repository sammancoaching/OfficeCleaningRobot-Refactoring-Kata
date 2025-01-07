<?php

namespace OfficeCleaner1;

class North implements Direction {
    public function move(Coordinate $coord)
    {
        $coord->y--;
    }
}