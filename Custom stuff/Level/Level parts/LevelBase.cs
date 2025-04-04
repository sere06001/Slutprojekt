namespace Slutprojekt;
public abstract class LevelBase
{
    public Player player;
    protected CirclePlacer circlePlacer;
    protected BrickPlacer brickPlacer;
    protected BallManager ballManager;
    protected virtual Vector2 Position { get; set; }
    public virtual bool UseBricks { get; set; }

    protected LevelBase(BallManager ballManager, Player plyr, bool useBricks)
    {
        this.ballManager = ballManager;
        player = plyr;
        UseBricks = useBricks;
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