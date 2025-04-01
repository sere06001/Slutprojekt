namespace Slutprojekt;
public class Player
{
    public BaseCharacter Character { get; set; }
    public BallManager ballManager { get; set; }
    public int Score { get; private set; }
    public Player(BallManager bllmng)
    {
        ballManager = bllmng;
    }
    public void AddScore(int score)
    {
        Score += score;
    }
    public virtual void Update()
    {
        Character.Update();
    }
}