using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robot.Lib
{
    public static class Constants
    {        
        public const int TableWidth = 5;
        public const int TableHeight = 5;
        public const string UnplacedRobot = "Toy robot not placed on the table";
        public const string SuccessPlacement = "Toy robot placed successfully.";
        public const string InvalidPlacement = "Invalid placement. The robot cannot be placed outside the table.";
        public const string InvalidCommand = "Invalid command. Please enter a valid command.";
    }
}