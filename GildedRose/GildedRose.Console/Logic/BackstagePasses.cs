using GildedRose.Console.Logic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Logic
{
    public class BackstagePasses : Item
    {
        private const int QUALITY_MAX = 50;
        private const int QUALITY_MIN = 0;

        public BackstagePasses(int sellIn, int quality) : base("Backstage passes to a TAFKAL80ETC concert", sellIn, quality)
        {
            if (!IsQualityBetweenLimits()) throw new Exception("The Quality property exceeds the allowed limit");
        }

        private bool IsQualityBetweenLimits()
        {
            return Quality >= QUALITY_MIN && Quality <= QUALITY_MAX;
        }

        public override void UpdateItem()
        {
            if (SellIn <= 0)
            {
                SellIn -= 1;
                Quality = 0;
                return;
            }

            if (SellIn > 0 && SellIn <= 5)
            {
                SellIn -= 1;
                Quality += 3;
                Quality = AdjustQualityToTheLimit();
                return;
            }

            if (SellIn > 5 && SellIn <= 10)
            {
                SellIn -= 1;
                Quality += 2;
                Quality = AdjustQualityToTheLimit();
                return;
            }

            if (SellIn > 10)
            {
                SellIn -= 1;
                Quality += 1;
                Quality = AdjustQualityToTheLimit();
                return;
            }
        }

        private int AdjustQualityToTheLimit()
        {
            return Quality > QUALITY_MAX ? QUALITY_MAX : Quality;
        }
    }
}
