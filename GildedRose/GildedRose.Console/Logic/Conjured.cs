﻿using GildedRose.Console.Logic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Logic
{
    public class Conjured : Item
    {
        private const int QUALITY_MAX = 50;
        private const int QUALITY_MIN = 0;

        public Conjured(int sellIn, int quality) : base("Conjured Mana Cake", sellIn, quality)
        {
            if (!IsQualityBetweenLimits()) throw new Exception("The Quality property exceeds the allowed limit");
        }

        private bool IsQualityBetweenLimits()
        {
            return Quality >= QUALITY_MIN && Quality <= QUALITY_MAX;
        }

        public override void UpdateItem()
        {
            int degradeByNormal = 2;
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
