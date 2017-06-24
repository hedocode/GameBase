using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Core
{
    public interface ISprite : IGameElement
    {
        Texture2D Texture { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        float Opacity { get; set; }
        float Rotation { get; set; }
        float ScaleX { get; set; }
        float ScaleY { get; set; }
        List<ISpriteAnimation> Animations { get; set; }
    }
}
