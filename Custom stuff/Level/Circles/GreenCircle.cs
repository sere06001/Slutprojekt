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
            if ((ball.Position - (Position + Origin)).Length() < (ball.Origin.X + Radius))
            {
                ball.HasHit();
                if (!Hit)
                {
                    if (player.Character is RandomPowerupCharacter)
                    {
                        player.Powerup = player.Character.SetRandomPowerup(ball);
                    }
                    SetHit();
                    ballPosList.Add(ball);
                    PowerupHandler(ball);
                    ball.IncreaseHitCount(player);
                }

                if (ball.IsOnFire)
                {
                    IsMarkedForRemoval = true;
                }
                else
                {
                    ResolveBallCollision(ball);
                }
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