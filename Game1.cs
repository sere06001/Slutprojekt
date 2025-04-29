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
        _graphics.PreferredBackBufferWidth = 800; //= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = 600; //= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        _graphics.IsFullScreen = false;
        _graphics.ApplyChanges();

        //Globals.Bounds = new(1280, 720);
        Globals.Bounds = new(800, 600);
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
