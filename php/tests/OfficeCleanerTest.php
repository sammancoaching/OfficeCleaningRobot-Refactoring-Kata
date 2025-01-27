<?php

declare(strict_types=1);

namespace OfficeCleaner\Tests;

use PHPUnit\Framework\TestCase;
use OfficeCleaner1;

class OfficeCleanerTest extends TestCase {
    private static function doRobotCleanerTest(string $filename, string $expected, callable $sut): void
    {
        try {
            $filePath = __DIR__ . '/' . $filename;
            $stdin = fopen($filePath, 'r');

            ob_start();
            $sut($stdin);
            $output = ob_get_clean();

            static::assertSame($expected, trim($output));
        } finally {
            fclose($stdin);
        }
    }

    /**
     * @dataProvider dataProvider
     */
    public function testOfficeCleaner1(string $filename, string $expected): void
    {
        self::doRobotCleanerTest($filename, $expected, function ($arg): void {
            OfficeCleaner1\Program::main($arg);
        });
    }

    public function dataProvider(): array
    {
        return [
            ["Input_empty.txt", "=> Cleaned: 1"],
            ["Input_one.txt", "=> Cleaned: 1"],
            ["Input_given_sample.txt", "=> Cleaned: 4"],
            ["Input_only_west.txt", "=> Cleaned: 9"],
            ["Input_wiping.txt", "=> Cleaned: 9"],
            ["Input_large.txt", "=> Cleaned: 1047"],
        ];
    }
}



