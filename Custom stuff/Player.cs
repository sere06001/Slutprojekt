namespace Slutprojekt;
public class Player
{
    public BaseCharacter Character { get; set; }
    public BallManager ballManager { get; set; }
    public int Score { get; private set; }
    public int ScoreMultiplier { get; private set; } = 1;
    private bool HasIncreasedMultHitStreak { get; set; } = false;
    public bool HasIncreasedMultFromPurple { get; private set; } = false;
    public Player(BallManager bllmng)
    {
        ballManager = bllmng;
    }
    public void AddScore(int score)
    {
        Score += score;
    }
    public void MultFromPurpleCheck()
    {
        HasIncreasedMultFromPurple = true;
    }
    public void ResetScoreMultiplier()
    {
        ScoreMultiplier = 1;
        HitStreak = 0;
        HasIncreasedMultHitStreak = false;
        HasIncreasedMultFromPurple = false;
    }
    public void IncreaseScoreMultiplier(int scoreMult)
    {
        ScoreMultiplier *= scoreMult;
    }
    public virtual void Update()
    {
        //Character.Update();
    }
}