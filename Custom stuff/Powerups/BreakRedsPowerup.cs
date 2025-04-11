namespace Slutprojekt;
public class BreakRedsPowerup : BasePowerup
{
    public LevelCombiner levelCombiner;
    public BreakRedsPowerup(BallManager ballmanager, LevelCombiner levelCombiner) : base(ballmanager)
    {
        this.levelCombiner = levelCombiner;
    }
    public override string Description()
    {
        string description = "";
        return description;
    }
    public override void PowerupAbility(Ball ball)
    {
        Vector2 ballPos = new(ball.Position.X, ball.Position.Y);
    }
}