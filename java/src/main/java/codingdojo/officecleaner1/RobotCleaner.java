package codingdojo.officecleaner1;

import java.util.List;
import java.util.*;

class RobotCleaner {
    private RobotCleanerParser cleanerParser;
    private Coordinate position;

    // Using a HashMap instead of a HashSet for now
    private Map<String, Integer> coordHashSet = new HashMap<>();

    // Directions
    private static Direction north = new North();
    private static Direction south = new South();
    private static Direction east = new East();
    private static Direction west = new West();

    private static String northString = "N";
    private static String southString = "S";
    private static String eastString = "E";
    private static String westString = "W";

    private static List<String> moveList = Arrays.asList(
            northString,
            southString,
            eastString,
            westString
    );

    private static Map<String, Direction> directionTable = new HashMap<String, Direction>() {{
        put(northString, north);
        put(southString, south);
        put(eastString, east);
        put(westString, west);
    }};

    // Constructor
    public RobotCleaner() {
        cleanerParser = new RobotCleanerParser(moveList);
    }

    public int getVisitedPositions() {
        return coordHashSet.size();
    }

    public boolean parseInput(List<String> input) {
        coordHashSet.clear();
        if (!cleanerParser.parse(input)) {
            return false;
        }

        position = cleanerParser.getStartPosition();
        coordHashSet.put(position.toString(), 0);

        for (String command : cleanerParser.getCommands()) {
            if (command == null) {
                continue;
            }
            String[] commandParts = command.split(" ");
            int iterations = Integer.parseInt(commandParts[1]);

            Direction move = directionTable.get(commandParts[0]);
            for (int count = 0; count < iterations; count++) {
                move.move(position);
                if (!coordHashSet.containsKey(position.toString())) {
                    coordHashSet.put(position.toString(), 0);
                }
            }
        }

        return true;
    }


}
