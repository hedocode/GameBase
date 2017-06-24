using Microsoft.Xna.Framework;

namespace GameBaseArilox.Core
{
    public interface IMoveableGameElement : IGameElement
    {
        Vector2 Velocity { get; set; }
    }
}
