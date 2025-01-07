<?php

declare(strict_types=1);

namespace OfficeCleaner\Tests;

use PHPUnit\Framework\TestCase;
use Sample\Sample;

class OfficeCleanerTests extends TestCase
{
    public function test_something(): void
    {
        $expected = 15;
        $actual = 42;
        self::assertSame($expected, $actual);
    }
}
