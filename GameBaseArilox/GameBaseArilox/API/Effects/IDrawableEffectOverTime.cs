using GameBaseArilox.API.Graphic;

namespace GameBaseArilox.API.Effects
{
    public interface IDrawableEffectOverTime : IEffectOverTime, IEffectObject
    {
        IDrawable AffectedDrawable { get; set; }
        void SetDrawable(IDrawable drawable);
    }
}
