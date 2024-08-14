package codingdojo.officecleaner1;

// This is an object-oriented design that's way too much
// For an initial cut.

// But I wanted to demonstrate how to get away from
// switch(char x)
//     case 'N':
// This way is extensible and object-oriented.

public interface Direction {
    void move(Coordinate coord);
}

class East implements Direction {
    public void move(Coordinate coord) {
        coord.x++;
    }
}

class West implements Direction {
    public void move(Coordinate coord) {
        coord.x--;
    }
}

class North implements Direction {
    public void move(Coordinate coord) {
        coord.y--;
    }
}

class South implements Direction {
    public void move(Coordinate coord) {
        coord.y++;
    }
}
