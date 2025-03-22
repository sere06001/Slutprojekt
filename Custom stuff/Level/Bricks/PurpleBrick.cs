
namespace Slutprojekt;
public class PurpleBrick : BaseBrick
{
    public PurpleBrick(BallManager ballmng) : base(ballmng)
    {
        ScoreOnHit = 1000;
        ScoreMultiplier = 2;
        ScoreMultiplierDuration = 3;

        ballManager = ballmng;

        TextureCurrent = Globals.BrickPurple;
        TextureHit = Globals.BrickPurpleHit;
        TextureNotHit = Globals.BrickPurple;
    }
}