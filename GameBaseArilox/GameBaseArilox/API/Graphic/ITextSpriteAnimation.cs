using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Effects;

namespace GameBaseArilox.API.Graphic
{
    public interface ITextSpriteAnimation : IEffectOverTime,IEffectObject, INamed
    {
        ITextSprite AffectedTextSprite { get; set; }
        List<string> AnimationTexts { get; set; }
        bool IsSeesaw { get; set; }
    }
}
