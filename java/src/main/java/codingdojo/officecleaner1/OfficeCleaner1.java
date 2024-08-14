package codingdojo.officecleaner1;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class OfficeCleaner1 {

        public static void main() {
            Scanner scanner = new Scanner(System.in);
            String firstLine = scanner.nextLine();
            int commandNum = Integer.parseInt(firstLine);

            List<String> inputCommands = new ArrayList<>();
            inputCommands.add(firstLine);
            String secondLine = scanner.nextLine();
            inputCommands.add(secondLine);
            RobotCleaner mainRobot = new RobotCleaner();

            for (int count = 0; count < commandNum; count++) {
                inputCommands.add(scanner.nextLine());
            }

            if (!mainRobot.parseInput(inputCommands)) {
                System.out.print("There was an error. Please check the logs");
            }

            System.out.print("=> Cleaned: " + mainRobot.getVisitedPositions());
        }



}
