namespace Slutprojekt;
public class BlueCircle : BaseCircle
{
    protected override Vector2 Position { get; set; } = new(0,0);
    public BlueCircle(BallManager ballmng) : base(ballmng)
    {
        ballManager = ballmng;

        TextureCurrent = Globals.BallBlue;
        TextureHit = Globals.BallBlueHit;
        TextureNotHit = Globals.BallBlue;
    }
    public override void Draw()
    {
        Globals.SpriteBatch.Draw(TextureCurrent, Position, Color.White);
    }
}