using GildedRose.Console.Logic.Abstractions;

namespace GildedRose.Console.Logic
{
    public class Sulfuras : Item
    {
        private const int UNIQUE_QUALITY_ALLOWED = 80;
        private const int UNIQUE_SELL_IN_ALLOWED = 0;

        public Sulfuras(int sellIn, int quality) : base("Sulfuras, Hand of Ragnaros", sellIn, quality)
        {
            if (!IsSellInAllowed()) throw new Exception("The SellIn property exceeds the allowed limit");
            if (!IsQualityAllowed()) throw new Exception("The Quality property exceeds the allowed limit");
        }

        private bool IsQualityAllowed()
        {
            return Quality == UNIQUE_QUALITY_ALLOWED;
        }

        private bool IsSellInAllowed()
        {
            return SellIn == UNIQUE_SELL_IN_ALLOWED;
        }

        public override void UpdateItem()
        {
            SellIn = SellIn;
            Quality = Quality;
        }
    }
}
