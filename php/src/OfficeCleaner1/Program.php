<?php

declare(strict_types=1);

namespace OfficeCleaner1;

class Program
{
    public static function main($stdin = null): void
    {
        // read from STDIN if no stream is passed in
        if (func_num_args() === 0) {
            $stdin = STDIN;
        }

        $firstLine = trim(fgets($stdin));
        $commandNum = intval($firstLine);
        $inputCommands = [];
        $inputCommands[] = $firstLine;
        $secondLine = trim(fgets($stdin));
        $inputCommands[] = $secondLine;
        $mainRobot = new RobotCleaner();
        for ($count = 0; $count < $commandNum; $count++) {
            $inputCommands[] = trim(fgets($stdin));
        }
        if (!$mainRobot->parseInput($inputCommands)) {
            echo "There was an error. Please check the logs";
        }
        echo "=> Cleaned: " . $mainRobot->getVisitedPositions();
    }
}