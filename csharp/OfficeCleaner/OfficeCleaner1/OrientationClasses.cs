namespace OfficeCleaner1;


//A class to keep track of the X and Y positions
public class Coordinate
{
    public Int32 x;
    public Int32 y;

    public Coordinate(int horiz, int vert)
    {
        x = horiz;
        y = vert;
    }

    public override string ToString()
    {
        return x + "," + y;
    }
}


// This is an object oriented design that's way too much
// For an initial cut.

// But I wanted to demonstrate how to get away from
// switch(char x)
//     case 'N':
// This way is extensible and object oriented.

public interface Direction
{
    void move(Coordinate coord);
}

public class East : Direction
{
    public void move(Coordinate coord)
    {
        coord.x++;
    }
}

public class West : Direction
{
    public void move(Coordinate coord)
    {
        coord.x--;
    }
}

public class North : Direction
{
    public void move(Coordinate coord)
    {
        coord.y--;
    }
}

public class South : Direction
{
    public void move(Coordinate coord)
    {
        coord.y++;
    }
}