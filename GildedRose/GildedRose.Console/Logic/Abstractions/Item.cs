namespace GildedRose.Console.Logic.Abstractions
{
    public abstract class Item
    {
        public string Name { get; private set; }
        public int SellIn { get; protected set; }
        public int Quality { get; protected set; }

        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public abstract void UpdateItem();
    }
}
