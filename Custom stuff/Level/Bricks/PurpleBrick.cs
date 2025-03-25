
namespace Slutprojekt;
public class PurpleBrick : BaseBrick
{
    public PurpleBrick(BallManager ballmng, float rotation) : base(ballmng, rotation)
    {
        ScoreOnHit = 1000;
        ScoreMultiplier = 2;

        ballManager = ballmng;

        TextureCurrent = Globals.BrickPurple;
        TextureHit = Globals.BrickPurpleHit;
        TextureNotHit = Globals.BrickPurple;
    }
}