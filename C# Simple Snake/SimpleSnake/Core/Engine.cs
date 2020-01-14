namespace SimpleSnake.Core
{
    using SimpleSnake.Constants;
    using SimpleSnake.Enums;
    using SimpleSnake.Factories;
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Foods;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class Engine
    {
        private DrawManager drawManager;
        private Snake snake;
        private Food food;
        private Coordinate boardCoordinate;
        private int gameScore;

        public Engine(DrawManager drawManager, Snake snake, Coordinate boardCoordinate)
        {
            this.drawManager = drawManager;
            this.snake = snake;
            this.boardCoordinate = boardCoordinate;

            this.InitializeFood();
            this.InitializeBorders();
        }

        public void Run()
        {
            while (true)
            {
                this.PlayerInfo();

                if (Console.KeyAvailable)
                {
                    this.SetCorrectDirecton(Console.ReadKey());
                }

                // draws the food on the console
                this.drawManager.Draw(food.Symbol, new List<Coordinate> { food.Coordinate });

                // draws the snake and her movement on the console
                this.drawManager.Draw(GameConstant.Snake.Symbol, snake.Body);
                this.snake.Move();
                this.drawManager.UndoDraw();

                if (HasBoardCollision())
                {
                    this.AskPlayerForRestart();
                }

                if (HasFoodCollision())
                {
                    this.snake.Eat(this.food);
                    this.gameScore += this.food.Points;
                    this.InitializeFood();
                }

                // Some attemp to fix the bug when the snake is moving up and down ( it is moving faster than usual )
                if (snake.Direction == Direction.Up && snake.Direction == Direction.Down)
                {
                    Thread.Sleep(200);
                }
                else
                {
                    Thread.Sleep(150);
                }
            }
        }

        private void PlayerInfo()
        {
            int x = GameConstant.Board.DefaultBoardWidth + GameConstant.Player.PlayerScoreOffsetX;
            int y = GameConstant.Player.PlayerScoreOffsetY; 

            Console.SetCursorPosition(x, y);
            Console.Write($"Game score: {this.gameScore}");
        }

        private void AskPlayerForRestart()
        {
            Console.SetCursorPosition(GameConstant.Config.EndMessageX, GameConstant.Config.EndMessageY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Would you like to continue?");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Y/N");

            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.Y)
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                return;
            }

        }

        private bool HasBoardCollision()
        {
            int snakeHeadCoordinateX = this.snake.Head.CoordinateX;
            int snakeHeadCoordinateY = this.snake.Head.CoordinateY;

            int boardCoordinateX = this.boardCoordinate.CoordinateX;
            int boardCoordinateY = this.boardCoordinate.CoordinateY;

            return snakeHeadCoordinateX == boardCoordinateX - 2
                || snakeHeadCoordinateX == 3 
                || snakeHeadCoordinateY == 1
                || snakeHeadCoordinateY == boardCoordinateY;
        }

        private void SetCorrectDirecton(ConsoleKeyInfo input)
        {
            Direction currentSnakeDirection = this.snake.Direction;

            switch (input.Key)
            {
                case ConsoleKey.DownArrow:
                    if (currentSnakeDirection != Direction.Up)
                    {
                        currentSnakeDirection = Direction.Down;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentSnakeDirection != Direction.Right)
                    {
                        currentSnakeDirection = Direction.Left;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (currentSnakeDirection != Direction.Left)
                    {
                        currentSnakeDirection = Direction.Right;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (currentSnakeDirection != Direction.Down)
                    {
                        currentSnakeDirection = Direction.Up;
                    }
                    break;

                default:
                    break;
            }

            this.snake.Direction = currentSnakeDirection;
        }

        private bool HasFoodCollision()
        {
            int snakeHeadCoordinateX = this.snake.Head.CoordinateX;
            int snakeHeadCoordinateY = this.snake.Head.CoordinateY;

            int foodCoordinateX = food.Coordinate.CoordinateX;
            int foodCoordinateY = food.Coordinate.CoordinateY;

            return snakeHeadCoordinateX == foodCoordinateX && snakeHeadCoordinateY == foodCoordinateY;
        }

        private void InitializeFood()
        {
            this.food = FoodFactory.GetRandomFood(this.boardCoordinate.CoordinateX, this.boardCoordinate.CoordinateY);
        }

        // rip my brain
        private void InitializeBorders()
        {
            List<Coordinate> allCoordinates = new List<Coordinate>();

            this.InitializeHorizontalBorderCoordinate(1, allCoordinates);
            this.InitializeHorizontalBorderCoordinate(this.boardCoordinate.CoordinateY, allCoordinates);

            this.InitializeVerticalBorderCoordinate(2, allCoordinates);
            this.InitializeVerticalBorderCoordinate(3, allCoordinates);
            this.InitializeVerticalBorderCoordinate(this.boardCoordinate.CoordinateX - 1, allCoordinates);
            this.InitializeVerticalBorderCoordinate(this.boardCoordinate.CoordinateX - 2, allCoordinates);

            this.drawManager.Draw(GameConstant.Board.DefaultBoardSymbol, allCoordinates);
        }

        private void InitializeVerticalBorderCoordinate(int coordinateX, List<Coordinate> allCoordinates)
        {
            for (int coordinateY = 1; coordinateY < this.boardCoordinate.CoordinateY; coordinateY++)
            {
                allCoordinates.Add(new Coordinate(coordinateX, coordinateY));
            }
        }

        private void InitializeHorizontalBorderCoordinate(int coordinateY, List<Coordinate> allCoordinates)
        {
            for (int coordinateX = 2; coordinateX < this.boardCoordinate.CoordinateX; coordinateX++)
            {
                allCoordinates.Add(new Coordinate(coordinateX, coordinateY));
            }
        }
    }
}
