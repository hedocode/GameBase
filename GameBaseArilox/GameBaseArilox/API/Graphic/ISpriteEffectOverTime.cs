using GameBaseArilox.API.Core;

namespace GameBaseArilox.API.Graphic
{
    public interface ISpriteEffectOverTime : IDrawableEffectOverTime
    {
        ISprite AffectedSprite { get; set; }
    }
}
