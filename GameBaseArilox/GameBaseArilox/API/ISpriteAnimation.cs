using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.API
{
    public interface ISpriteAnimation : IEffect
    {
        List<Texture2D> AnimationsTextures { get; set; }
    }
}
