using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.zUpdaters
{
    public class TextSpriteUpdater : IUpdater
    {

        private readonly List<ITextSpriteEffect> _effectsToAdd;
        private readonly List<ITextSpriteEffect> _effectsToRemove;

        public List<ITextSprite> ToUpdate { get; set; }

        /*-------------*/
        /* CONSTRUCTOR */
        /*-------------*/
        public TextSpriteUpdater()
        {
            _effectsToAdd = new List<ITextSpriteEffect>();
            _effectsToRemove = new List<ITextSpriteEffect>();

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

        public void Reset(ITextSprite sprite)
        {
            sprite.Opacity = 1;
            sprite.Rotation = 0;
            sprite.Scale = new Vector2(1, 1);
        }

        public void AddTextSpriteEffects()
        {
            foreach (ITextSpriteEffect effect in _effectsToAdd)
            {
                effect.AffectedTextSprite.Effects.Add(effect);
            }
            _effectsToAdd.Clear();
        }

        public void RemoveTextSpriteEffects()
        {
            foreach (ITextSpriteEffect effect in _effectsToRemove)
            {
                effect.AffectedTextSprite.Effects.Remove(effect);
                if (effect.AffectedTextSprite.Effects.Count == 0)
                {
                    Reset(effect.AffectedTextSprite);
                }
            }
            _effectsToRemove.Clear();
        }

        public void UpdateTextSprites(GameTime gameTime)
        {
            foreach (ITextSprite textSprite in ToUpdate)
            {
                UpdateEffect(textSprite, gameTime);
            }
        }

        public void UpdateEffect(ITextSprite textSprite, GameTime gameTime)
        {
            if (textSprite.Effects.Count != 0)
            {
                foreach (IEffect textSpriteEffect in textSprite.Effects)
                {
                    if (textSpriteEffect.TimeSpent >= textSpriteEffect.Duration)
                    {
                        _effectsToRemove.Add(textSpriteEffect as ITextSpriteEffect);
                    }
                    textSpriteEffect.Affect(gameTime);
                }
            }
        }
    }
}
