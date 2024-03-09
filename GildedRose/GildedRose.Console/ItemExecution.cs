using GildedRose.Console.Logic.Abstractions;

namespace GildedRose.Console
{
    public class ItemExecution
    {
        public List<Item> Items {  get; private set; }

        public ItemExecution(List<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.UpdateItem();
            }
        }
    }
}
