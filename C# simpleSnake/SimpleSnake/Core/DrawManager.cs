namespace SimpleSnake.Core
{
    using SimpleSnake.GameObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DrawManager
    {
        private const string SnakeSymbol = "\u25CF";
        private List<Coordinate> snakeBodyElements;

        public DrawManager()
        {
            this.snakeBodyElements = new List<Coordinate>();
        }

        public void Draw(string symbol, IEnumerable<Coordinate> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                if (symbol == SnakeSymbol)
                {
                    snakeBodyElements.Add(coordinate);
                }
                
                Console.SetCursorPosition(coordinate.CoordinateX, coordinate.CoordinateY);
                Console.Write(symbol);
            }
        }

        public void UndoDraw()
        {
            Coordinate lastElementInCollection = this.snakeBodyElements.First();

            Console.SetCursorPosition(lastElementInCollection.CoordinateX, lastElementInCollection.CoordinateY);
            Console.Write(" ");

            this.snakeBodyElements.Clear();
        }
    }
}
