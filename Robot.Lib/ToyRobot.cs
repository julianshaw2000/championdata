using Microsoft.VisualBasic;
namespace Robot.Lib;
public class ToyRobot
{
    
        private const int TableWidth = 5;
        private const int TableHeight = 5;

        private int x;
        private int y;
        public Direction direction; 
        public bool isPlaced { get;  set; }

    public ToyRobot()
        {
            isPlaced = false;
        }

        public bool Place(int x, int y, Direction direction)
        {
            if (x < 0 || x > TableWidth || y < 0 || y > TableHeight)
                return false;

            this.x = x;
            this.y = y;
            this.direction = direction;
            isPlaced = true;
            return true;
        }

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

            if (newX >= 0 && newX <= TableWidth && newY >= 0 && newY <= TableHeight)
            {
                x = newX;
                y = newY;
            }
        }

        public void Left()
        {
            if (isPlaced)
                direction = (Direction)(((int)direction + 3) % 4);
        }

        public void Right()
        {
            if (isPlaced)
                direction = (Direction)(((int)direction + 3) % 4);
        }

        public string Report()
        {
            if (isPlaced)
                return $"{x},{y},{direction}";
            else
                return Constants.UnplacedRobot;
        }
    


}
