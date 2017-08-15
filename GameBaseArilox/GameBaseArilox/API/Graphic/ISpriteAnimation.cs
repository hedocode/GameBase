using System.Collections.Generic;
using GameBaseArilox.API.Core;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Graphic
{
    public interface ISpriteAnimation : IEffect
    {
        string Name { get; }
        List<Rectangle> AnimationsTextures { get; set; }
        float Speed { get; set; }
        bool IsSeesaw { get; set; }
    }
}
