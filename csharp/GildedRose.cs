using System.Collections.Generic;
using ApprovalUtilities.Utilities;
using csharp.Strategies;

namespace csharp
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string Conjured = "Conjured Mana Cake";

        private readonly IList<Item> _items;

        private static readonly Dictionary<string, IItemStrategy> ItemStrategies = new Dictionary<string, IItemStrategy>
        {
            { Sulfuras, new SulfurasStrategy() },
            { AgedBrie, new AgedBrieStrategy() },
            { BackstagePasses, new BackstagePassesStrategy() },
            { Conjured, new ConjuredStrategy() }
        };

        private static readonly ItemStrategy DefaultItemStrategy = new ItemStrategy();

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            _items.ForEach(HandleItem);
        }

        private static void HandleItem(Item item)
        {
            GetItemStrategy(item).Handle(item);
        }

        private static IItemStrategy GetItemStrategy(Item item)
        {
            return ItemStrategies.ContainsKey(item.Name) ? ItemStrategies[item.Name] : DefaultItemStrategy;
        }
    }
}