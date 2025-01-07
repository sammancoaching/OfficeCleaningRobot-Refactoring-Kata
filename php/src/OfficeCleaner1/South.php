<?php

namespace OfficeCleaner1;

class South implements Direction {
    public function move(Coordinate $coord)
    {
        $coord->y++;
    }
}