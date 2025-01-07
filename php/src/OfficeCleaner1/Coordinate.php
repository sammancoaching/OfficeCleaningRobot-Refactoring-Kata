<?php

namespace OfficeCleaner1;

class Coordinate {
    public $x;
    public $y;

    public function __construct($horiz, $vert)
    {
        $this->x = $horiz;
        $this->y = $vert;
    }

    public function __toString()
    {
        return $this->x . "," . $this->y;
    }
}