namespace Slutprojekt;
public class DuplicateBallCharacter : BaseCharacter
{
    public DuplicateBallCharacter(BallManager ballmanager) : base(ballmanager)
    {
        Powerup = new DuplicateBallPowerup(ballmanager);
    }
    public override string Description()
    {
        return "";
    }

    public override void Draw()
    {
        // Draw the character texture at the specified position
        //Globals.SpriteBatch.Draw(Texture, Position, Color.White);
    }
}