namespace Slutprojekt;
public class Player
{
    public BasePowerup Powerup { get; set; } //Assign powerup here so stuff can call player.Powerup likewise with character etc to minimize clutter in GameManager.cs
    public BaseCharacter Character { get; set; }
    public BallManager ballManager { get; set; }
    public Player(BallManager bllmng)
    {
        ballManager = bllmng;
    }
}