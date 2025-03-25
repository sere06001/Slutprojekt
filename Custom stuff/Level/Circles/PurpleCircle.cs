namespace Slutprojekt;
public class PurpleCircle : BaseCircle
{
    public PurpleCircle(BallManager ballmng) : base(ballmng)
    {
        ScoreOnHit = 1000;
        ScoreMultiplier = 2;

        ballManager = ballmng;

        TextureCurrent = Globals.BallPurple;
        TextureHit = Globals.BallPurpleHit;
        TextureNotHit = Globals.BallPurple;
    }
}