namespace Slutprojekt;
public class GameManager
{
    private BallManager ballManager = new();

    public GameManager()
    {

    }


    public void Update()
    {
        ballManager.Update();
    }

    public void Draw()
    {
        ballManager.Draw();
    }
}