using SharpDX.XAudio2;

namespace Slutprojekt;
public class LevelGenerator
{
    public Player player;
    public BallManager ballManager;
    private LevelCircle levelCircle;
    private LevelGrid levelGrid;
    public LevelGenerator(BallManager ballmngr, Player plyr)
    {
        ballManager = ballmngr;
        player = plyr;
    }
    public void Face()
    {
        levelCircle = new(ballManager, player, 100f, 10, 500, 500, false);
        levelGrid = new(ballManager, player, 1, 10, 100, 250, 250, true);
    }
    public void Init()
    {
        Face();
    }
    public void Update()
    {
        levelCircle.Update();
        levelGrid.Update();
    }
    public void Draw()
    {
        levelCircle.Draw();
        levelGrid.Draw();
    }
}