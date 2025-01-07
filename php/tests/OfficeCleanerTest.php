<?php

declare(strict_types=1);

namespace OfficeCleaner\Tests;

use PHPUnit\Framework\TestCase;
use OfficeCleaner1;

class OfficeCleanerTest extends TestCase {
    private static function doRobotCleanerTest($filename, $expected, callable $sut): void
    {
        try {
            $filePath = __DIR__ . '/' . $filename;
            $stdin = fopen($filePath, 'r');
            // Replace the standard input stream with our file
            $GLOBALS['stdin'] = $stdin;

            ob_start();
            $sut();
            $output = ob_get_clean();

            static::assertSame($expected, trim($output));
        } finally {
            fclose($stdin);
            // Restore the original stdin stream
            $GLOBALS['stdin'] = fopen('php://stdin', 'r');
        }
    }

    /**
     * @dataProvider dataProvider
     */
    public function testOfficeCleaner1($filename, $expected)
    {
        self::doRobotCleanerTest($filename, $expected, function () {
            OfficeCleaner1\Program::main([]);
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



