
namespace Slutprojekt;
public class GreenBrick : BaseBrick
{
    protected override Vector2 Position { get; set; } = new(0,0);
    public GreenBrick(BallManager ballmng) : base(ballmng)
    {
        ballManager = ballmng;

        TextureCurrent = Globals.BallGreen;
        TextureHit = Globals.BallGreenHit;
        TextureNotHit = Globals.BallGreen;
    }
    public override void Draw()
    {
        Globals.SpriteBatch.Draw(TextureCurrent, Position, Color.White);
    }
}