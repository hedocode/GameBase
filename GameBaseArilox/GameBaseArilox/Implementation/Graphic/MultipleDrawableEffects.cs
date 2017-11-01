using System.Collections.Generic;
using GameBaseArilox.API.Effects;
using Microsoft.Xna.Framework;
using IDrawable = GameBaseArilox.API.Graphic.IDrawable;

namespace GameBaseArilox.Implementation.Graphic
{
    public class MultipleDrawableEffects : IDrawableEffectOverTime
    {
        private readonly List<IDrawableEffectOverTime> _effects;

        public MultipleDrawableEffects(List<IDrawableEffectOverTime> effects, IDrawable drawable, int frequenty)
        {
            _effects = effects;
            float maxDuration = 0;
            foreach (IDrawableEffectOverTime effect in _effects)
            {
                effect.SetDrawable(drawable);
                if (effect.Duration > maxDuration) maxDuration = effect.Duration;
            }
            Duration = maxDuration;
            Frequency = frequenty;
            ElapsedLifeTime = 0;
            drawable.AddEffect(this);
        }

        public float Duration { get; set; }
        public double ElapsedLifeTime { get; set; }
        public float Frequency { get; set; }
       

        public object AffectedObject { get; set; }
        public object BaseObject => AffectedDrawable;
        public void Reset()
        {
            foreach (IDrawableEffectOverTime effect in _effects)
            {
                effect.Reset();
            }
        }

        public IDrawable AffectedDrawable { get; set; }


        public void SetDrawable(IDrawable drawable)
        {
            AffectedDrawable = drawable;
        }

        public void Affect(GameTime gameTime)
        {
            foreach (IDrawableEffectOverTime effect in _effects)
            {
                effect.Affect(gameTime);
            }
        }
    }
}
