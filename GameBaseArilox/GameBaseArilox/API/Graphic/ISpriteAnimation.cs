using System.Collections.Generic;
using GameBaseArilox.API.Core;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.API.Graphic
{
    public interface ISpriteAnimation : IEffect
    {
        List<Texture2D> AnimationsTextures { get; set; }
    }
}
