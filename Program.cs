// See https://aka.ms/new-console-template for more information
using Bejeweled.Core;
using System;
using System.Text;

namespace Bejeweled.Core;

class Program
{
    static void Main(string[] args)
    {
        Gem gem1 = new Gem(GemType.Red);
        Gem gem2 = new Gem(GemType.Blue);
        Gem gem3 = new Gem(GemType.Red);
        Gem gem4 = new Gem(GemType.Green);
        Gem gem5 = new Gem(GemType.Yellow);
        Gem gem6 = new Gem(GemType.Purple);

        Console.WriteLine("\n-----------------------------\n");
        Console.WriteLine("Welcome to the Bejewelwd Game");
        Console.WriteLine("\n-----------------------------\n");
        Console.WriteLine("List of Gems\n");

        Console.WriteLine(gem1);
        Console.WriteLine(gem2);
        Console.WriteLine(gem3);
        Console.WriteLine(gem4);
        Console.WriteLine(gem5);
        Console.WriteLine(gem6);
    }
}