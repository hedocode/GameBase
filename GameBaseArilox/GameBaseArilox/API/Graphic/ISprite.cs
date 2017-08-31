using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Graphic
{
    public interface ISprite : IDrawable
    {
        string TextureId { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        Rectangle TextureSourceRectangle { get; set; }

        string CurrentAnimation { get; set; }
        int CurrentFrame { get; set; }
    }
}
