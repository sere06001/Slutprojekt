namespace Slutprojekt;
public class RedCircle : BaseCircle
{
    protected bool hasAddedRed = false;
    public RedCircle(BallManager ballmng, Player player) : base(ballmng, player)
    {
        ScoreOnHit = 100;

        ballManager = ballmng;

        TextureCurrent = Globals.BallRed;
        TextureHit = Globals.BallRedHit;
        TextureNotHit = Globals.BallRed;
    }
    public override void Update()
    {
        base.Update();
        if (Hit)
        {
            if (!hasAddedRed)
            {
                player.AddRedsHit();
                hasAddedRed = true;
            }
        }
    }
}