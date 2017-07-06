using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.API
{
    public interface ISprite : IScreenPositioned, IGameElement
    {
        Texture2D Texture { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        float Opacity { get; set; }
        Vector2 Origin { get; set; }
        float Rotation { get; set; }
        Vector2 Scale { get; set; }
        List<ISpriteAnimation> Animations { get; set; }
    }
}
