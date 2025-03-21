namespace Slutprojekt;
public class GreenCircle : BaseCircle
{
    protected override Vector2 Position { get; set; } = new(0,0);
    public GreenCircle(BallManager ballmng) : base(ballmng)
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