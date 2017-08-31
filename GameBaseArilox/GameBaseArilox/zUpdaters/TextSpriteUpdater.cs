using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.zUpdaters
{
    public class TextSpriteUpdater : IUpdater
    {

        private readonly List<IDrawableEffectOverTime> _effectsToAdd;
        private readonly List<IDrawableEffectOverTime> _effectsToRemove;

        public List<ITextSprite> ToUpdate { get; set; }

        /*-------------*/
        /* CONSTRUCTOR */
        /*-------------*/

        public TextSpriteUpdater()
        {
            _effectsToAdd = new List<IDrawableEffectOverTime>();
            _effectsToRemove = new List<IDrawableEffectOverTime>();

            ToUpdate = new List<ITextSprite>();
        }

        public void Update(GameTime gameTime)
        {
            AddTextSpriteEffects();
            RemoveTextSpriteEffects();

            UpdateTextSprites(gameTime);
        }

        public void AddToUpdate(ITextSprite textSprite)
        {
            ToUpdate.Add(textSprite);
        }

        public void RemoveToUpdate(ITextSprite textSprite)
        {
            if (ToUpdate.Contains(textSprite))
            {
                ToUpdate.Remove(textSprite);
            }
        }
        

        public void AddTextSpriteEffects()
        {
            foreach (IDrawableEffectOverTime effect in _effectsToAdd)
            {
                effect.AffectedDrawable.Effects.Add(effect);
            }
            _effectsToAdd.Clear();
        }

        public void RemoveTextSpriteEffects()
        {
            foreach (IDrawableEffectOverTime effect in _effectsToRemove)
            {
                effect.AffectedDrawable.Effects.Remove(effect);
                if (effect.AffectedDrawable.Effects.Count == 0)
                {
                    effect.Reset();
                }
            }
            _effectsToRemove.Clear();
        }

        public void UpdateTextSprites(GameTime gameTime)
        {
            foreach (ITextSprite textSprite in ToUpdate)
            {
                UpdateEffect(textSprite, gameTime);
                UpdateAnimation(textSprite, gameTime);
            }
        }

        public void UpdateEffect(ITextSprite textSprite, GameTime gameTime)
        {
            if (textSprite.Effects.Count != 0)
            {
                foreach (IDrawableEffectOverTime textSpriteEffect in textSprite.Effects)
                {
                    if (textSpriteEffect.TimeSpent >= textSpriteEffect.Duration)
                    {
                        _effectsToRemove.Add(textSpriteEffect);
                    }
                    textSpriteEffect.Affect(gameTime);
                }
            }
        }

        public void UpdateAnimation(ITextSprite textSprite, GameTime gameTime)
        {
            if (textSprite.CurrentAnimation != null)
            {
                textSprite.Animation.Affect(gameTime);
                if (textSprite.Animation.TimeSpent >= textSprite.Animation.Duration)
                {
                    textSprite.Animation.Reset();
                }
            }
        }
    }
}
