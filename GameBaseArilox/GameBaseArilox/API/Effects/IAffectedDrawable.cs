using System.Collections.Generic;

namespace GameBaseArilox.API.Effects
{
    public interface IAffectedDrawable
    {
        List<IDrawableEffectOverTime> Effects { get; set; }
        void AddEffect(IDrawableEffectOverTime effectOverTime);
    }
}
