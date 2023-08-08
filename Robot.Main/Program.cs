using Robot.Lib;
using Constants = Robot.Lib.Constants;
 

// Create a new instance of the ToyRobot class
ToyRobot toyRobot = new ToyRobot();

// Display introductory messages for the Toy Robot Simulation
Console.Clear();
Console.WriteLine("Toy Robot Simulation");
Console.WriteLine("Available commands: PLACE X,Y,F | MOVE | LEFT | RIGHT | REPORT");

// The main loop of the Toy Robot Simulation
while (true)
{
    // Read the user input from the console and remove any leading or trailing whitespace
    string command = Console.ReadLine().Trim();

    // Split the input command into tokens separated by spaces
    string[] tokens = command.Split(' ');

    // Check if the command is "REPORT"
    if (tokens.Length == 1 && tokens[0].ToUpper() == "REPORT")
    {
        // If the Toy Robot is placed on the table, display its current position and direction
        // Otherwise, display a message indicating that the robot is not placed on the table
        Console.WriteLine(toyRobot.Report());
    }
    // Check if the command is "PLACE X,Y,F" where X and Y are integers, and F is a valid direction
    else if (tokens.Length == 2 && tokens[0].ToUpper() == "PLACE")
    {
        // Split the position part of the command (X,Y,F) into separate values
        string[] position = tokens[1].Split(',');

        // Try to parse the X and Y coordinates and the direction from the position part of the command
        // The direction is converted to uppercase for case-insensitive comparison
        if (position.Length == 3 && Enum.TryParse(position[2].ToUpper(), out Direction direction))
        {
            int x = int.Parse(position[0]);
            int y = int.Parse(position[1]);

            // Attempt to place the Toy Robot on the table with the specified position and direction
            // If placement is successful, display a success message along with the robot's current position and direction
            // If placement fails (e.g., the position is outside the table), display an error message
            if (toyRobot.Place(x, y, direction))
            {
                Console.WriteLine(Constants.SuccessPlacement);
                Console.WriteLine(toyRobot.Report());
            }
            else
            {
                Console.WriteLine(Constants.InvalidPlacement);
            }
        }
    }
    // Check if the command is a single command (MOVE, LEFT, RIGHT) and the Toy Robot is already placed on the table
    else if (tokens.Length == 1 && toyRobot.isPlaced)
    {
        // Execute the corresponding action based on the command
        // - "MOVE": Move the Toy Robot one unit forward in the direction it is currently facing
        // - "LEFT": Rotate the Toy Robot 90 degrees to the left without changing its position
        // - "RIGHT": Rotate the Toy Robot 90 degrees to the right without changing its position
        // After executing the action, display the Toy Robot's current position and direction
        if (tokens[0].ToUpper() == "MOVE")
            toyRobot.Move();
        else if (tokens[0].ToUpper() == "LEFT")
            toyRobot.Left();
        else if (tokens[0].ToUpper() == "RIGHT")
            toyRobot.Right();

        Console.WriteLine(toyRobot.Report());
    }
    // If the input command does not match any of the valid commands, or the Toy Robot is not placed on the table
    // Display an error message indicating an invalid command and prompt the user to enter a valid command
    else
    {
        Console.WriteLine(Constants.InvalidCommand );
    }

}
