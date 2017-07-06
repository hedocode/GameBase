using System.Collections.Generic;

namespace GameBaseArilox.API
{
    public interface IBackground
    {
        List<ISprite> BackgroundSprites { get; set; }
    }
}
