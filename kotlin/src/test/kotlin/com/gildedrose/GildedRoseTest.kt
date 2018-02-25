package com.gildedrose

import org.junit.Assert.assertEquals
import org.junit.Test

class GildedRoseTest {

    private lateinit var app: GildedRose

    @Test
    fun `at the end of each day our system lowers both values for every item`() {
        givenItem(name = "foo", sellIn = 10, quality = 10)
        whenWeUpdateTheQuality()
        thenItemHas(name = "foo", sellIn = 9, quality = 9)
    }

    @Test
    fun `the Quality of an item is never negative`() {
        givenItem(name = "foo", sellIn = 10, quality = 0)
        whenWeUpdateTheQuality()
        thenItemHas(name = "foo", sellIn = 9, quality = 0)
    }

    @Test
    fun `once the sell by date has passed Quality degrades twice as fast`() {
        givenItem(name = "foo", sellIn = 0, quality = 10)
        whenWeUpdateTheQuality()
        thenItemHas(name = "foo", sellIn = -1, quality = 8)
    }

    @Test
    fun `once the sell by date has passed Quality degrades twice as fast 2`() {
        givenItem(name = "foo", sellIn = 0, quality = 1)
        whenWeUpdateTheQuality()
        thenItemHas(name = "foo", sellIn = -1, quality = 0)
    }

    @Test
    fun `Aged Brie  actually increases in Quality the older it gets`() {
        givenItem(name = "Aged Brie", sellIn = 10, quality = 10)
        whenWeUpdateTheQuality()
        thenItemHas(name = "Aged Brie", sellIn = 9, quality = 11)
    }

    @Test
    fun `the Quality of an item is never more than 50`() {
        givenItem(name = "Aged Brie", sellIn = 10, quality = 50)
        whenWeUpdateTheQuality()
        thenItemHas(name = "Aged Brie", sellIn = 9, quality = 50)
    }

    @Test
    fun `Sulfuras being a legendary item never has to be sold or decreases in Quality`() {
        val sulfuras = "Sulfuras, Hand of Ragnaros"
        givenItem(name = sulfuras, sellIn = 10, quality = 80)
        whenWeUpdateTheQuality()
        thenItemHas(name = sulfuras, sellIn = 10, quality = 80)
    }

    @Test
    fun `backstage passes increases in Quality as its SellIn value approaches`() {
        testBackstagePass(sellIn = 20, startQuality = 10, expectedQuality = 11)
        testBackstagePass(sellIn = 11, startQuality = 10, expectedQuality = 11)
        testBackstagePass(sellIn = 10, startQuality = 10, expectedQuality = 12)
        testBackstagePass(sellIn = 9, startQuality = 10, expectedQuality = 12)
        testBackstagePass(sellIn = 6, startQuality = 10, expectedQuality = 12)
        testBackstagePass(sellIn = 5, startQuality = 10, expectedQuality = 13)
        testBackstagePass(sellIn = 4, startQuality = 10, expectedQuality = 13)
        testBackstagePass(sellIn = 1, startQuality = 10, expectedQuality = 13)
        testBackstagePass(sellIn = 0, startQuality = 10, expectedQuality = 0)
        testBackstagePass(sellIn = -1, startQuality = 10, expectedQuality = 0)

        testBackstagePass(sellIn = 20, startQuality = 50, expectedQuality = 50)
        testBackstagePass(sellIn = 9, startQuality = 50, expectedQuality = 50)
        testBackstagePass(sellIn = 3, startQuality = 50, expectedQuality = 50)
    }

    private fun testBackstagePass(sellIn: Int, startQuality: Int, expectedQuality: Int) {
        val backstagePass = "Backstage passes to a TAFKAL80ETC concert"
        givenItem(backstagePass, sellIn, startQuality)
        whenWeUpdateTheQuality()
        assertEquals("quality for sellIn " + sellIn, expectedQuality, app.items[0].quality)
        assertEquals("new sellIn for old sellIn " + sellIn, sellIn - 1, app.items[0].sellIn)
    }

    private fun givenItem(name: String, sellIn: Int, quality: Int) {
        app = GildedRose(arrayOf(Item(name, sellIn, quality)))
    }

    private fun whenWeUpdateTheQuality() {
        app.updateItems()
    }

    private fun thenItemHas(name: String, sellIn: Int, quality: Int) {
        assertEquals(name, app.items[0].name)
        assertEquals("sellIn", sellIn, app.items[0].sellIn)
        assertEquals("quality", quality, app.items[0].quality)
    }
}


