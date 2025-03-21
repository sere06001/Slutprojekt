
namespace Slutprojekt;
public class PurpleBrick : BaseBrick
{
    public PurpleBrick(BallManager ballmng) : base(ballmng)
    {
        ballManager = ballmng;

        TextureCurrent = Globals.BallPurple;
        TextureHit = Globals.BallPurpleHit;
        TextureNotHit = Globals.BallPurple;
    }
}