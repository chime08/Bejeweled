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
            throw new ArgumentOutOfRangeException("Invalid row or column index.");
        return grid[r, c];
    }

    public bool isValidPosition(int row, int col) =>
        row >= 0 && row < Rows && col >= 0 && col < Cols;

    public void swapGems(int r1, int c1, int r2, int c2) =>
        (grid[r1, c1], grid[r2, c2]) = (grid[r2, c2], grid[r1, c1]);

    public void revertSwap(int r1, int c1, int r2, int c2) =>
        swapGems(r1, c1, r2, c2);

    public Gem generateGem()
    {
        GemType[] values = (GemType[])Enum.GetValues(typeof(GemType));
        return new Gem(values[Random.Shared.Next(values.Length)]);
    }

    public void removeMatchedGems(List<Gem> matches)
    {
        for (int r = 0; r < Rows; r++)
            for (int c = 0; c < Cols; c++)
                if (matches.Contains(grid[r, c]))
                    grid[r, c] = null!;
    }

    // shifts all gems down to fill empty (null) slots left by removed matches
    public void dropGems()
    {
        for (int c = 0; c < Cols; c++)
        {
            int emptyRow = Rows - 1;
            for (int r = Rows - 1; r >= 0; r--)
            {
                if (grid[r, c] != null)
                {
                    grid[emptyRow, c] = grid[r, c];
                    if (emptyRow != r) grid[r, c] = null!;
                    emptyRow--;
                }
            }
        }
    }

    // fills any remaining null slots (at the top) with new random gems
    public void refill()
    {
        for (int r = 0; r < Rows; r++)
            for (int c = 0; c < Cols; c++)
                if (grid[r, c] == null)
                    grid[r, c] = generateGem();
    }
}