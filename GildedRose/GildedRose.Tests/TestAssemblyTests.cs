using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit.Abstractions;

namespace GildedRose.Tests
{/*
    public class TestAssemblyTests
    {
        private const string DEXTERITY_NAME = "+5 Dexterity Vest";
        private const string AGED_BRIE_NAME = "Aged Brie";
        private const string ELIXIR_OF_THE_MONGOOSE_NAME = "Elixir of the Mongoose";
        private const string SULFURAS_NAME = "Sulfuras, Hand of Ragnaros";
        private const string BACKSTAGE_PASSES_NAME = "Backstage passes to a TAFKAL80ETC concert";
        private const string CONJURED_NAME = "Conjured Mana Cake";

        private List<Item> InitializeItems()
        {
            return new List<Item>()
            {
                new Item {Name = DEXTERITY_NAME, SellIn = 10, Quality = 20},
                new Item {Name = AGED_BRIE_NAME, SellIn = 2, Quality = 0},
                new Item {Name = ELIXIR_OF_THE_MONGOOSE_NAME, SellIn = 5, Quality = 7},
                new Item {Name = SULFURAS_NAME, SellIn = 0, Quality = 80},
                new Item
                    {
                        Name = BACKSTAGE_PASSES_NAME,
                        SellIn = 15,
                        Quality = 20
                    },
                new Item {Name = CONJURED_NAME, SellIn = 3, Quality = 6}
            };
        }

        private bool CommonRuleLimits(Item itemToEvaluate)
        {
            return itemToEvaluate.Quality >= 0 && itemToEvaluate.Quality <= 50;
        }

        [Fact]
        public void TestPlus5DexterityVest()
        {
            var items = InitializeItems();
            ItemLogic itemLogic = new ItemLogic(items);
            var itemBeforeUpdate = itemLogic.GetItems().First(x => x.Name == DEXTERITY_NAME);
            var sellInBefore = itemBeforeUpdate.SellIn;
            var qualityBefore = itemBeforeUpdate.Quality;
            itemLogic.UpdateQuality();

            var itemToEvaluate = itemLogic.GetItems().First(x => x.Name == DEXTERITY_NAME);

            Assert.Equal(sellInBefore - 1, itemToEvaluate.SellIn);
            Assert.Equal(qualityBefore - 1, itemToEvaluate.Quality);
            Assert.True(CommonRuleLimits(itemToEvaluate));
        }

        [Fact]
        public void TestAgedBrie()
        {
            var items = InitializeItems();
            ItemLogic itemLogic = new ItemLogic(items);
            var itemBeforeUpdate = itemLogic.GetItems().First(x => x.Name == AGED_BRIE_NAME);
            var sellInBefore = itemBeforeUpdate.SellIn;
            var qualityBefore = itemBeforeUpdate.Quality;
            itemLogic.UpdateQuality();

            var itemToEvaluate = itemLogic.GetItems().First(x => x.Name == AGED_BRIE_NAME);

            Assert.Equal(sellInBefore - 1, itemToEvaluate.SellIn);
            Assert.Equal(qualityBefore + 1, itemToEvaluate.Quality);
            Assert.True(CommonRuleLimits(itemToEvaluate));
        }

        [Fact]
        public void TestElixirOfTheMongoose()
        {
            var items = InitializeItems();
            ItemLogic itemLogic = new ItemLogic(items);
            var itemBeforeUpdate = itemLogic.GetItems().First(x => x.Name == ELIXIR_OF_THE_MONGOOSE_NAME);
            var sellInBefore = itemBeforeUpdate.SellIn;
            var qualityBefore = itemBeforeUpdate.Quality;
            itemLogic.UpdateQuality();

            var itemToEvaluate = itemLogic.GetItems().First(x => x.Name == ELIXIR_OF_THE_MONGOOSE_NAME);

            Assert.Equal(sellInBefore - 1, itemToEvaluate.SellIn);
            Assert.Equal(qualityBefore - 1, itemToEvaluate.Quality);
            Assert.True(CommonRuleLimits(itemToEvaluate));
        }

        [Fact]
        public void TestSulfuras()
        {
            var items = InitializeItems();
            ItemLogic itemLogic = new ItemLogic(items);
            itemLogic.UpdateQuality();

            var itemToEvaluate = itemLogic.GetItems().First(x => x.Name == SULFURAS_NAME);

            Assert.Equal(0, itemToEvaluate.SellIn);
            Assert.Equal(80, itemToEvaluate.Quality);
        }

        [Fact]
        public void TestBackstagePasses()
        {
            int adjustRealSellIn(int value)
            {
                int sellInFactorDecrease = -1;
                return value + sellInFactorDecrease;
            }

            var items = InitializeItems();
            ItemLogic itemLogic = new ItemLogic(items);
            var itemQualityBeforeUpdate = itemLogic.GetItems().First(x => x.Name == BACKSTAGE_PASSES_NAME).Quality;
            itemLogic.UpdateQuality();

            var itemToEvaluate = itemLogic.GetItems().First(x => x.Name == BACKSTAGE_PASSES_NAME);
            
            Assert.True(CommonRuleLimits(itemToEvaluate));
            
            if (itemToEvaluate.SellIn == adjustRealSellIn(0))
            {
                Assert.Equal(0, itemToEvaluate.Quality);
                return;
            }

            if (itemToEvaluate.SellIn > adjustRealSellIn(0) && itemToEvaluate.SellIn <= adjustRealSellIn(5))
            {
                Assert.Equal(itemQualityBeforeUpdate + 3, itemToEvaluate.Quality);
                return;
            }

            if (itemToEvaluate.SellIn > adjustRealSellIn(5) && itemToEvaluate.SellIn <= adjustRealSellIn(10))
            {
                Assert.Equal(itemQualityBeforeUpdate + 2, itemToEvaluate.Quality);
                return;
            }

            if (itemToEvaluate.SellIn > adjustRealSellIn(10))
            {
                Assert.Equal(itemQualityBeforeUpdate + 1, itemToEvaluate.Quality);
                return;
            }
        }
    }*/
}