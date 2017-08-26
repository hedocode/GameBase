using System.Collections.Generic;
using GameBaseArilox.API.Core;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Graphic
{
    public interface ISpriteAnimation : IEffect
    {
        string TargetContentId { get; set; }
        string Name { get; set; }
        List<Rectangle> AnimationsTextures { get; set; }
        float Speed { get; set; }
        bool IsSeesaw { get; set; }
    }
}
