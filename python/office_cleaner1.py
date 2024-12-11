import sys

class Coordinate:
    def __init__(self, horiz, vert):
        self.x = horiz
        self.y = vert

    def __str__(self):
        return f"{self.x},{self.y}"


class Direction:
    def move(self, coord):
        raise NotImplementedError("This method should be overridden by subclasses")


class East(Direction):
    def move(self, coord):
        coord.x += 1


class West(Direction):
    def move(self, coord):
        coord.x -= 1


class North(Direction):
    def move(self, coord):
        coord.y -= 1


class South(Direction):
    def move(self, coord):
        coord.y += 1


class RobotCleanerParser:
    MINIMUM_NUM_ENTRIES = 2 # Must at least be #steps, position, 0..n moves.
    COMMAND_OVERHEAD = 2 # # steps, position
    MINIMUM_NUM_STEPS = 0 # minimum number of steps
    MAXIMUM_NUM_STEPS = 100000 # maximum number of steps

    def __init__(self, supported_moves):
        if supported_moves is None:
            raise ValueError("Null passed to Robot Parser Constructor")

        if len(supported_moves) == 0:
            raise ValueError("Empty list passed to Robot Parser Constructor")

        self.supported_moves = supported_moves
        self.moves = []
        self.start_position = None

    def get_start_position(self):
        return self.start_position

    def get_commands(self):
        return self.moves

    def visit(self):
        if self.moves is not None:
            self.moves = None
        self.start_position = None

    def parse(self, commands):
        # OMITTED: The logging statements that should precede return False
        # Perform visit
        self.visit()

        # First, ensure not null or incorrect number of elements
        if commands is None or len(commands) < self.MINIMUM_NUM_ENTRIES:
            return False

        # Next, Evaluate the number of steps
        if int(commands[0], 10) < 0:
            return False

        # Parse the initial position and store it
        tokens = commands[1].split(' ')
        if len(tokens) != 2:
            return False

        self.start_position = Coordinate(int(tokens[0]), int(tokens[1]))

        # Remove the first two lines - the rest are the commands to be executed
        commands = commands[2:]

        # For each command, parse and ensure that it matches the pattern direction[space]steps
        for command in commands:
            if command is None:
                continue

            command_line_item_parts = command.split(' ')
            if command_line_item_parts[0] not in self.supported_moves:
                return False

            if len(command_line_item_parts) != 2:
                return False

            steps = int(command_line_item_parts[1])
            if steps < self.MINIMUM_NUM_STEPS or steps > self.MAXIMUM_NUM_STEPS:
                return False

        # Appears to check out
        self.moves = commands
        # print(f"""parsed moves: {"\n".join(self.moves)}\n""")
        return True


class RobotCleaner:
    def __init__(self):
        self._cleaner_parser = RobotCleanerParser(["N", "S", "E", "W"])
        self.position = Coordinate(0, 0)
        self.coord_hash_set = {}

        self.directions = {
            "N": North(),
            "S": South(),
            "E": East(),
            "W": West()
        }

    def get_visited_positions(self):
        return len(self.coord_hash_set)

    def parse_input(self, input_commands):
        self.coord_hash_set.clear()
        if not self._cleaner_parser.parse(input_commands):
            return False

        self.position = self._cleaner_parser.get_start_position()
        self.coord_hash_set[str(self.position)] = 0

        for command in self._cleaner_parser.get_commands():
            if command is None:
                continue
            command_parts = command.split(' ')
            iterations = int(command_parts[1])
            move = self.directions[command_parts[0]]
            for _ in range(iterations):
                move.move(self.position)
                if str(self.position) not in self.coord_hash_set:
                    self.coord_hash_set[str(self.position)] = 0

        return True


def main():
    first_line = input().strip()
    command_num = int(first_line)

    input_commands = []
    input_commands.append(first_line)
    second_line = input().strip()
    input_commands.append(second_line)
    main_robot = RobotCleaner()

    for _ in range(command_num):
        input_commands.append(input().strip())

    if not main_robot.parse_input(input_commands):
        print("There was an error. Please check the logs")
    else:
        print("=> Cleaned: {}".format(main_robot.get_visited_positions()))


if __name__ == "__main__":
    main()


