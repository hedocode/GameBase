using GameBaseArilox.API.Effects;

namespace GameBaseArilox.API.Graphic
{
    public interface ISpriteEffectOverTime : IDrawableEffectOverTime
    {
        ISprite AffectedSprite { get; set; }
    }
}
