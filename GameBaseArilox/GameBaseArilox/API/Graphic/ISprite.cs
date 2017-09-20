using GameBaseArilox.API.Effects;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Graphic
{
    public interface ISprite : IDrawable, IChangedOverTime, ILimitedLifeTime
    {
        string TextureId { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        Rectangle TextureSourceRectangle { get; set; }
    }
}
