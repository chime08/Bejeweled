using Bejeweled.Core;
using BoardType = Board.Core.Board;

namespace Bejeweled.Core;

public class SwapValidator
{
    private readonly BoardType board;

    public SwapValidator(BoardType board)
    {
        this.board = board;
    }

    public bool isAdjacent(int r1, int c1, int r2, int c2)
    {
        int rowDiff = Math.Abs(r1 - r2);
        int colDiff = Math.Abs(c1 - c2);
        return (rowDiff == 1 && colDiff == 0) || (rowDiff == 0 && colDiff == 1);
    }

    // Returns the gem type at (r, c), treating (r1,c1) and (r2,c2) as swapped
    private GemType TypeAt(int r, int c, int r1, int c1, int r2, int c2)
    {
        if (r == r1 && c == c1) return board.getGem(r2, c2).getType();
        if (r == r2 && c == c2) return board.getGem(r1, c1).getType();
        return board.getGem(r, c).getType();
    }

    // Checks if there'e a match 
    private bool HasMatchAt(int row, int col, int r1, int c1, int r2, int c2)
    {
        GemType t = TypeAt(row, col, r1, c1, r2, c2);

        // Horizontal count
        int count = 1;
        for (int c = col - 1; c >= 0 && TypeAt(row, c, r1, c1, r2, c2) == t; c--) count++;
        for (int c = col + 1; c < board.Cols && TypeAt(row, c, r1, c1, r2, c2) == t; c++) count++;
        if (count >= 3) return true;

        // Vertical count
        count = 1;
        for (int r = row - 1; r >= 0 && TypeAt(r, col, r1, c1, r2, c2) == t; r--) count++;
        for (int r = row + 1; r < board.Rows && TypeAt(r, col, r1, c1, r2, c2) == t; r++) count++;
        return count >= 3;
    }

    public bool isValidSwap(int r1, int c1, int r2, int c2)
    {
        if (!isAdjacent(r1, c1, r2, c2)) return false;
        return HasMatchAt(r1, c1, r1, c1, r2, c2) || HasMatchAt(r2, c2, r1, c1, r2, c2);
    }

    public List<Gem> findMatches()
    {
        HashSet<(int, int)> matched = new();

        // check if there are any horizontal matches 
        for (int r = 0; r < board.Rows; r++)
        {
            int c = 0;
            while (c < board.Cols)
            {
                GemType t = board.getGem(r, c).getType();
                int len = 1;
                while (c + len < board.Cols && board.getGem(r, c + len).getType() == t) len++;
                if (len >= 3)
                    for (int k = 0; k < len; k++) matched.Add((r, c + k));
                c += len;
            }
        }

        // check if there are any vertical matches 
        for (int c = 0; c < board.Cols; c++)
        {
            int r = 0;
            while (r < board.Rows)
            {
                GemType t = board.getGem(r, c).getType();
                int len = 1;
                while (r + len < board.Rows && board.getGem(r + len, c).getType() == t) len++;
                if (len >= 3)
                    for (int k = 0; k < len; k++) matched.Add((r + k, c));
                r += len;
            }
        }

        List<Gem> result = new();
        foreach (var (r, c) in matched)
            result.Add(board.getGem(r, c));
        return result;
    }

    public bool hasAnyMatch()
    {
        return findMatches().Count > 0;
    }

    public bool hasAnyValidMove()
    {
        for (int r = 0; r < board.Rows; r++)
            for (int c = 0; c < board.Cols; c++)
            {
                if (c + 1 < board.Cols && isValidSwap(r, c, r, c + 1)) return true;
                if (r + 1 < board.Rows && isValidSwap(r, c, r + 1, c)) return true;
            }
        return false;
    }
}
