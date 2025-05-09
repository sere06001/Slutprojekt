namespace Slutprojekt;
public abstract class LevelBase
{
    public Player player;
    public CirclePlacer circlePlacer;
    public BrickPlacer brickPlacer;
    protected BallManager ballManager;
    protected virtual Vector2 Position { get; set; }
    public virtual bool UseBricks { get; set; }
    public virtual bool ShouldMove { get; set; }

    protected LevelBase(BallManager ballManager, Player plyr, float centerX, float centerY, bool useBricks, bool move)
    {
        this.ballManager = ballManager;
        player = plyr;
        UseBricks = useBricks;
        ShouldMove = move;
        Position = new Vector2(centerX, centerY);
        circlePlacer = new CirclePlacer(ballManager, player);
        brickPlacer = new BrickPlacer(ballManager, player);
    }
    public virtual void UseBrickOrCircle(float x, float y, bool usebricks)
    {
        if (usebricks)
        {
            brickPlacer.PlaceBrick(new Vector2(x, y));
        }
        else
        {
            circlePlacer.PlaceCircle(new Vector2(x, y));
        }
    }

    public virtual void Update()
    {
        circlePlacer.Update();
        brickPlacer.Update();
    }

    public void Draw()
    {
        circlePlacer.Draw();
        brickPlacer.Draw();
    }
}