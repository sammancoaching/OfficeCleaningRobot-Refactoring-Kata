
class RobotCleaner:
    DIRECTIONS = "NEWS"
    MAX_STEPS = 100000
    FLOOR_UPPER_WIDTH = 100000
    FLOOR_LOWER_WIDTH = -100000
    FLOOR_UPPER_LENGTH = 100000
    FLOOR_LOWER_LENGTH = -100000
    CURRENT_X = 0
    CURRENT_Y = 0

    class Coordinates:
        def __init__(self, x, y):
            self.X = x
            self.Y = y

        def __str__(self):
            return f"[{self.X}, {self.Y}, Visit]"

    def __init__(self):
        self.visited_places = {}

    def start_at(self, X, Y):
        self.CURRENT_X = X
        self.CURRENT_Y = Y
        self.visited_places[f"{self.CURRENT_X} {self.CURRENT_Y}"] = self.Coordinates(self.CURRENT_X, self.CURRENT_Y)

    def clean_floor(self, direction, steps):
        if direction not in self.DIRECTIONS:
            return
        if steps < 0 or steps > self.MAX_STEPS:
            return

        for _ in range(steps):
            if direction == 'N':
                if self.CURRENT_Y + 1 > self.FLOOR_UPPER_LENGTH:
                    self.CURRENT_Y = self.FLOOR_UPPER_LENGTH
                    break
                else:
                    if f"{self.CURRENT_X} {self.CURRENT_Y + 1}" not in self.visited_places:
                        self.visited_places[f"{self.CURRENT_X} {self.CURRENT_Y + 1}"] = self.Coordinates(self.CURRENT_X, self.CURRENT_Y + 1)
                    self.CURRENT_Y += 1

            elif direction == 'S':
                if self.CURRENT_Y - 1 < self.FLOOR_LOWER_LENGTH:
                    self.CURRENT_Y = self.FLOOR_LOWER_LENGTH
                    break
                else:
                    if f"{self.CURRENT_X} {self.CURRENT_Y - 1}" not in self.visited_places:
                        self.visited_places[f"{self.CURRENT_X} {self.CURRENT_Y - 1}"] = self.Coordinates(self.CURRENT_X, self.CURRENT_Y - 1)
                    self.CURRENT_Y -= 1

            elif direction == 'E':
                if self.CURRENT_X - 1 < self.FLOOR_LOWER_WIDTH:
                    self.CURRENT_X = self.FLOOR_LOWER_WIDTH
                    break
                else:
                    if f"{self.CURRENT_X - 1} {self.CURRENT_Y}" not in self.visited_places:
                        self.visited_places[f"{self.CURRENT_X - 1} {self.CURRENT_Y}"] = self.Coordinates(self.CURRENT_X - 1, self.CURRENT_Y)
                    self.CURRENT_X -= 1

            elif direction == 'W':
                if self.CURRENT_X + 1 > self.FLOOR_UPPER_WIDTH:
                    self.CURRENT_X = self.FLOOR_UPPER_WIDTH
                    break
                else:
                    if f"{self.CURRENT_X + 1} {self.CURRENT_Y}" not in self.visited_places:
                        self.visited_places[f"{self.CURRENT_X + 1} {self.CURRENT_Y}"] = self.Coordinates(self.CURRENT_X + 1, self.CURRENT_Y)
                    self.CURRENT_X += 1

    def print_visited_places(self):
        result = "\n".join(str(spot) for spot in self.visited_places.values())
        # print(result)


def main():
    no_commands = int(input())
    if no_commands < 0 or no_commands > 10000:
        return

    start_points = input().split()
    robot = RobotCleaner()
    robot.start_at(int(start_points[0]), int(start_points[1]))

    list_of_commands = [input() for _ in range(no_commands)]

    for command in list_of_commands:
        options = command.split()
        robot.clean_floor(options[0], int(options[1]))

    robot.print_visited_places()
    print(f"=> Cleaned: {len(robot.visited_places)}")

if __name__ == "__main__":
    main()