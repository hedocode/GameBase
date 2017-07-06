using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.API
{
    public interface ITextSprite : IScreenPositioned
    {
        SpriteFont Font { get; set; }
        string Text { get; set; }
        Color Color { get; set; }
        float Rotation { get; set; }
        Vector2 Origin { get; set; }
        Vector2 Scale { get; set; }
        SpriteEffects Effects { get; set; }
        float LayerDepth { get; set; }
    }
}
