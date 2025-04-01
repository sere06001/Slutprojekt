namespace Slutprojekt;
public abstract class LevelBase
{
    public Player player;
    public  CirclePlacer circlePlacer; //protected
    public  BrickPlacer brickPlacer; //protected
    protected  BallManager ballManager;
    protected virtual Vector2 Position { get; set; }

    protected LevelBase(BallManager ballManager, Player plyr)
    {
        this.ballManager = ballManager;
        player = plyr;
        circlePlacer = new CirclePlacer(ballManager, player);
        brickPlacer = new BrickPlacer(ballManager, player);
    }
    public virtual void UseBrickOrCircle(float x, float y, bool usebricks)
    {
        if (usebricks)
        {
            brickPlacer.PlaceBrick(new Vector2(x, y), 0);
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