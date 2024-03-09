using GildedRose.Console.Logic.Abstractions;

namespace GildedRose.Console.Logic
{
    public class ElixirOfTheMongoose : Item
    {
        private const int QUALITY_MAX = 50;
        private const int QUALITY_MIN = 0;

        public ElixirOfTheMongoose(int sellIn, int quality) : base("Elixir of the Mongoose", sellIn, quality)
        {
            if (!IsQualityBetweenLimits()) throw new Exception("The Quality property exceeds the allowed limit");
        }

        private bool IsQualityBetweenLimits()
        {
            return Quality >= QUALITY_MIN && Quality <= QUALITY_MAX;
        }

        public override void UpdateItem()
        {
            SellIn -= 1;
            Quality -= 1;

            Quality = Quality < QUALITY_MIN ? QUALITY_MIN : Quality;
        }
    }
}
