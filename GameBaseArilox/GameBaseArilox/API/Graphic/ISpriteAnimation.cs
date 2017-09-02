using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Effects;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Graphic
{
    public interface ISpriteAnimation : IEffectOverTime, INamed
    {
        string TargetContentId { get; set; }
        List<Rectangle> AnimationsTextures { get; set; }
        bool IsSeesaw { get; set; }
    }
}
