using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void AllItems_ShouldDegradeSellIn()
        {
            var item = new Item {Name = "Normal Item", SellIn = 5, Quality = 0};

            UpdateQualityOf(item);

            item.SellIn.Should().Be(4);
        }

        [Test]
        public void NormalItem_ShouldDegradeQuality()
        {
            var item = new Item {Name = "Normal Item", SellIn = 5, Quality = 5};

            UpdateQualityOf(item);

            item.Quality.Should().Be(4);
        }

        [Test]
        public void NormalItem_WhenSellInDatePassed_ShouldDegradeQualityTwice()
        {
            var item = new Item {Name = "Normal Item", SellIn = 0, Quality = 5};

            UpdateQualityOf(item);

            item.Quality.Should().Be(3);
        }

        [Test]
        public void AllItems_QualityShouldNeverBeLowerThanZero()
        {
            var item = new Item {Name = "Normal Item", SellIn = 10, Quality = 0};

            UpdateQualityOf(item);

            item.Quality.Should().Be(0);
        }

        [Test]
        public void AllItems_QualityShouldNeverBeHigherThan50()
        {
            var item = new Item {Name = "Aged Brie", SellIn = 5, Quality = 50};

            UpdateQualityOf(item);

            item.Quality.Should().Be(50);
        }

        [Test]
        public void AgedBrie_ShouldIncreaseQuality()
        {
            var item = new Item {Name = "Aged Brie", SellIn = 5, Quality = 5};

            UpdateQualityOf(item);

            item.Quality.Should().Be(6);
        }

        [Test]
        public void Sulfuras_SellInShouldBeFixed()
        {
            var item = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80};

            UpdateQualityOf(item);

            item.SellIn.Should().Be(10);
        }

        [Test]
        public void Sulfuras_QualityShouldBeFixed()
        {
            var item = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80};

            UpdateQualityOf(item);

            item.Quality.Should().Be(80);
        }

        [Test]
        public void BackstagePasses_ShouldIncreaseQuality()
        {
            var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 5};

            UpdateQualityOf(item);

            item.Quality.Should().Be(6);
        }

        [Test]
        public void BackstagePasses_WhenSellInLowerOrEqualTo10_ShouldIncreaseQualityTwice()
        {
            var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5};

            UpdateQualityOf(item);

            item.Quality.Should().Be(7);
        }

        [Test]
        public void BackstagePasses_WhenSellInLowerOrEqualTo5_ShouldIncreaseQualityTwice()
        {
            var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5};

            UpdateQualityOf(item);

            item.Quality.Should().Be(8);
        }

        [Test]
        public void BackstagePasses_WhenSellInIsPassed_QualityShouldBeZero()
        {
            var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5};

            UpdateQualityOf(item);

            item.Quality.Should().Be(0);
        }

        [Test]
        public void Conjured_ShouldDegradeTwiceAsFastAsNormalItems()
        {
            var item = new Item {Name = "Conjured Mana Cake", SellIn = 5, Quality = 5};

            UpdateQualityOf(item);

            item.Quality.Should().Be(3);
        }

        [Test]
        public void Conjured_WhenSellInPassed_ShouldTwiceAsFastAsUsually()
        {
            var item = new Item {Name = "Conjured Mana Cake", SellIn = 0, Quality = 5};

            UpdateQualityOf(item);

            item.Quality.Should().Be(1);
        }

        private static void UpdateQualityOf(Item item)
        {
            var app = new GildedRose(new List<Item> {item});
            app.UpdateQuality();
        }
    }
}