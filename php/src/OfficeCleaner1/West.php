<?php

declare(strict_types=1);

namespace OfficeCleaner1;
class West implements Direction {
    public function move(Coordinate $coord): void
    {
        $coord->x--;
    }
}