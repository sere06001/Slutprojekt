namespace Slutprojekt;
public class LevelGrid : LevelBase
{
    protected override Vector2 Position { get; set; }
    private readonly int rows;
    private readonly int columns;
    private readonly float spacing;

    public LevelGrid(BallManager ballManager, int rows, int columns, float spacing, float centerX, float centerY, bool useBricks)
        : base(ballManager, useBricks)
    {
        this.rows = rows;
        this.columns = columns;
        this.spacing = spacing;

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

                UseBrickOrCircle(x, y, usebricks);
            }
        }
    }
}