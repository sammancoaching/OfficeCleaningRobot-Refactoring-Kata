<?php

namespace OfficeCleaner1;

class Program
{
    public static function main()
    {
        $firstLine = trim(fgets(STDIN));
        $commandNum = intval($firstLine);

        $inputCommands = [];
        $inputCommands[] = $firstLine;
        $secondLine = trim(fgets(STDIN));
        $inputCommands[] = $secondLine;
        $mainRobot = new RobotCleaner();

        for ($count = 0; $count < $commandNum; $count++) {
            $inputCommands[] = trim(fgets(STDIN));
        }

        if (!$mainRobot->parseInput($inputCommands)) {
            echo "There was an error. Please check the logs";
        }

        echo "=> Cleaned: " . $mainRobot->getVisitedPositions();
    }
}

if (PHP_SAPI === 'cli') { Program::main(); }
?>
