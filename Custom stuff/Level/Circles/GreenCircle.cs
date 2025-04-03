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
}