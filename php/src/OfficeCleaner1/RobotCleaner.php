<?php

declare(strict_types=1);

namespace OfficeCleaner1;

class RobotCleaner
{
    private $cleanerParser;
    private $position;

    // Using an associative array to mimic a HashSet for storing coordinates
    private $coordHashSet = [];

    // This entire block should be set up with some kind of dependency injection
    // but for now has been coded like this

    private static $north;
    private static $south;
    private static $east;
    private static $west;

    private static $northString = "N";
    private static $southString = "S";
    private static $eastString = "E";
    private static $westString = "W";

    private static $moveList = [];
    private static $directionTable = [];

    // block ends

    public function __construct()
    {
        self::$north = new North();
        self::$south = new South();
        self::$east = new East();
        self::$west = new West();

        self::$moveList = [
            self::$northString,
            self::$southString,
            self::$eastString,
            self::$westString
        ];

        self::$directionTable = [
            self::$northString => self::$north,
            self::$southString => self::$south,
            self::$eastString => self::$east,
            self::$westString => self::$west
        ];

        $this->cleanerParser = new RobotCleanerParser(self::$moveList);
    }

    public function getVisitedPositions()
    {
        return count($this->coordHashSet);
    }

    public function parseInput($input)
    {
        $this->coordHashSet = [];
        if (!$this->cleanerParser->parse($input)) {
            return false;
        }

        $this->position = $this->cleanerParser->getStartPosition();
        $this->coordHashSet[$this->position->__toString()] = 0;

        foreach ($this->cleanerParser->getCommands() as $command) {
            if ($command == null) {
                continue;
            }
            $commandParts = explode(' ', $command);
            $iterations = intval($commandParts[1]);

            $move = self::$directionTable[$commandParts[0]];
            for ($count = 0; $count < $iterations; $count++) {
                $move->move($this->position);
                if (!array_key_exists($this->position->__toString(), $this->coordHashSet)) {
                    $this->coordHashSet[$this->position->__toString()] = 0;
                }
            }
        }

        return true;
    }
}

?>




