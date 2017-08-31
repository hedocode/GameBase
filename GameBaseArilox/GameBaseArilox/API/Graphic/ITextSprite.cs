using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.API.Graphic
{
    public interface ITextSprite : IDrawable
    {
        string FontName { get; set; }
        string Text { get; set; }
    }
}
