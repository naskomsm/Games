namespace SimpleSnake.GameObjects.Foods
{
    using SimpleSnake.Constants;

    public class HashFood : Food
    {
        public HashFood(Coordinate coordinate)
            : base(GameConstant.Food.HashSymbol, GameConstant.Food.HashPoints, coordinate)
        {
        }
    }
}
