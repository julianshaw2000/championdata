

using Robot.Lib;

ToyRobot toyRobot = new ToyRobot();

Console.WriteLine("Toy Robot Simulation");
Console.WriteLine("Available commands: PLACE X,Y,F | MOVE | LEFT | RIGHT | REPORT");

while (true)
{
    string command = Console.ReadLine().Trim(); 

    string[] tokens = command.Split(' ');

    if (tokens.Length == 1 && tokens[0].ToUpper() == "REPORT")
    {
        Console.WriteLine(toyRobot.Report());
    }
    else if (tokens.Length == 2 && tokens[0].ToUpper() == "PLACE")
    {
        string[] position = tokens[1].Split(',');
        if (position.Length == 3 && Enum.TryParse((position[2]).ToUpper(), out Direction direction))
        {
            int x = int.Parse(position[0]);
            int y = int.Parse(position[1]);
            if (toyRobot.Place(x, y, direction)){
                Console.WriteLine("Toy robot placed successfully.");   
       Console.WriteLine(toyRobot.Report());
            }
            else
                Console.WriteLine("Invalid placement. The robot cannot be placed outside the table.");
        }
    }
    else if (tokens.Length == 1 && toyRobot.isPlaced)
    {
        if (tokens[0].ToUpper() == "MOVE")
            toyRobot.Move();
        else if (tokens[0].ToUpper() == "LEFT")
            toyRobot.Left();
        else if (tokens[0].ToUpper() == "RIGHT")
            toyRobot.Right();

            
       Console.WriteLine(toyRobot.Report());
    }
    else
    {
        Console.WriteLine("Invalid command. Please enter a valid command.");
    }

} 