namespace Slutprojekt;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameManager gameManager;
    public Texture2D pixel;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.IsFullScreen = true;
        _graphics.ApplyChanges();

        //Globals.Bounds = new(1280, 720);
        Globals.Bounds = new(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
        Globals.Content = Content;
        Globals.LoadContent();

        gameManager = new();
        gameManager.Init();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.SpriteBatch = _spriteBatch;
        pixel = new Texture2D(GraphicsDevice,1,1);
        Color[] colorData = { Color.White };
        pixel.SetData(colorData);
        Globals.Pixel = pixel;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Globals.Update(gameTime);
        gameManager.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        gameManager.Draw();
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
