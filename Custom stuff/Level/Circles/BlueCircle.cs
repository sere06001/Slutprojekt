using SharpDX.MediaFoundation;

namespace Slutprojekt;
public class BlueCircle : BaseCircle
{
    public BlueCircle(BallManager ballmng, Player player) : base(ballmng, player)
    {
        ScoreOnHit = 10;
        
        ballManager = ballmng;

        TextureCurrent = Globals.BallBlue;
        TextureHit = Globals.BallBlueHit;
        TextureNotHit = Globals.BallBlue;
    }
}