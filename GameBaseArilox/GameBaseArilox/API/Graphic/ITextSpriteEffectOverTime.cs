using GameBaseArilox.API.Core;

namespace GameBaseArilox.API.Graphic
{
    public interface ITextSpriteEffectOverTime : IEffectOverTime, IEffectObject
    {
        ITextSprite AffectedTextSprite { get; set; }
    }
}
