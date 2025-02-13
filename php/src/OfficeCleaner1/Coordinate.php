<?php

declare(strict_types=1);

namespace OfficeCleaner1;

use Stringable;

class Coordinate implements Stringable {
    public function __construct(public int $x, public int $y)
    {
    }

    public function __toString(): string
    {
        return $this->x . "," . $this->y;
    }
}