namespace Slutprojekt;
public class Cannon
{
    public Vector2 Position { get; private set; }
    public float Rotation { get; private set; }
    public float MaxRotation = MathHelper.ToRadians(80f); // Half of 160 degrees
    private readonly BallManager ballManager;
    private readonly Texture2D texture;
    
    public Cannon(BallManager ballManager)
    {
        this.ballManager = ballManager;
        texture = Globals.BallTexture; // You might want to create a separate cannon texture
        Position = new Vector2(Globals.Bounds.X / 2, 50);
    }

    public void Update()
    {
        Vector2 mousePosition = new(Mouse.GetState().X, Mouse.GetState().Y);
        Vector2 direction = mousePosition - Position;
        float targetRotation = (float)Math.Atan2(direction.Y, direction.X);
        
        // Adjust rotation to be relative to pointing downward (π/2)
        float adjustedRotation = targetRotation - MathHelper.PiOver2;
        Rotation = MathHelper.Clamp(adjustedRotation, -MaxRotation, MaxRotation) + MathHelper.PiOver2;

        if (Mouse.GetState().LeftButton == ButtonState.Pressed && ballManager.BallsLeft > 0)
        {
            ShootBall();
        }
    }

    private void ShootBall()
    {
        Vector2 direction = new((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
        ballManager.ShootBall(Position, direction);
    }

    public void Draw()
    {
        Rectangle sourceRect = new(0, 0, texture.Width, texture.Height);
        Globals.SpriteBatch.Draw(texture, Position, sourceRect, Color.Yellow, 
            Rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1.5f, 
            SpriteEffects.None, 0);
    }
}
