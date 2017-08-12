using System.Collections.Generic;

namespace GameBaseArilox.API.Graphic
{
    public interface IBackground
    {
        List<ISprite> BackgroundSprites { get; set; }
    }
}
