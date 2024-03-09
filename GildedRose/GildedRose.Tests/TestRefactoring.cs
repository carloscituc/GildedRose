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
                new BackstagePasses(15, 20),
                new Conjured(3, 6),
            };
        }

        private bool CommonRuleLimits(Item itemToEvaluate)
        {
            return itemToEvaluate.Quality >= 0 && itemToEvaluate.Quality <= 50;
        }

        private int AdjustQualityMinToTheLimit(int qualityUpdated, int qualityMin)
        {
            return qualityUpdated < qualityMin ? qualityMin : qualityUpdated;
        }

        private int AdjustQualityMaxToTheLimit(int qualityUpdated, int qualityMax)
        {
            return qualityUpdated > qualityMax ? qualityMax : qualityUpdated;
        }

        [Fact]
        public void TestPlus5DexterityVest()
        {
            var items = InitializeItems();
            var itemExecution = new ItemExecution(items);
            int qualityMin = 0;

            foreach (var itemToEvaluate in itemExecution.Items.Where(x => x is Plus5DexterityVest))
            {
                var sellInBefore = itemToEvaluate.SellIn;
                var qualityBefore = itemToEvaluate.Quality;

                itemToEvaluate.UpdateItem();

                int qualityUpdated = qualityBefore - 1;
                Assert.Equal(sellInBefore - 1, itemToEvaluate.SellIn);
                Assert.Equal(AdjustQualityMinToTheLimit(qualityUpdated, qualityMin), itemToEvaluate.Quality);
                Assert.True(CommonRuleLimits(itemToEvaluate));
            }
        }

        [Fact]
        public void TestAgedBrie()
        {
            var items = InitializeItems();
            var itemExecution = new ItemExecution(items);
            int qualityMax = 50;

            foreach (var itemToEvaluate in itemExecution.Items.Where(x => x is AgedBrie))
            {
                var sellInBefore = itemToEvaluate.SellIn;
                var qualityBefore = itemToEvaluate.Quality;

                itemToEvaluate.UpdateItem();

                int qualityUpdated = qualityBefore + 1;
                Assert.Equal(sellInBefore - 1, itemToEvaluate.SellIn);
                Assert.Equal(AdjustQualityMaxToTheLimit(qualityUpdated, qualityMax), itemToEvaluate.Quality);
                Assert.True(CommonRuleLimits(itemToEvaluate));
            }
        }

        [Fact]
        public void TestElixirOfTheMongoose()
        {
            var items = InitializeItems();
            var itemExecution = new ItemExecution(items);
            int qualityMin = 0;

            foreach (var itemToEvaluate in itemExecution.Items.Where(x => x is ElixirOfTheMongoose))
            {
                var sellInBefore = itemToEvaluate.SellIn;
                var qualityBefore = itemToEvaluate.Quality;

                itemToEvaluate.UpdateItem();

                int qualityUpdated = qualityBefore - 1;
                Assert.Equal(sellInBefore - 1, itemToEvaluate.SellIn);
                Assert.Equal(AdjustQualityMinToTheLimit(qualityUpdated, qualityMin), itemToEvaluate.Quality);
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
            int qualityMax = 50;

            foreach (var itemToEvaluate in itemExecution.Items.Where(x => x is BackstagePasses))
            {
                int sellInBefore = itemToEvaluate.SellIn;
                int qualityBefore = itemToEvaluate.Quality;

                itemToEvaluate.UpdateItem();

                Assert.True(CommonRuleLimits(itemToEvaluate));

                if (itemToEvaluate.SellIn == adjustRealSellIn(0))
                {
                    Assert.Equal(sellInBefore - 1, itemToEvaluate.SellIn);
                    Assert.Equal(0, itemToEvaluate.Quality);
                    return;
                }

                if (itemToEvaluate.SellIn > adjustRealSellIn(0) && itemToEvaluate.SellIn <= adjustRealSellIn(5))
                {
                    int qualityUpdated = qualityBefore + 3;
                    Assert.Equal(sellInBefore - 1, itemToEvaluate.SellIn);
                    Assert.Equal(AdjustQualityMaxToTheLimit(qualityUpdated, qualityMax), itemToEvaluate.Quality);
                    return;
                }

                if (itemToEvaluate.SellIn > adjustRealSellIn(5) && itemToEvaluate.SellIn <= adjustRealSellIn(10))
                {
                    int qualityUpdated = qualityBefore + 2;
                    Assert.Equal(sellInBefore - 1, itemToEvaluate.SellIn);
                    Assert.Equal(AdjustQualityMaxToTheLimit(qualityUpdated, qualityMax), itemToEvaluate.Quality);
                    return;
                }

                if (itemToEvaluate.SellIn > adjustRealSellIn(10))
                {
                    int qualityUpdated = qualityBefore + 1;
                    Assert.Equal(sellInBefore - 1, itemToEvaluate.SellIn);
                    Assert.Equal(AdjustQualityMaxToTheLimit(qualityUpdated, qualityMax), itemToEvaluate.Quality);
                    return;
                }
            }
        }

        [Fact]
        public void TestConjured()
        {
            var items = InitializeItems();
            var itemExecution = new ItemExecution(items);
            int qualityMin = 0;

            foreach (var itemToEvaluate in itemExecution.Items.Where(x => x is Conjured))
            {
                var sellInBefore = itemToEvaluate.SellIn;
                var qualityBefore = itemToEvaluate.Quality;

                itemToEvaluate.UpdateItem();

                int qualityUpdated = qualityBefore - 2;
                Assert.Equal(sellInBefore - 1, itemToEvaluate.SellIn);
                Assert.Equal(AdjustQualityMinToTheLimit(qualityUpdated, qualityMin), itemToEvaluate.Quality);
                Assert.True(CommonRuleLimits(itemToEvaluate));
            }
        }
    }
}
