namespace csharp.Strategies
{
    public class ItemStrategy : IItemStrategy
    {
        protected const int QualityMinimum = 0;
        protected const int QualityMaximum = 50;
        protected const int SellInDateReached = 0;

        // GOF: TemplateMethod
        public void Handle(Item item)
        {
            HandleSellInOf(item);
            HandleQualityOf(item);
        }

        protected virtual void HandleQualityOf(Item item)
        {
            DegradeQuality(item);

            if (!SellInDatePassed(item)) return;
            DegradeQuality(item);
        }

        protected virtual void HandleSellInOf(Item item)
        {
            item.SellIn--;
        }

        protected static bool SellInDatePassed(Item item)
        {
            return !(item.SellIn >= SellInDateReached);
        }

        protected static void DegradeQuality(Item item)
        {
            if (item.Quality > QualityMinimum)
            {
                item.Quality--;
            }
        }

        protected static void IncreaseQuality(Item item)
        {
            if (item.Quality < QualityMaximum)
            {
                item.Quality++;
            }
        }
    }
}