namespace Slutprojekt;
public class FireballCharacter : BaseCharacter
{
    public FireballCharacter(BallManager ballmanager) : base(ballmanager)
    {
        Powerup = new FireballPowerup(ballmanager);
        Name = "Fireball";
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