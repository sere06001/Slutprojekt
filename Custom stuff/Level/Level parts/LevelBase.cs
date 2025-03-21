namespace Slutprojekt;
public abstract class LevelBase
{
    protected readonly CirclePlacer circlePlacer;
    protected readonly BrickPlacer brickPlacer;
    protected readonly BallManager ballManager;
    protected virtual Vector2 Position { get; set; }

    protected LevelBase(BallManager ballManager)
    {
        this.ballManager = ballManager;
        circlePlacer = new CirclePlacer(ballManager);
        brickPlacer = new BrickPlacer(ballManager);
    }

    public virtual void Update()
    {
        circlePlacer.Update();
        brickPlacer.Update();
    }

    public abstract void Draw();
}