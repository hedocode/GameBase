using GameBaseArilox.API.Core;

namespace GameBaseArilox.API.Graphic
{
    public interface ITextSpriteEffect : IEffect
    {
        ITextSprite AnimatedTextSprite { get; set; }
    }
}
