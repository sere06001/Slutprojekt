namespace Slutprojekt;
public class GreenCircle : BaseCircle
{
    public GreenCircle(BallManager ballmng, Player player) : base(ballmng, player)
    {
        ScoreOnHit = 10;

        ballManager = ballmng;

        TextureCurrent = Globals.BallGreen;
        TextureHit = Globals.BallGreenHit;
        TextureNotHit = Globals.BallGreen;
    }
    protected override void CheckCollisions()
    {
        foreach (Ball ball in ballManager.balls) 
        {
            if ((ball.Position - (Position + Origin)).Length() < (ball.Origin.X + Radius))
            {
                ResolveBallCollision(ball);
                if (!Hit)
                {
                    player.Powerup.PowerupAbility(ball.Position); //DuplicateBallPowerup is crashing game because it is modifying ballManager.balls while iterating over it
                    Hit = true;
                    ball.HasHit(player);
                    player.AddCircleAndBricksHitCount();
                    player.AddScore(ScoreOnHit * player.ScoreMultiplier);
                    secondsBeforeRemovalTimer = secondsBeforeRemoval;
                }
            }
        }
    }
    public override void Update()
    {
        base.Update();
    }
}