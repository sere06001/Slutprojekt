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
        List<Ball> ballPosList = new List<Ball>();
        foreach (Ball ball in ballManager.balls) 
        {
            if ((ball.Position - (Position + Origin)).Length() < (ball.Origin.X + Radius))
            {
                ResolveBallCollision(ball);
                if (!Hit)
                {
                    ballPosList.Add(ball);
                    if (player.Powerup is RespawnBallPowerup)
                    {
                        ball.SetRespawn(true);
                    }
                    Hit = true;
                    ball.IncreaseHitCount(player);
                    player.AddCircleAndBricksHitCount();
                    player.AddScore(ScoreOnHit * player.ScoreMultiplier);
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
}