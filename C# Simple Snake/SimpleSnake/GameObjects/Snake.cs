namespace SimpleSnake.GameObjects
{
    using SimpleSnake.Constants;
    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects.Foods;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake
    {
        private List<Coordinate> snakeBody;

        public Snake()
        {
            this.snakeBody = new List<Coordinate>();
            this.Direction = Direction.Right;
            this.InitializeBody();
        }

        public IReadOnlyCollection<Coordinate> Body => this.snakeBody.AsReadOnly();

        public Direction Direction { get; set; }

        public Coordinate Head => this.snakeBody.Last();

        private void InitializeBody()
        {
            int x = GameConstant.Snake.DefaultX;
            int y = GameConstant.Snake.DefaultY;

            // becouse of the default lenght we need to loop to 6;
            for (int i = 0; i <= GameConstant.Snake.DefaultLenght; i++)
            {
                this.snakeBody.Add(new Coordinate(x, y));
                x++;
            }
        }

        public void Move()
        {
            Coordinate newHead = this.GetNewHeadCoordinates();

            this.snakeBody.Add(newHead);
            this.snakeBody.RemoveAt(0);
        }

        // movement
        private Coordinate GetNewHeadCoordinates()
        {
            Coordinate newHeadCoordinate = new Coordinate(this.Head.CoordinateX, this.Head.CoordinateY);

            switch (this.Direction)
            {
                case Direction.Right:
                    newHeadCoordinate.CoordinateX++;
                    break;
                case Direction.Left:
                    newHeadCoordinate.CoordinateX--;
                    break;
                case Direction.Down:
                    newHeadCoordinate.CoordinateY++;
                    break;
                case Direction.Up:
                    newHeadCoordinate.CoordinateY--;
                    break;
                default:
                    break;
            }

            return newHeadCoordinate;
        }

        public void Eat(Food food)
        {
            for (int i = 0; i < food.Points; i++)
            {
                Coordinate newHeadCoordinate = this.GetNewHeadCoordinates();
                this.snakeBody.Add(newHeadCoordinate);
            }
        }
    }
}
