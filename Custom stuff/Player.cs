namespace Slutprojekt;
public class Player
{
    public BaseCharacter Character { get; set; }
    public BallManager ballManager { get; set; }
    public int CircleAndBricksHitCount { get; private set; } = 0;
    public int Score { get; private set; }
    public int FinalScore { get; private set; }
    public int ScoreMultiplier { get; private set; } = 1;
    public bool HasIncreasedMultFromPurple { get; private set; } = false;
    public Player(BallManager bllmng)
    {
        ballManager = bllmng;
    }
    public void AddCircleAndBricksHitCount()
    {
        CircleAndBricksHitCount++;
    }
    public void ResetCircleAndBricksHitCount()
    {
        CircleAndBricksHitCount = 0;
    }
    public void UpdateFinalScore()
    {
        FinalScore += Score * CircleAndBricksHitCount / 2;
    }
    public void AddScore(int score)
    {
        Score += score;
    }
    public void ResetScore()
    {
        Score = 0;
    }
    public void MultFromPurpleCheck()
    {
        HasIncreasedMultFromPurple = true;
    }
    public void ResetScoreMultiplier()
    {
        ScoreMultiplier = 1;
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