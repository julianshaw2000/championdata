using System.Reflection.Metadata;
using Microsoft.VisualBasic;
using Constants = Robot.Lib.Constants;

namespace Robot.Lib
{
    /// <summary>
    /// Represents a toy robot moving on a square tabletop.
    /// </summary>
    public class ToyRobot
    {
        private int x;
        private int y;

        /// <summary>
        /// Gets or sets the direction the robot is facing.
        /// </summary>
        public Direction direction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the robot has been placed on the tabletop.
        /// </summary>
        public bool isPlaced { get; set; }

        /// <summary>
        /// Initializes a new instance of the ToyRobot class.
        /// The robot is not placed on the tabletop initially.
        /// </summary>
        public ToyRobot()
        {
            isPlaced = false;
        }

        /// <summary>
        /// Places the robot on the tabletop at the specified position and facing direction.
        /// </summary>
        /// <param name="x">The X-coordinate of the position.</param>
        /// <param name="y">The Y-coordinate of the position.</param>
        /// <param name="direction">The direction the robot is facing.</param>
        /// <returns>True if the robot is successfully placed, otherwise false.</returns>
        public bool Place(int x, int y, Direction direction)
        {
            if (x < 0 || x > Constants.TableWidth || y < 0 || y > Constants.TableHeight)
                return false;

            this.x = x;
            this.y = y;
            this.direction = direction;
            isPlaced = true;
            return true;
        }

        /// <summary>
        /// Moves the robot one unit forward in the direction it is currently facing.
        /// </summary>
        public void Move()
        {
            if (!isPlaced)
                return;

            int newX = direction switch
            {
                Direction.NORTH => x,
                Direction.EAST => x + 1,
                Direction.SOUTH => x,
                Direction.WEST => x - 1,
                _ => x
            };

            int newY = direction switch
            {
                Direction.NORTH => y + 1,
                Direction.EAST => y,
                Direction.SOUTH => y - 1,
                Direction.WEST => y,
                _ => y
            };

            if (newX >= 0 && newX <= Constants.TableWidth && newY >= 0 && newY <= Constants.TableHeight)
            {
                x = newX;
                y = newY;
            }
        }

        /// <summary>
        /// Rotates the robot 90 degrees to the left without changing its position.
        /// </summary>
        public void Left()
        {
            if (isPlaced)
                direction = (Direction)(((int)direction + 3) % 4);
        }

        /// <summary>
        /// Rotates the robot 90 degrees to the right without changing its position.
        /// </summary>
        public void Right()
        {
            if (isPlaced)
                direction = (Direction)(((int)direction + 1) % 4);
        }

        /// <summary>
        /// Reports the current position and facing direction of the robot.
        /// </summary>
        /// <returns>A string representing the robot's position and direction.</returns>
        public string Report()
        {
            if (isPlaced)
                return $"{x},{y},{direction}";
            else
                return Constants.UnplacedRobot;
        }
    }
}
