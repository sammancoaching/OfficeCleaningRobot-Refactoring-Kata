<?php

namespace OfficeCleaner1;

class RobotCleanerParser
{
    private $MINIMUM_NUM_ENTRIES = 2; // Must at least be #steps, position, 0..n moves.
    private $COMMAND_OVERHEAD = 2; // # steps, position
    private const MINIMUM_NUM_STEPS = 0; // minimum number of steps
    private const MAXIMUM_NUM_STEPS = 100000; // maximum number of steps
    private $moves;
    private $startPosition;

    private $supportedMoves;

    public function __construct($supportedMoves)
    {
        if ($supportedMoves == null) {
            throw new \InvalidArgumentException("Null passed to Robot Parser Constructor");
        }

        if (count($supportedMoves) == 0) {
            throw new \InvalidArgumentException("Empty list passed to Robot Parser Constructor");
        }

        $this->supportedMoves = $supportedMoves;
    }

    public function getStartPosition()
    {
        return $this->startPosition;
    }

    public function getCommands()
    {
        return $this->moves;
    }

    private function visit()
    {
        if ($this->moves != null) {
            $this->moves = null;
        }

        $this->startPosition = null;
    }

    public function parse($commands)
    {
        // OMITTED: The logging statements that should precede return false;
        // perform visit
        $this->visit();

        // First, ensure not null or incorrect number of elements
        if ($commands == null || count($commands) < $this->MINIMUM_NUM_ENTRIES) {
            return false;
        }

        // Next, evaluate the number of steps
        if (intval($commands[0], 10) < 0) {
            return false;
        }

        // Parse the initial position and store it
        $tokens = explode(' ', $commands[1]);
        if (count($tokens) != 2) {
            return false;
        }

        $this->startPosition = new Coordinate(intval($tokens[0]), intval($tokens[1]));

        // Remove the first two lines - the rest are the commands to be executed
        array_shift($commands);
        array_shift($commands);

        // For each command, parse and ensure that it matches the pattern direction[space]steps
        foreach ($commands as $s) {
            if ($s == null) {
                continue;
            }
            $commandLineItemParts = explode(' ', $s);
            if (!in_array($commandLineItemParts[0], $this->supportedMoves)) {
                return false;
            }
            if (count($commandLineItemParts) != 2) {
                return false;
            }
            $steps = intval($commandLineItemParts[1]);
            if ($steps < self::MINIMUM_NUM_STEPS || $steps > self::MAXIMUM_NUM_STEPS) {
                return false;
            }
        }

        // Appears to check out
        $this->moves = $commands;

        return true;
    }
}

?>
