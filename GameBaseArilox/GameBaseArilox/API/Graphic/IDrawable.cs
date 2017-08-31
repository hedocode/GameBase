using GameBaseArilox.API.Core;
using GameBaseArilox.API.Environment;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.API.Graphic
{
    public interface IDrawable : IScreenPositioned, IGameElement, IScalable, IRotatable, IAffected
    {
        bool Visible { get; set; }
        float Opacity { get; set; }
        Vector2 Origin { get; set; }
        float Depth { get; set; }
        Color Color { get; set; }
        SpriteEffects SpriteEffect { get; set; }
    }
}
