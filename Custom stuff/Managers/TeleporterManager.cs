namespace Slutprojekt;
public class TeleporterManager
{
    private List<Teleporter> teleporters = new();
    private BallManager ballManager;

    public TeleporterManager(BallManager ballManager)
    {
        this.ballManager = ballManager;
    }

    public void AddTeleporterPair(Vector2 pos1, Vector2 pos2)
    {
        teleporters.Add(new Teleporter(pos1, pos2));
    }

    public void Update()
    {
        foreach (var teleporter in teleporters)
        {
            foreach (var ball in ballManager.balls)
            {
                teleporter.TeleportBall(ball);
            }
        }
    }

    public void Draw()
    {
        foreach (var teleporter in teleporters)
        {
            teleporter.Draw();
        }
    }
}
