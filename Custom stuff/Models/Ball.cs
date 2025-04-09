using System.Configuration.Assemblies;

namespace Slutprojekt;
public class Ball
{
    public Texture2D texture = Globals.BallTexture;
    public bool HasHitBrickOrCircle { get; private set; } = false;
    public bool WillRespawn { get; private set; } = false;
    public Vector2 Origin { get; private set; }
    public Vector2 Position { get; set; }
    public Vector2 Direction { get; set; }
    public Vector2 Velocity { get; set; }
    private int Speed { get; set; } = 200; //Initial speed in pixels per second, change this when cannon is added
    public Color Color { get; set; } = Color.White;
    private float gravity = 9.82f * 100; //Scaled up for pixels
    public float Restitution = 0.85f; //Energy loss on bounce
    public bool IsDuplicate { get; private set; } = false;

    public Ball(Vector2? position = null, bool isDuplicate = false)
    {
        Origin = new(texture.Width / 2, texture.Height / 2);
        Position = position ?? StartPosition();
        Direction = RandomDirection();
        Velocity = Direction * Speed;
        IsDuplicate = isDuplicate;
    }
    public void SetRespawn(bool willRespawn)
    {
        WillRespawn = willRespawn;
    }
    public void IncreaseHitCount(Player player)
    {
        player.AddCircleAndBricksHitCount();
    }
    public void HasHit()
    {
        HasHitBrickOrCircle = true;
    }
    private Vector2 StartPosition()
    {
        var x = Globals.Random.Next(Globals.Bounds.X); //Bounds.X/2;
        var y = texture.Height / 2;
        return new(x, y);
    }

    private Vector2 RandomDirection() //Make it follow mouse instead
    {
        var angle = Globals.Random.NextDouble() * 2 * Math.PI;
        return new((float)Math.Sin(angle), -(float)Math.Cos(angle));
    }
    private void HandleCollision()
    {
        if (Position.X < Origin.X || Position.X > Globals.Bounds.X - Origin.X)
        {
            Velocity = new(-Velocity.X * Restitution, Velocity.Y);
            Position = new(
                MathHelper.Clamp(Position.X, Origin.X, Globals.Bounds.X - Origin.X),
                Position.Y
            );
        }

        if (Position.Y < Origin.Y || Position.Y > Globals.Bounds.Y - Origin.Y)
        {
            Velocity = new(Velocity.X * Restitution, -Velocity.Y * Restitution);
            Position = new(
                Position.X,
                MathHelper.Clamp(Position.Y, Origin.Y, Globals.Bounds.Y - Origin.Y)
            );
        }
    }
    private void UpdatePosition()
    {
        Velocity += new Vector2(0, gravity) * Globals.TotalSeconds;
        Position += Velocity * Globals.TotalSeconds;

        HandleCollision();
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