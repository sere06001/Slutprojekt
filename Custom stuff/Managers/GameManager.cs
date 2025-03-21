namespace Slutprojekt;
public class GameManager
{
    public BallManager ballManager = new();

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