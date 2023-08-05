using Robot.Lib;
using Xunit; 

namespace Robot.Tests;

public class SimulationTest
{ 
    public class ToyRobotTests
    {
        [Theory]
        [InlineData("PLACE 0,0,NORTH\nMOVE\nREPORT", "0,1,NORTH")]
        [InlineData("PLACE 0,0,NORTH\nLEFT\nREPORT", "0,0,WEST")]
        [InlineData("PLACE 2,2,SOUTH\nMOVE\nMOVE\nREPORT", "2,0,SOUTH")]
        [InlineData("PLACE 2,2,SOUTH\nMOVE\nMOVE\nRIGHT\nREPORT", "2,0,EAST")]
        [InlineData("PLACE 2,2,SOUTH\nMOVE\nMOVE\nRIGHT\nMOVE\nREPORT", "3,0,EAST")]
        [InlineData("MOVE\nREPORT", Constants.UnplacedRobot)]
        [InlineData("PLACE 0,0,NORTH\nLEFT\nMOVE\nREPORT", "0,0,WEST")]
        [InlineData("PLACE 0,0,NORTH\nRIGHT\nMOVE\nREPORT", "0,0,WEST")]  
        [InlineData("PLACE 0,0,SOUTH\nLEFT\nMOVE\nREPORT", "1,0,EAST")]
        [InlineData("PLACE 0,0,SOUTH\nRIGHT\nMOVE\nREPORT", "1,0,EAST")]
        [InlineData("PLACE 0,0,NORTH\nRIGHT\nREPORT", "0,0,WEST")]
        [InlineData("PLACE 4,4,NORTH\nRIGHT\nREPORT", "4,4,WEST")]
        [InlineData("PLACE 5,5,NORTH\nRIGHT\nREPORT", "5,5,WEST")]
        [InlineData("PLACE 5,6,NORTH\nRIGHT\nREPORT", Constants.UnplacedRobot)] 
        public void TestToyRobotSimulation(string inputCommands, string expectedOutput)
        {
            // Arrange
            ToyRobot toyRobot = new ToyRobot();

            // Act
            string[] commands = inputCommands.Split('\n');
            foreach (string command in commands)
            {
                string[] tokens = command.Split(' ');
                if (tokens.Length == 1 && tokens[0].ToUpper() == "REPORT")
                {
                    Assert.Equal(expectedOutput, toyRobot.Report());
                }
                else if (tokens.Length == 2 && tokens[0].ToUpper() == "PLACE")
                {
                    string[] position = tokens[1].Split(',');
                    if (position.Length == 3 && Enum.TryParse(position[2], out Direction direction))
                    {
                        int x = int.Parse(position[0]);
                        int y = int.Parse(position[1]);
                        toyRobot.Place(x, y, direction);
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
                }
            }
        }
    }
}

   