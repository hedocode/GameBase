using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Environment;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.API.Graphic
{
    public interface ISprite : IScreenPositioned, IGameElement, IScalable, IRotatable
    {
        string TextureId { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        Rectangle TextureSourceRectangle { get; set; }
        float Opacity { get; set; }
        Vector2 Origin { get; set; }
        List<ISpriteEffect> Effects { get; set; }
        SpriteEffects SpriteEffect { get; set; }
        List<ISpriteAnimation> Animations { get; set; }
        ISpriteAnimation CurrentAnimation { get; set; }
    }
}
