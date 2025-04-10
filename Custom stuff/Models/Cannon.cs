namespace Slutprojekt;
public class Cannon
{
    public Vector2 Position { get; private set; }
    public float Rotation { get; private set; }
    public float MaxRotation = 2*MathF.PI; //MathHelper.ToRadians(80f)
    private readonly BallManager ballManager;
    private readonly Texture2D texture;
    private const int PREDICTION_STEPS = 100;
    private const float TIME_STEP = 1f / 60f;
    private float spawnOffset = 75f;
    private List<Vector2> trajectoryPoints = new();
    private Vector2 spawnPosition;

    public Cannon(BallManager ballManager)
    {
        this.ballManager = ballManager;
        texture = Globals.BallTexture; //Change later
        Position = new Vector2(Globals.Bounds.X / 2, 50);
    }

    private void UpdateTrajectoryPrediction()
    {
        trajectoryPoints.Clear();
        Vector2 direction = new((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
        spawnPosition = Position + direction * spawnOffset;

        Vector2 position = spawnPosition;
        Vector2 velocity = direction * Ball.Speed;

        for (int i = 0; i < PREDICTION_STEPS; i++)
        {
            trajectoryPoints.Add(position);

            velocity += new Vector2(0, Globals.Gravity) * TIME_STEP;
            position += velocity * TIME_STEP;

            if (position.X < Globals.LeftWall || position.X > Globals.RightWall) //Changes trajectory if it touches walls
            {
                velocity.X = -velocity.X * 0.9f;
                position.X = MathHelper.Clamp(position.X, 0, Globals.Bounds.X);
            }

            if (position.Y > Globals.RestrictionCoordsLower)
                break;
        }
    }

    public void Update()
    {
        Vector2 mousePosition = new(Mouse.GetState().X, Mouse.GetState().Y);
        Vector2 direction = mousePosition - Position;
        float targetRotation = (float)Math.Atan2(direction.Y, direction.X);

        float adjustedRotation = targetRotation - MathHelper.PiOver2;
        Rotation = MathHelper.Clamp(adjustedRotation, -MaxRotation, MaxRotation) + MathHelper.PiOver2;

        if (Mouse.GetState().LeftButton == ButtonState.Pressed && ballManager.BallsLeft > 0)
        {
            ShootBall();
        }

        UpdateTrajectoryPrediction();
    }

    private void ShootBall()
    {
        Vector2 direction = new((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
        ballManager.ShootBall(spawnPosition, direction);
    }

    public void Draw()
    {
        for (int i = 1; i < trajectoryPoints.Count; i++)
        {
            Vector2 start = trajectoryPoints[i - 1];
            Vector2 end = trajectoryPoints[i];
            float distance = Vector2.Distance(start, end);
            float rotation = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);

            Rectangle destRect = new Rectangle(
                (int)start.X,
                (int)start.Y,
                (int)distance,
                2);

            Globals.SpriteBatch.Draw(
                Globals.Pixel,
                destRect,
                null,
                new Color(Color.White, 0.3f),
                rotation,
                Vector2.Zero,
                SpriteEffects.None,
                0);
        }

        Rectangle sourceRect = new(0, 0, texture.Width, texture.Height);
        Globals.SpriteBatch.Draw(texture, Position, sourceRect, Color.Yellow,
            Rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1.5f,
            SpriteEffects.None, 0);
    }
}
