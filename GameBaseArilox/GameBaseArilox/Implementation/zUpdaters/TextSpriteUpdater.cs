using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Effects;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Implementation.zUpdaters
{
    public class TextSpriteUpdater : IUpdater
    {

        private readonly List<IDrawableEffectOverTime> _effectsToAdd;
        private readonly List<IDrawableEffectOverTime> _effectsToRemove;

        private Dictionary<string, SpriteFont> _spriteFonts;

        public List<ITextSprite> ToUpdate { get; set; }

        /*-------------*/
        /* CONSTRUCTOR */
        /*-------------*/

        public TextSpriteUpdater(GameModel game)
        {
            _effectsToAdd = new List<IDrawableEffectOverTime>();
            _effectsToRemove = new List<IDrawableEffectOverTime>();

            _spriteFonts = new Dictionary<string, SpriteFont>();

            ToUpdate = new List<ITextSprite>();
            game.AddToUpdaters(this);
        }

        public void Update(GameTime gameTime)
        {
            AddTextSpriteEffects();
            RemoveTextSpriteEffects();

            UpdateTextSprites(gameTime);
        }

        public void AddContent(string textureId, object content)
        {
            SpriteFont spriteFont = content as SpriteFont;
            if (spriteFont != null)
                _spriteFonts.Add(textureId, spriteFont);
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
                    if (textSpriteEffect.ElapsedLifeTime >= textSpriteEffect.Duration)
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
                if (textSprite.Animation.ElapsedLifeTime >= textSprite.Animation.Duration)
                {
                    textSprite.Animation.Reset();
                }
            }
        }

        public void InitializeTextSprite(ITextSprite textSprite)
        {
            textSprite.Origin = Vector2.One;
            SpriteFont spriteFont;
            _spriteFonts.TryGetValue(textSprite.FontName, out spriteFont);
        }
    }
}
