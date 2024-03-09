using GildedRose.Console;
using GildedRose.Console.Logic;
using GildedRose.Console.Logic.Abstractions;

namespace GildedRose.Tests
{
    public class TestRefactoring
    {
        private List<Item> InitializeItems()
        {
            return new List<Item>()
            {
                new Plus5DexterityVest(10, 20),
                new AgedBrie(2, 0),
                new ElixirOfTheMongoose(5, 7),
                new Sulfuras(0, 80),
                new BackstagePasses(0, 20),
                //    {
                //        Name = BACKSTAGE_PASSES_NAME,
                //        SellIn = 15,
                //        Quality = 20
                //    },
                //new Item {Name = CONJURED_NAME, SellIn = 3, Quality = 6}
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
            var itemExecution = new ItemExecution(items);

            foreach (var itemToEvaluate in itemExecution.Items.Where(x => x is Plus5DexterityVest))
            {
                var sellInBefore = itemToEvaluate.SellIn;
                var qualityBefore = itemToEvaluate.Quality;

                itemToEvaluate.UpdateItem();

                Assert.Equal(sellInBefore - 1, itemToEvaluate.SellIn);
                Assert.Equal(qualityBefore - 1, itemToEvaluate.Quality);
                Assert.True(CommonRuleLimits(itemToEvaluate));
            }
        }

        [Fact]
        public void TestAgedBrie()
        {
            var items = InitializeItems();
            var itemExecution = new ItemExecution(items);

            foreach (var itemToEvaluate in itemExecution.Items.Where(x => x is AgedBrie))
            {
                var sellInBefore = itemToEvaluate.SellIn;
                var qualityBefore = itemToEvaluate.Quality;

                itemToEvaluate.UpdateItem();

                Assert.Equal(sellInBefore - 1, itemToEvaluate.SellIn);
                Assert.Equal(qualityBefore + 1, itemToEvaluate.Quality);
                Assert.True(CommonRuleLimits(itemToEvaluate));
            }
        }

        [Fact]
        public void TestElixirOfTheMongoose()
        {
            var items = InitializeItems();
            var itemExecution = new ItemExecution(items);

            foreach (var itemToEvaluate in itemExecution.Items.Where(x => x is ElixirOfTheMongoose))
            {
                var sellInBefore = itemToEvaluate.SellIn;
                var qualityBefore = itemToEvaluate.Quality;

                itemToEvaluate.UpdateItem();

                Assert.Equal(sellInBefore - 1, itemToEvaluate.SellIn);
                Assert.Equal(qualityBefore - 1, itemToEvaluate.Quality);
                Assert.True(CommonRuleLimits(itemToEvaluate));
            }
        }

        [Fact]
        public void TestSulfuras()
        {
            var items = InitializeItems();
            var itemExecution = new ItemExecution(items);

            foreach (var itemToEvaluate in itemExecution.Items.Where(x => x is Sulfuras))
            {
                var sellInBefore = itemToEvaluate.SellIn;
                var qualityBefore = itemToEvaluate.Quality;

                itemToEvaluate.UpdateItem();

                Assert.Equal(0, itemToEvaluate.SellIn);
                Assert.Equal(80, itemToEvaluate.Quality);
            }
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
            var itemExecution = new ItemExecution(items);

            foreach (var itemToEvaluate in itemExecution.Items.Where(x => x is BackstagePasses))
            {
                int qualityBefore = itemToEvaluate.Quality;

                itemToEvaluate.UpdateItem();

                Assert.True(CommonRuleLimits(itemToEvaluate));

                if (itemToEvaluate.SellIn == adjustRealSellIn(0))
                {
                    Assert.Equal(0, itemToEvaluate.Quality);
                    return;
                }

                if (itemToEvaluate.SellIn > adjustRealSellIn(0) && itemToEvaluate.SellIn <= adjustRealSellIn(5))
                {
                    Assert.Equal(qualityBefore + 3, itemToEvaluate.Quality);
                    return;
                }

                if (itemToEvaluate.SellIn > adjustRealSellIn(5) && itemToEvaluate.SellIn <= adjustRealSellIn(10))
                {
                    Assert.Equal(qualityBefore + 2, itemToEvaluate.Quality);
                    return;
                }

                if (itemToEvaluate.SellIn > adjustRealSellIn(10))
                {
                    Assert.Equal(qualityBefore + 1, itemToEvaluate.Quality);
                    return;
                }
            }
        }
    }
}
