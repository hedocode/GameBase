using GameBaseArilox.API.Core;

namespace GameBaseArilox.API.Graphic
{
    public interface ISpriteEffect : IEffect
    {
        ISprite AffectedSprite { get; set; }
    }
}
