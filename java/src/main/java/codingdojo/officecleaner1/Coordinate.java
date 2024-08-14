package codingdojo.officecleaner1;


// A class to keep track of the X and Y positions
public class Coordinate {
    public int x;
    public int y;

    public Coordinate(int horiz, int vert) {
        x = horiz;
        y = vert;
    }

    @Override
    public String toString() {
        return x + "," + y;
    }
}

