package com.gildedrose

class GildedRose(var items: Array<Item>) {

    fun updateItems() {
        items.forEach { updateItem(it) }
    }

    private fun updateItem(item: Item) = when {
        item.name == "Aged Brie"                                 -> updateCheese(item)
        item.name == "Backstage passes to a TAFKAL80ETC concert" -> updateBackstagePasses(item)
        item.name == "Sulfuras, Hand of Ragnaros"                -> updateLegendary(item)
        else                                                     -> updateNormalItem(item)
    }

    private fun updateNormalItem(item: Item) {
        item.decreaseQuality()
        item.decreaseSellIn()
        if (item.sellIn < 0) {
            item.decreaseQuality()
        }
    }

    private fun updateCheese(item: Item) {
        item.increaseQuality()
        item.decreaseSellIn()
        if (item.sellIn < 0) {
            item.increaseQuality()
        }
    }

    @Suppress("UNUSED_PARAMETER")
    private fun updateLegendary(item: Item) {
    }

    private fun updateBackstagePasses(item: Item) {
        item.decreaseSellIn()
        if (item.sellIn < 0) {
            item.quality = 0
            return
        }

        item.increaseQuality()
        if (item.sellIn < 10) {
            item.increaseQuality()
        }
        if (item.sellIn < 5) {
            item.increaseQuality()
        }
    }

    private fun Item.increaseQuality() {
        if (this.quality < 50) {
            this.quality += 1
        }
    }

    private fun Item.decreaseQuality() {
        if (this.quality > 0) {
            this.quality -= 1
        }
    }

    private fun Item.decreaseSellIn() {
        this.sellIn -= 1
    }

}
