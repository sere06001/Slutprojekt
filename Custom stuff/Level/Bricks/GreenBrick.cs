namespace Slutprojekt;
public class GreenBrick : BaseBrick
{
    public GreenBrick(BallManager ballmng, Player player, float rotation) : base(ballmng, player, rotation)
    {
        ScoreOnHit = 10;

        ballManager = ballmng;

        TextureCurrent = Globals.BrickGreen;
        TextureHit = Globals.BrickGreenHit;
        TextureNotHit = Globals.BrickGreen;
    }
    protected override void CheckCollisions()
    {
        foreach (Ball ball in ballManager.balls)
        {
            if (CheckBallCollision(ball))
            {
                ResolveBallCollision(ball);
                if (!Hit)
                {
                    player.Powerup.PowerupAbility(ball.Position);
                    ball.HasHit(player);
                    player.AddCircleAndBricksHitCount();
                    player.AddScore(ScoreOnHit * player.ScoreMultiplier);
                    Hit = true;
                    secondsBeforeRemovalTimer = secondsBeforeRemoval;
                    showScore = true;
                    scoreDisplayTimer = ScoreDisplayDurationSeconds;
                }
            }
        }
    }
    public override void Update()
    {
        base.Update();
    }
}