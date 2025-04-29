namespace Slutprojekt;
public class Player
{
    public BaseCharacter Character { get; set; }
    public BasePowerup Powerup { get; set; }
    public BallManager ballManager { get; set; }
    public int CircleAndBricksHitCount { get; private set; } = 0;
    public int ScoreFromHits { get; private set; }
    public int ScoreForBall { get; private set; }
    public int ScoreLevel { get; private set; }
    public int ScoreMultiplier { get; private set; } = 1;
    public bool HasIncreasedMultFromPurple { get; private set; } = false;
    public int RedsHit { get; private set; } = 0;
    public int currentLevel { get; set; }
    public Player(BallManager bllmng)
    {
        ballManager = bllmng;
    }
    public void SetCharacter(BaseCharacter character)
    {
        Character = character;
        Powerup = character.Powerup;
    }
    public void AddRedsHit()
    {
        RedsHit++;
    }
    public void ResetRedsHit()
    {
        RedsHit = 0;
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
        ScoreForBall = ScoreFromHits;
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
        if (ScoreForBall >= 25000)
        {
            ballManager.AddBallsLeft();
            ScoreForBall = 0;
        }
        if (RedsHit >= 10)
        {
            ScoreMultiplier = 2;
        }
        if (RedsHit >= 15)
        {
            ScoreMultiplier = 3;
        }
        if (RedsHit >= 19)
        {
            ScoreMultiplier = 5;
        }
        if (RedsHit >= 22)
        {
            ScoreMultiplier = 10;
        }
    }
}