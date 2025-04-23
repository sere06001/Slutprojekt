namespace Slutprojekt;
public class RespawnBallCharacter : BaseCharacter
{
    public RespawnBallCharacter(BallManager ballmanager) : base(ballmanager)
    {
        Powerup = new RespawnBallPowerup(ballmanager);
        Name = "Respawn Ball";
    }
    public override string Description()
    {
        return $"{Powerup.Description()}";
    }

    public override void Draw()
    {
        // Draw the character texture at the specified position
        //Globals.SpriteBatch.Draw(Texture, Position, Color.White);
    }
}