using GameBaseArilox.API.Environment;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Core
{
    public interface IMoveableGameElement : IGameElement
    {
        Vector2 MaxVelocity { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }
    }
}
