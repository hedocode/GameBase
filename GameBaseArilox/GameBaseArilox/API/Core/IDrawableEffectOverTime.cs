using GameBaseArilox.API.Graphic;

namespace GameBaseArilox.API.Core
{
    public interface IDrawableEffectOverTime : IEffectOverTime, IEffectObject, IChangedOverTime
    {
        IDrawable AffectedDrawable { get; set; }
        void SetDrawable(IDrawable drawable);
    }
}
