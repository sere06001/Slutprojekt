namespace Slutprojekt;
public class PurpleCircle : BaseCircle
{
    public PurpleCircle(BallManager ballmng, Player player) : base(ballmng, player)
    {
        ScoreOnHit = 500;
        //ScoreMultiplier = 2;

        ballManager = ballmng;

        TextureCurrent = Globals.BallPurple;
        TextureHit = Globals.BallPurpleHit;
        TextureNotHit = Globals.BallPurple;
    }
    public override void Update()
    {
        base.Update();
        if (Hit)
        {
            if (!player.HasIncreasedMultFromPurple)
            {
                player.IncreaseScoreMultiplier(ScoreMultiplier);
                player.MultFromPurpleCheck();
            }
        }
    }
}