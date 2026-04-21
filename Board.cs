using System;
using Bejeweled.Core;
namespace Board.Core;
public sealed class Board
{
    private readonly Gem[,] grid;
    public int Rows { get; }
    public int Cols { get; }

    //Constructor
    public Board(int r, int c)
    {
        Rows = r;
        Cols = c;
        grid = new Gem[Rows, Cols];

        // Initialize the grid with random gems
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        Random rand = new Random();
        GemType[] values = (GemType[])Enum.GetValues(typeof(GemType)); //looks into enum Type and generate a random value 

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                GemType randomType = values[rand.Next(0, values.Length)]; //pick random gemtype 
                grid[i, j] = new Gem(randomType); // Assuming 5 types of gems
            }
        }
    }

    public Gem getGem(int r, int c)
    {
        if (r < 0 || r >= Rows || c < 0 || c >= Cols)
        {
            throw new ArgumentOutOfRangeException("Invalid row or column index.");
        }
        return grid[r, c];
    }
}