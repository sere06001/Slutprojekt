using System.CodeDom;

namespace Slutprojekt;
public class Ball
{
    private static readonly Random random = new();
    private Texture2D texture = Globals.Content.Load<Texture2D>("ball");
    public Vector2 Origin { get; private set;}
    public Vector2 Position { get; set; }
    public Vector2 Direction { get; set; }
    private int Speed { get; set; } = 0;
    public Color Color { get; set; } = Color.White;
    public Ball()
    {
        Origin = new(texture.Width / 2, texture.Height / 2);
        Position = StartPosition();
        Direction = RandomDirection();
    }

    private Vector2 StartPosition()
    {
        var x = Globals.Bounds.X/2;
        var y = texture.Height / 2;
        return new(x, y);
    }

    private Vector2 RandomDirection()
    {
        var angle = random.NextDouble() * 2 * Math.PI;
        return new((float)Math.Sin(angle), -(float)Math.Cos(angle));
    }
    private void UpdatePosition()
    {
        Position += Direction * Speed * Globals.TotalSeconds;

        if (Position.X < Origin.X || Position.X > Globals.Bounds.X - Origin.X) Direction = new(-Direction.X, Direction.Y);
        if (Position.Y < Origin.Y || Position.Y > Globals.Bounds.Y - Origin.Y) Direction = new(Direction.X, -Direction.Y);

        Position = new(MathHelper.Clamp(Position.X, Origin.X, Globals.Bounds.X - Origin.X),
                       MathHelper.Clamp(Position.Y, Origin.Y, Globals.Bounds.Y - Origin.Y));
    }

    public void Update()
    {
        UpdatePosition();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(texture, Position, null, Color, 0, Origin, 1, SpriteEffects.None, 1);
    }
}