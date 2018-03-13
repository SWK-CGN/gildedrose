namespace csharp.Strategies
{
    public class BackstagePassesStrategy : ItemStrategy {
        private const int TenDays = 10;
        private const int FiveDays = 5;

        protected override void HandleQualityOf(Item item)
        {
            if (SellInDatePassed(item))
            {
                item.Quality = QualityMinimum;
                return;
            }

            IncreaseQuality(item);

            if (item.SellIn >= TenDays) return;
            IncreaseQuality(item);

            if (item.SellIn >= FiveDays) return;
            IncreaseQuality(item);
        }
    }
}