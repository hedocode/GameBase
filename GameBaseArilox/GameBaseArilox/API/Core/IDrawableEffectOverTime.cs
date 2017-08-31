using GameBaseArilox.API.Graphic;

namespace GameBaseArilox.API.Core
{
    public interface IDrawableEffectOverTime : IEffectOverTime, IEffectObject
    {
        IDrawable AffectedDrawable { get; set; }
        void SetDrawable(IDrawable drawable);
    }
}
