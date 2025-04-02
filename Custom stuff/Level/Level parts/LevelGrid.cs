namespace Slutprojekt;
public class LevelGrid : LevelBase
{
    protected override Vector2 Position { get; set; }
    private int rows;
    private int columns;
    private float spacing;
    private float rotation; //Rotation of the entire grid (stored in radians)
    private float rotationBricks; //Rotation of the bricks (stored in radians)

    public LevelGrid(BallManager ballManager, Player plyr, int rows, int columns, float spacing, float centerX, float centerY, bool useBricks, float rotationDegrees = 0f, float rotationBricksDegrees = 0)
        : base(ballManager, plyr, useBricks)
    {
        this.rows = rows;
        this.columns = columns;
        this.spacing = spacing;

        player = plyr;

        rotation = rotationDegrees * (MathF.PI / 180f);
        rotationBricks = rotationBricksDegrees * (MathF.PI/180f);

        Position = new Vector2(centerX, centerY);

        CreateGridPattern(useBricks);
    }

    private void CreateGridPattern(bool usebricks)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float x = Position.X - (columns - 1) * spacing / 2 + col * spacing;
                float y = Position.Y - (rows - 1) * spacing / 2 + row * spacing;

                Vector2 rotatedPosition = RotatePoint(new Vector2(x, y), Position, rotation);

                UseBrickOrCircle(rotatedPosition.X, rotatedPosition.Y, usebricks);
            }
        }
    }
    public override void UseBrickOrCircle(float x, float y, bool usebricks)
    {
        if (usebricks)
        {
            brickPlacer.PlaceBrick(new Vector2(x, y), rotationBricks);
        }
        else
        {
            circlePlacer.PlaceCircle(new Vector2(x, y));
        }
    }

    private Vector2 RotatePoint(Vector2 point, Vector2 origin, float angle)
    {
        float translatedX = point.X - origin.X;
        float translatedY = point.Y - origin.Y;

        float rotatedX = translatedX * MathF.Cos(angle) - translatedY * MathF.Sin(angle);
        float rotatedY = translatedX * MathF.Sin(angle) + translatedY * MathF.Cos(angle);

        return new Vector2(rotatedX + origin.X, rotatedY + origin.Y);
    }
}