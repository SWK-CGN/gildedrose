namespace csharp.Strategies
{
    public class AgedBrieStrategy : ItemStrategy
    {
        protected override void HandleQualityOf(Item item)
        {
            IncreaseQuality(item);

            if (!SellInDatePassed(item)) return;
            IncreaseQuality(item);
        }
    }
}