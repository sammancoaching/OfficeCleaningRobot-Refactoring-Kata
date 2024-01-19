package codingdojo.officecleaner9;

import java.util.TreeMap;

public class RobotCleaner {
    /**
     * Directions NEWS = North, East, West, South
    */
        final String DIRECTIONS = "NEWS";
    /**
     * Maximum number of steps
    */
        final int MAX_STEPS = 100000;
    /**
     * Upper bounadry width of the room.
     * from problem x(-100,000 <= x <= 100,000).
    */
    private final int FLOOR_UPPER_WIDTH = 100000;
    /**
     * Lower bounadry width of the room.
     * from problem x(-100,000 <= x <= 100,000).
    */
    private final int FLOOR_LOWER_WIDTH = -100000;
    /**
     * Upper bounadry length of the room.
     * from problem y(-100,000 <= y <= 100,000).
    */
    private final int FLOOR_UPPER_LENGTH = 100000;
    /**
     * Lower bounadry length of the room.
     * from problem y(-100,000 <= y <= 100,000).
    */
    private final int FLOOR_LOWER_LENGTH = -100000;
    /**
     * Current Location X.
    */
    private static int CURRENT_X;
    /**
     * Current Location Y.
    */
    private static int CURRENT_Y;

    /**
     * Holds the x y coordiantes on floor.
    */
    public class Coordinates
    {
        public int X;
        public int Y;
            public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public String ToString()
        {
            return "[" + this.X + ", " + this.Y + ", Visit]";
        }
    }
    /**
     * Sorted List(for fast searching) of visited spaces(coordinates) on floor.
    */
    public TreeMap<String, Coordinates> visitedPlaces = new TreeMap<String, Coordinates>();

    /**
     * Constructor with no parameter
    */
    public RobotCleaner() { }

    /**
     * Starts the robot at given location and Visit it 
    */
    // <param name="X">X coordinate</param>
    // <param name="Y">Y coordiante</param>
    public void StartAt(int X, int Y)
    {
        CURRENT_X = X; // x(-100,000 <= x <= 100,000)
        CURRENT_Y = Y; //y(-100,000 <= y <= 100,000)
        //Visited start position,  (Key  = CURRENT_X + CURRENT_Y) for searching
        visitedPlaces.put(String.format("%s %s",CURRENT_X, CURRENT_Y), new Coordinates(CURRENT_X, CURRENT_Y));
    }

    /**
     * Visits the floor 
     * in direction
     * with number of steps
    */
    // <param name="direction">Direction {'E', 'W', 'N', 'S'}</param>
    // <param name="steps"></param>
    public void CleanFloor(char direction, int steps)
    {
        // if the correct direction is no given it exits
        if (!DIRECTIONS.contains(""+direction))
            return;
        //if steps is less than 0 or greater than MAX_STEPS it exits
        if (steps < 0 || steps > MAX_STEPS)
            return;
        switch (direction)
        {
            case 'N':
                for (int i = 0; i < steps; i++)
                {
                    //if robot is at the boundary of the floor it just stops there and wait for next direction 
                    if (CURRENT_Y + 1 > FLOOR_UPPER_LENGTH)
                    {
                        CURRENT_Y = FLOOR_UPPER_LENGTH;
                        break;
                    }
                    else
                    {
                        //if place is not visited
                        if (!visitedPlaces.containsKey(String.format("%s %s", CURRENT_X, CURRENT_Y + 1)))
                        {
                            //Visit it and add to the visited places
                            visitedPlaces.put(String.format("%s %s", CURRENT_X, CURRENT_Y + 1), new Coordinates(CURRENT_X, ++CURRENT_Y));
                        }
                        else
                        {
                            //otherwise moves to the next location
                            ++CURRENT_Y;
                        }
                    }
                }
                break;
            case 'S':
                for (int i = 0; i < steps; i++)
                {
                    //if robot is at the boundary of the floor it just stops there and wait for next direction 
                    if (CURRENT_Y - 1 < FLOOR_LOWER_LENGTH)
                    {
                        CURRENT_Y = FLOOR_LOWER_LENGTH;
                        break;
                    }
                    else
                    {
                        //if place is not visited
                        if (!visitedPlaces.containsKey(String.format("%s %s", CURRENT_X, CURRENT_Y - 1)))
                        {
                            //Visit it and add to the visited places
                            visitedPlaces.put(String.format("%s %s", CURRENT_X, CURRENT_Y - 1), new Coordinates(CURRENT_X, --CURRENT_Y));
                        }
                        else
                        {
                            //otherwise moves to the next location
                            --CURRENT_Y;
                        }
                    }
                }
                break;
            case 'E':
                for (int i = 0; i < steps; i++)
                {
                    //if robot is at the boundary of the floor it just stops there and wait for next direction 
                    if (CURRENT_X - 1 < FLOOR_LOWER_WIDTH)
                    {
                        CURRENT_X = FLOOR_LOWER_WIDTH;
                        break;
                    }
                    else
                    {
                        //if place is not visited
                        if (!visitedPlaces.containsKey(String.format("%s %s", CURRENT_X - 1, CURRENT_Y)))
                        {
                            //Visit it and add to the visited places
                            visitedPlaces.put(String.format("%s %s", CURRENT_X - 1, CURRENT_Y), new Coordinates(--CURRENT_X, CURRENT_Y));
                        }
                        else
                        {
                            //otherwise moves to the next location
                            --CURRENT_X;
                        }
                    }
                }
                break;
            case 'W':
                for (int i = 0; i < steps; i++)
                {
                    //if robot is at the boundary of the floor it just stops there and wait for next direction 
                    if (CURRENT_X + 1 > FLOOR_UPPER_WIDTH)
                    {
                        CURRENT_X = FLOOR_UPPER_WIDTH;
                        break;
                    }
                    else
                    {
                        //if place is not visited
                        if (!visitedPlaces.containsKey(String.format("%s %s", CURRENT_X + 1, CURRENT_Y)))
                        {
                            //Visit it and add to the visited places
                            visitedPlaces.put(String.format("%s %s", CURRENT_X + 1, CURRENT_Y), new Coordinates(++CURRENT_X, CURRENT_Y));
                        }
                        else
                        {
                            //otherwise moves to the next location
                            ++CURRENT_X;
                        }
                    }
                }
                break;
        }
    }

    public void PrintVisitedPlaces()
    {
        
        var result = "";
        for (var spot : visitedPlaces.values())
        {
            result += spot.ToString();
            result += "\n";
        }
        //System.out.println(result);

    }
}
