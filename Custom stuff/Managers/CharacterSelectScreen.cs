namespace Slutprojekt;
public class CharacterSelectScreen
{
    private List<Rectangle> characterButtons = new();
    private List<BaseCharacter> characters;
    private readonly BallManager ballManager;
    private readonly LevelCombiner levelCombiner;
    private readonly GameStateManager gameStateManager;
    private readonly Player player;
    private MouseState previousMouseState;
    private int BUTTON_WIDTH = 150;
    private int BUTTON_HEIGHT = 40;
    private int BUTTON_SPACING = 15;
    private bool isFirstUpdate = true;

    public CharacterSelectScreen(BallManager ballManager, LevelCombiner levelCombiner, 
        GameStateManager gameStateManager, Player player)
    {
        this.ballManager = ballManager;
        this.levelCombiner = levelCombiner;
        this.gameStateManager = gameStateManager;
        this.player = player;

        characters = new List<BaseCharacter>
        {
            new ExplodeCharacter(ballManager, levelCombiner),
            new BreakRedsCharacter(ballManager, levelCombiner),
            new DuplicateBallCharacter(ballManager),
            new RespawnBallCharacter(ballManager),
            new FireballCharacter(ballManager)
        };

        InitializeButtons();
        
    }

    private void InitializeButtons()
    {
        int startY = (Globals.Bounds.Y - (characters.Count * (BUTTON_HEIGHT + BUTTON_SPACING))) / 2;
        for (int i = 0; i < characters.Count; i++)
        {
            characterButtons.Add(new Rectangle(
                (Globals.Bounds.X - BUTTON_WIDTH) / 2,
                startY + (BUTTON_HEIGHT + BUTTON_SPACING) * i,
                BUTTON_WIDTH,
                BUTTON_HEIGHT
            ));
        }
    }

    public void Update()
    {
        var currentMouseState = Mouse.GetState();

        if (isFirstUpdate)
        {
            previousMouseState = currentMouseState;
            isFirstUpdate = false;
            return;
        }

        var mousePos = new Point(currentMouseState.X, currentMouseState.Y);

        for (int i = 0; i < characterButtons.Count; i++)
        {
            if (characterButtons[i].Contains(mousePos) && 
                currentMouseState.LeftButton == ButtonState.Pressed && 
                previousMouseState.LeftButton == ButtonState.Released)
            {
                SelectCharacter(i);
                break;
            }
        }

        previousMouseState = currentMouseState;
    }

    private void SelectCharacter(int index)
    {
        BaseCharacter character = index switch
        {
            0 => new ExplodeCharacter(ballManager, levelCombiner),
            1 => new BreakRedsCharacter(ballManager, levelCombiner),
            2 => new DuplicateBallCharacter(ballManager),
            3 => new RespawnBallCharacter(ballManager),
            4 => new FireballCharacter(ballManager),
            _ => new ExplodeCharacter(ballManager, levelCombiner)
        };
        player.SetCharacter(character);
        ballManager.StartShootDelay();
        gameStateManager.ChangeState(GameState.Playing);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Globals.Pixel, new Rectangle(0, 0, Globals.Bounds.X, Globals.Bounds.Y), 
            new Color(0, 0, 0, 180));

        string title = "Select Character";
        Vector2 titleSize = Globals.Font.MeasureString(title);
        Vector2 titlePos = new(
            (Globals.Bounds.X - titleSize.X) / 2,
            characterButtons[0].Y - titleSize.Y - 20
        );
        Globals.SpriteBatch.DrawString(Globals.Font, title, titlePos, Color.White);

        for (int i = 0; i < characterButtons.Count; i++)
        {
            var mouseState = Mouse.GetState();
            var mousePos = new Point(mouseState.X, mouseState.Y);
            Color buttonColor = characterButtons[i].Contains(mousePos) ? Color.Gray : Color.DarkGray;
            
            Globals.SpriteBatch.Draw(Globals.Pixel, characterButtons[i], buttonColor);
            
            Vector2 textSize = Globals.Font.MeasureString(characters[i].Name);
            Vector2 textPos = new(
                characterButtons[i].Center.X - textSize.X / 2,
                characterButtons[i].Center.Y - textSize.Y / 2
            );
            Globals.SpriteBatch.DrawString(Globals.Font, characters[i].Name, textPos, Color.White);
        }
    }
}