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
    private void PowerupHandler(Ball ball)
    {
        if (player.Powerup is not DuplicateBallPowerup)
        {
            player.Powerup.PowerupAbility(ball);
        }
    }
    protected override void CheckCollisions()
    {
        List<Ball> ballPosList = new List<Ball>();
        foreach (Ball ball in ballManager.balls)
        {
            if (CheckBallCollision(ball))
            {
                ResolveBallCollision(ball);
                if (!Hit)
                {
                    ballPosList.Add(ball);
                    PowerupHandler(ball);
                    ball.IncreaseHitCount(player);
                    player.AddCircleAndBricksHitCount();
                    player.AddScore(ScoreOnHit * player.ScoreMultiplier);
                    Hit = true;
                    secondsBeforeRemovalTimer = secondsBeforeRemoval;
                    showScore = true;
                    scoreDisplayTimer = ScoreDisplayDurationSeconds;
                }
                ball.HasHit();
            }
        }
        if (player.Powerup is DuplicateBallPowerup)
        {
            foreach (Ball ball in ballPosList)
            {
                player.Powerup.PowerupAbility(ball);
            }
        }
    }
    public override void Update()
    {
        base.Update();
    }
}