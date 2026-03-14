// See https://aka.ms/new-console-template for more information
using Bejeweled.Core;
using System;
using System.Text;

namespace Bejeweled.Core;
using Board.Core;

// public class Program
// {
//     //driver test for Gem class 
//     static void Main(string[] args)
//     {
//         Gem gem1 = new Gem(GemType.Red);
//         Gem gem2 = new Gem(GemType.Blue);
//         Gem gem3 = new Gem(GemType.Red);
//         Gem gem4 = new Gem(GemType.Green);
//         Gem gem5 = new Gem(GemType.Yellow);
//         Gem gem6 = new Gem(GemType.Purple);

//         Console.WriteLine("\n-----------------------------");
//         Console.WriteLine("Welcome to the Bejewelwd Game");
//         Console.WriteLine("-----------------------------\n");
//         Console.WriteLine("List of Gems\n");

//         Console.WriteLine(gem1);
//         Console.WriteLine(gem2);
//         Console.WriteLine(gem3);
//         Console.WriteLine(gem4);
//         Console.WriteLine(gem5);
//         Console.WriteLine(gem6);
//     }
// }

//Driver Test for Board class 
public class Program1
{    
    static void Main(string[] args)
    {
        Board board = new Board(8, 8);
        Console.WriteLine("\nInitialize Board:\n");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(board.getGem(i, j) + " ");
            }
            Console.WriteLine();
        }
    }
}