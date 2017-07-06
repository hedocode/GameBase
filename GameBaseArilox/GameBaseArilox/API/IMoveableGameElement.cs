using Microsoft.Xna.Framework;

namespace GameBaseArilox.API
{
    public interface IMoveableGameElement : IGameElement
    {
        Vector2 MaxVelocity { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }
    }
}
