using System;
using Bejeweled.Core;

namespace Board.Core;

public sealed class Board
{
    private readonly Gem[,] grid;
    private readonly int rows = 8;
    private readonly int cols = 8;
    
    //Constructor 
    public Board(int r, int c)
    {
        int rows = r;
        int cols = c;
        grid = new Gem[rows, cols];

        // Initialize the grid with random gems
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        Random rand = new Random();
        GemType[] values = (GemType[])Enum.GetValues(typeof(GemType)); //looks into enum Type and generate a random value 

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GemType randomType = values[rand.Next(0, values.Length)]; //pick random gemtype 
                grid[i, j] = new Gem(randomType); // Assuming 5 types of gems
            }
        }
    }

    public Gem getGem(int r, int c)
    {
        if (r < 0 || r >= rows || c < 0 || c >= cols)
        {
            throw new ArgumentOutOfRangeException("Invalid row or column index.");
        }
        return grid[r, c];
    }
}