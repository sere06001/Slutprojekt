namespace Slutprojekt;
public class GameManager
{
    public BallManager ballManager = new();
    public Player player;
    public BaseCharacter character;
    public UI UI;
    public LevelGenerator levelGenerator;
    public LevelCombiner levelCombiner;
    private Cannon cannon;  // Add cannon field

    public GameManager()
    {
        character = new DuplicateBallCharacter(ballManager);
        //character = new RespawnBallCharacter(ballManager);
        //character = new FireballCharacter(ballManager);
        player = new(ballManager, character);
        levelCombiner = new(ballManager, player);
        levelGenerator = new(ballManager, player, levelCombiner);
        cannon = new Cannon(ballManager);  // Initialize cannon
        UI = new();
    }
    public void Init()
    {
        UI.Init(player);
        levelGenerator.Init();
    }

    public void Update()
    {
        player.Update();
        ballManager.Update(player);
        levelGenerator.Update();
        cannon.Update();  // Update cannon
    }

    public void Draw()
    {
        ballManager.Draw();
        UI.Draw();
        levelGenerator.Draw();
        cannon.Draw();  // Draw cannon
    }
}