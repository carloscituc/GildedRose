using GildedRose.Console.Logic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Logic
{
    public class AgedBrie : Item
    {
        private const int QUALITY_MAX = 50;
        private const int QUALITY_MIN = 0;

        public AgedBrie(int sellIn, int quality) : base("Aged Brie", sellIn, quality)
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
            Quality += 1;

            Quality = Quality > QUALITY_MAX ? QUALITY_MAX : Quality;
        }
    }
}
