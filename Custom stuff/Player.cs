namespace Slutprojekt;
public class Player
{
    public BaseCharacter Character { get; set; }
    public BallManager ballManager { get; set; }
    public Player(BallManager bllmng)
    {
        ballManager = bllmng;
    }
    public virtual void Update()
    {
        Character.Update();
    }
}