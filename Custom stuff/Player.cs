namespace Slutprojekt;
public class Player
{
    public BaseCharacter Character { get; set; }
    public BallManager ballManager { get; set; }
    public int Score { get; private set; }
    public int ScoreMultiplier { get; private set; } = 1;
    private int HitStreak { get; set; }
    private bool HasIncreasedMultHitStreak { get; set; } = false;
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
        HitStreak = 0;
        HasIncreasedMultHitStreak = false;
    }
    public void IncreaseScoreMultiplier(int scoreMult)
    {
        ScoreMultiplier *= scoreMult;
    }
    public void IncreaseHitStreak(int streak)
    {
        HitStreak += streak;
    }
    public virtual void Update()
    {
        if (HitStreak == 10 && !HasIncreasedMultHitStreak)
        {
            ScoreMultiplier *= 2;
            HasIncreasedMultHitStreak = true;
        }
        //Character.Update();
    }
}