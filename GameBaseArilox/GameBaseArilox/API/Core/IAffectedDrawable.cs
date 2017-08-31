using System.Collections.Generic;

namespace GameBaseArilox.API.Core
{
    public interface IAffectedDrawable
    {
        List<IDrawableEffectOverTime> Effects { get; set; }
        void AddEffect(IDrawableEffectOverTime effectOverTime);
    }
}
