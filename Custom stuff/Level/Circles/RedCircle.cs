namespace Slutprojekt;
public class RedCircle : BaseCircle
{
    protected override Vector2 Position { get; set; } = new(0,0);
    public RedCircle(BallManager ballmng) : base(ballmng)
    {
        ballManager = ballmng;

        TextureCurrent = BallRed;
        TextureHit = BallRedHit;
        TextureNotHit = BallRed;
    }
    public override void Draw()
    {
        Globals.SpriteBatch.Draw(TextureCurrent, Position, Color.White);
    }
}