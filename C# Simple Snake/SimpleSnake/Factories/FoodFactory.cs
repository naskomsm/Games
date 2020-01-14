namespace SimpleSnake.Factories
{
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Foods;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class FoodFactory
    {
        private static Random random;

        static FoodFactory()
        {
            random = new Random();
        }

        public static Food GetRandomFood(int boardWidth, int boardHeight)
        {
            List<Type> foodType = Assembly.
                GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.BaseType == typeof(Food))
                .ToList();

            var currentFoodType = foodType[random.Next(0, foodType.Count)];

            int coordinateX = random.Next(1, boardWidth - 1);
            int coordinateY = random.Next(1, boardHeight - 1);

            Coordinate coordinate = new Coordinate(coordinateX, coordinateY);

            var instance = (Food)Activator.CreateInstance(currentFoodType, new object[] { coordinate });

            return instance;
        }
    }
}
