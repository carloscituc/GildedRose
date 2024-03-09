using GildedRose.Console;
using GildedRose.Console.Logic.Abstractions;
using GildedRose.Console.Logic;

Console.WriteLine("Execution started");

ItemExecution itemExecution = new ItemExecution(new List<Item>()
{
    new Plus5DexterityVest(10, 20),
    new AgedBrie(2, 0),
    new ElixirOfTheMongoose(5, 7),
    new Sulfuras(0, 80),
    new BackstagePasses(15, 20),
    new Conjured(3, 6),
});

itemExecution.UpdateQuality();

Console.WriteLine("Execution finished");