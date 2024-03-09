using System.Reflection.Metadata.Ecma335;

namespace GildedRose.Console.Logic
{
    public class Plus5DexterityVest : Abstractions.Item
    {
        private const int QUALITY_MAX = 50;
        private const int QUALITY_MIN = 0;

        public Plus5DexterityVest(int sellIn, int quality) : base("+5 Dexterity Vest", sellIn, quality)
        {
            if (!IsQualityBetweenLimits()) throw new Exception("The Quality property exceeds the allowed limit");
        }

        private bool IsQualityBetweenLimits()
        {
            return Quality >= QUALITY_MIN && Quality <= QUALITY_MAX;
        }

        public override void UpdateItem()
        {
            int degradeByNormal = 1;
            int degradeByTwice = degradeByNormal * 2;

            Quality = DateHasPassed() ? 
                Quality - degradeByTwice :
                Quality - degradeByNormal;

            SellIn -= 1;

            Quality = Quality < QUALITY_MIN ? QUALITY_MIN : Quality;
        }

        private bool DateHasPassed()
        {
            return SellIn < 0;
        }
    }
}
