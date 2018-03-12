namespace csharp.Strategies
{
    public class ConjuredStrategy : ItemStrategy
    {
        protected override void HandleQualityOf(Item item)
        {
            DegradeQuality(item);
            DegradeQuality(item);

            if (!SellInDatePassed(item)) return;

            DegradeQuality(item);
            DegradeQuality(item);
        }
    }
}