namespace Slutprojekt;
public class Player
{
    public BaseCharacter Character { get; set; }
    public BallManager ballManager { get; set; }
    public int Score { get; private set; }
    public int ScoreMultiplier { get; private set; } = 1;
    public Player(BallManager bllmng)
    {
        ballManager = bllmng;
    }
    public void AddScore(int score)
    {
        Score += score;
    }
    public void ResetScoreMultiplier()
    {
        ScoreMultiplier = 1;
    }
    public void IncreaseScoreMultiplier(int scoreMult)
    {
        ScoreMultiplier *= scoreMult;
    }
    public virtual void Update()
    {
        Character.Update();
    }
}