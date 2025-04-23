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
    private int buttonWidth = (int)Globals.Font.MeasureString("Random character").X+20; //This is just because random character button is the longest and button length should stay consistent
    private int buttonHeight = 40;
    private int buttonSpacing = 15;
    private bool isFirstUpdate = true;

    private readonly int descriptionX;
    private readonly int buttonX;
    private const int DESCRIPTION_PADDING = 20;

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
            new FireballCharacter(ballManager),
            new ExplodeCharacter(ballManager, levelCombiner) //This is a placeholder for random character
        };

        buttonX = Globals.Bounds.X / 3;
        descriptionX = Globals.Bounds.X / 3 * 2;

        InitializeButtons();
        
    }

    private void InitializeButtons()
    {
        int startY = (Globals.Bounds.Y - (characters.Count * (buttonHeight + buttonSpacing))) / 2;
        for (int i = 0; i < characters.Count; i++)
        {
            characterButtons.Add(new Rectangle(
                buttonX - (buttonWidth / 2), // Center buttons on buttonX
                startY + (buttonHeight + buttonSpacing) * i,
                buttonWidth,
                buttonHeight
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
        if (index == characterButtons.Count-1)
        {
            index = Globals.Random.Next(0, characters.Count);
        }
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
            buttonX - (titleSize.X / 2),
            characterButtons[0].Y - titleSize.Y - 20
        );
        Globals.SpriteBatch.DrawString(Globals.Font, title, titlePos, Color.White);

        var mouseState = Mouse.GetState();
        var mousePos = new Point(mouseState.X, mouseState.Y);

        string currentDescription = null;
        int hoveredIndex = -1;

        for (int i = 0; i < characterButtons.Count; i++)
        {
            Color buttonColor = characterButtons[i].Contains(mousePos) ? Color.Gray : Color.DarkGray;
            Globals.SpriteBatch.Draw(Globals.Pixel, characterButtons[i], buttonColor);

            string buttonText = (i == characterButtons.Count - 1) ? "Random character" : characters[i].Name;
            Vector2 textSize = Globals.Font.MeasureString(buttonText);
            Vector2 textPos = new(
                characterButtons[i].Center.X - textSize.X / 2,
                characterButtons[i].Center.Y - textSize.Y / 2
            );
            Globals.SpriteBatch.DrawString(Globals.Font, buttonText, textPos, Color.White);

            if (characterButtons[i].Contains(mousePos))
            {
                hoveredIndex = i;
                currentDescription = (i < characters.Count - 1) ? characters[i].Description() : "Select a random character";
            }
        }

        if (hoveredIndex != -1 && currentDescription != null)
        {
            Vector2 descPos = new(
                descriptionX,
                characterButtons[hoveredIndex].Center.Y - (Globals.Font.MeasureString(currentDescription).Y / 2)
            );
            Globals.SpriteBatch.DrawString(Globals.Font, currentDescription, descPos, Color.White);
        }
    }
}