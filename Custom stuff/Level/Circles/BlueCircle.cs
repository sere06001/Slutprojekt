using SharpDX.MediaFoundation;

namespace Slutprojekt;
public class BlueCircle : BaseCircle
{
    public BlueCircle(BallManager ballmng) : base(ballmng)
    {
        ScoreOnHit = 200;
        
        ballManager = ballmng;

        TextureCurrent = Globals.BallBlue;
        TextureHit = Globals.BallBlueHit;
        TextureNotHit = Globals.BallBlue;
    }
}