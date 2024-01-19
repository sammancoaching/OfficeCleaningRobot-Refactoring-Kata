package codingdojo.officecleaner9;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class OfficeCleaner9 {

    public static void main() {
        Scanner input = new Scanner(System.in);
        int noCommands = Integer.parseInt(input.nextLine());
        //from problem - number of commands n(0 <= n <= 10,000).
        if (noCommands < 0 || noCommands > 10000 )
        { return; }
        //read starting location of robot
        String[] startPoints = input.nextLine().split(" "); ;
        var robot = new RobotCleaner();
        //Visits the starting location
        robot.StartAt(Integer.parseInt(startPoints[0]), Integer.parseInt(startPoints[1]));

        List<String> listOfCommands = new ArrayList<>();
        for (int i = 0; i < noCommands; i++)
        {
            listOfCommands.add(input.nextLine());
        }

        //Reads the direction and number of steps and Visits the floor in each direction
        for (String command : listOfCommands)
        {
            String[] options = command.split(" ");

            robot.CleanFloor(options[0].charAt(0), Integer.parseInt(options[1]));
        }

        robot.PrintVisitedPlaces();
        System.out.println(String.format("=> Cleaned: %s", robot.visitedPlaces.size()));

    }
}
