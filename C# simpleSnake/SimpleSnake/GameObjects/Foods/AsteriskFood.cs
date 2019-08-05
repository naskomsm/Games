namespace SimpleSnake.GameObjects.Foods
{
    using SimpleSnake.Constants;

    public class AsteriskFood : Food
    {
        public AsteriskFood(Coordinate coordinate) 
            : base(GameConstant.Food.AsteriksSymbol, GameConstant.Food.AsteriksPoints, coordinate)
        {
        }
    }
}
