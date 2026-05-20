using Bejeweled.Core;

namespace Bejeweled.Core;

public class ScoreManager
{
    private int score;

    public ScoreManager() { score = 0; }

    public void addScore(List<Gem> matches) => score += calculatePoints(matches.Count);

    public int getScore() => score;

    public void resetScore() => score = 0;

    public int calculatePoints(int matchSize) => matchSize * 10;
}
