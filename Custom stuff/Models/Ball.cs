namespace Slutprojekt;
public class Ball
{
    public enum HorizontalDirection
    {
        Left,
        Right,
    }

    public Texture2D texture = Globals.BallTexture;
    public bool HasHitBrickOrCircle { get; private set; } = false;
    public bool WillRespawn { get; private set; } = false;
    public Vector2 Origin { get; private set; }
    public Vector2 Position { get; set; }
    public Vector2 Direction { get; set; }
    public Vector2 Velocity { get; set; }
    public HorizontalDirection CurrentDirection { get; private set; }
    public static int Speed { get; private set; } = 400;
    public Color Color { get; set; } = Color.White;
    public float Restitution = 0.8f;
    public bool IsDuplicate { get; private set; } = false;
    public bool IsOnFire { get; private set; } = false;

    public Ball(Vector2 position, bool isDuplicate = false)
    {
        Origin = new(texture.Width / 2, texture.Height / 2);
        Position = position;
        Direction = Vector2.Zero;
        Velocity = Vector2.Zero;
        IsDuplicate = isDuplicate;
        UpdateDirection();
    }

    public void SetRespawn(bool willRespawn)
    {
        WillRespawn = willRespawn;
    }
    public void SetFireStatus(bool isonfire)
    {
        IsOnFire = isonfire;
    }
    public void IncreaseHitCount(Player player)
    {
        player.AddCircleAndBricksHitCount();
    }
    public void HasHit()
    {
        HasHitBrickOrCircle = true;
    }

    private void UpdateDirection()
    {
        CurrentDirection = Velocity.X > 0 ? HorizontalDirection.Right : HorizontalDirection.Left;
    }

    private void HandleCollision()
    {
        if (Position.X < Origin.X || Position.X > Globals.Bounds.X - Origin.X
            || Position.X < Globals.LeftWall || Position.X > Globals.RightWall)
        {
            Velocity = new(-Velocity.X * Restitution, Velocity.Y);
            Position = new(
                MathHelper.Clamp(Position.X, Origin.X, Globals.Bounds.X - Origin.X),
                Position.Y
            );
            UpdateDirection();
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
        Velocity += new Vector2(0, Globals.Gravity) * Globals.TotalSeconds;
        Position += Velocity * Globals.TotalSeconds;
        UpdateDirection();
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