package codingdojo.officecleaner1;

import java.util.ArrayList;
import java.util.List;

class RobotCleanerParser {
    private int MINIMUM_NUM_ENTRIES = 2; // Must at least be #steps, position, 0..n moves.
    private int COMMAND_OVERHEAD = 2; // # steps, position
    private static final int MINIMUM_NUM_STEPS = 0; // minimum number of steps
    private static final int MAXIMUM_NUM_STEPS = 100000; // maximum number of steps
    private List<String> moves;
    private Coordinate startPosition;

    private List<String> supportedMoves;

    public RobotCleanerParser(List<String> supportedMoves) {
        if (supportedMoves == null)
            throw new NullPointerException("Null passed to Robot Parser Constructor");

        if (supportedMoves.size() == 0)
            throw new IllegalArgumentException("Empty list passed to Robot Parser Constructor");

        this.supportedMoves = supportedMoves;
    }

    public Coordinate getStartPosition() {
        return startPosition;
    }

    public List<String> getCommands() {
        return moves;
    }

    private void visit() {
        if (moves != null)
            moves = null;

        startPosition = null;
    }

    public boolean parse(List<String> commands) {
        // OMITTED: The logging statements that should precede return false;
        // perform visit
        visit();

        // first, ensure not null or incorrect number of elements
        if (commands == null || commands.size() < MINIMUM_NUM_ENTRIES)
            return false;

        // next, evaluate the number of steps
        if (Integer.parseInt(commands.get(0)) < 0)
            return false;

        // parse the initial position and store it
        String[] tokens = commands.get(1).split(" ");
        if (tokens.length != 2)
            return false;

        startPosition = new Coordinate(Integer.parseInt(tokens[0]), Integer.parseInt(tokens[1]));

        // remove the first two lines - the rest are the commands to be executed
        commands.remove(0);
        commands.remove(0);

        // For each command, parse and ensure that it matches the pattern direction[space]steps

        for (String s : commands) {
            if (s == null) {
                continue;
            }
            String[] commandLineItemParts = s.split(" ");
            if (!supportedMoves.contains(commandLineItemParts[0])) {
                return false;
            }
            if (commandLineItemParts.length != 2) {
                return false;
            }
            int steps = Integer.parseInt(commandLineItemParts[1]);
            if (steps < MINIMUM_NUM_STEPS || steps > MAXIMUM_NUM_STEPS) {
                return false;
            }
        }

        // Appears to check out
        moves = commands;

        return true;
    }
}

