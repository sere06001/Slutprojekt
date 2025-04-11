namespace Slutprojekt;
public class GameManager
{
    public BallManager ballManager = new();
    public Player player;
    public BaseCharacter character;
    public UI UI;
    public LevelGenerator levelGenerator;
    public LevelCombiner levelCombiner;
    private Cannon cannon;

    public GameManager()
    {
        player = new(ballManager);
        levelCombiner = new(ballManager, player);
        levelGenerator = new(ballManager, player, levelCombiner);
        //character = new BreakRedsCharacter(ballManager, levelCombiner);
        character = new ExplodeCharacter(ballManager, levelCombiner);
        //character = new DuplicateBallCharacter(ballManager);
        //character = new RespawnBallCharacter(ballManager);
        //character = new FireballCharacter(ballManager);
        player.SetCharacter(character);
        
        cannon = new Cannon(ballManager, levelCombiner);
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
        cannon.Update();
    }

    public void Draw()
    {
        levelGenerator.Draw();
        cannon.Draw();
        
        
        Globals.SpriteBatch.Draw(Globals.Pixel, new Rectangle(0, 0, Globals.LeftWall, Globals.Bounds.Y), Color.Blue);
        Globals.SpriteBatch.Draw(Globals.Pixel, new Rectangle(Globals.RightWall, 0, Globals.Bounds.X-Globals.RightWall, Globals.Bounds.Y), Color.Pink);
        ballManager.Draw();
        UI.Draw();
    }
}