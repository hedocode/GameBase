using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Graphic
{
    public interface IBackground
    {
        List<ISprite> BackgroundSprites { get; set; }
    }
}
