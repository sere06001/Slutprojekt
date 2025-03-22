
namespace Slutprojekt;
public class RedBrick : BaseBrick
{
    public RedBrick(BallManager ballmng) : base(ballmng)
    {
        ScoreOnHit = 100;

        ballManager = ballmng;

        TextureCurrent = Globals.BrickRed;
        TextureHit = Globals.BrickRedHit;
        TextureNotHit = Globals.BrickRed;
    }
}