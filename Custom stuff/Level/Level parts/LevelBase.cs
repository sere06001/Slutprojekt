namespace Slutprojekt;
public abstract class LevelBase
{
    protected readonly CirclePlacer circlePlacer;
    protected readonly BrickPlacer brickPlacer;
    protected readonly BallManager ballManager;
    protected virtual Vector2 Position { get; set; }

    protected LevelBase(BallManager ballManager, bool useBricks)
    {
        this.ballManager = ballManager;
        circlePlacer = new CirclePlacer(ballManager);
        brickPlacer = new BrickPlacer(ballManager);
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