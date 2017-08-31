using GameBaseArilox.API.Core;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Graphic
{
    public interface ISprite : IDrawable, IChangedOverTime
    {
        string TextureId { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        Rectangle TextureSourceRectangle { get; set; }
    }
}
