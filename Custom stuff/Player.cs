namespace Slutprojekt;
public class Player
{
    public BaseCharacter Character { get; set; }
    public BallManager ballManager { get; set; }
    public int CircleAndBricksHitCount { get; private set; } = 0;
    public int ScoreFromHits { get; private set; }
    public int ScoreLevel { get; private set; }
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
        ScoreLevel += ScoreFromHits * CircleAndBricksHitCount / 2;
    }
    public void AddScore(int score)
    {
        ScoreFromHits += score;
    }
    public void ResetScore()
    {
        ScoreFromHits = 0;
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
        if (ScoreLevel >= 20000)
        {
            ScoreMultiplier = 2;
        }
        if (ScoreLevel >= 30000)
        {
            ScoreMultiplier = 3;
        }
        if (ScoreLevel >= 50000)
        {
            ScoreMultiplier = 5;
        }
        if (ScoreLevel >= 100000)
        {
            ScoreMultiplier = 10;
        }
        //Character.Update();
    }
}