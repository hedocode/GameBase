using System;
using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Graphic;
using GameBaseArilox.Graphic;
using Microsoft.Xna.Framework;
using IDrawable = GameBaseArilox.API.Graphic.IDrawable;

namespace GameBaseArilox.zUpdaters
{
    public class SpriteUpdater : IUpdater
    {
          /*------------*/
         /* ATTRIBUTES */
        /*------------*/
        private readonly Dictionary<string, Rectangle> _initializeSpriteRectangleValue = new Dictionary<string, Rectangle>
        {
            {"SpriteTest",new Rectangle(0,0,64,64)},
            {"Cursor1",new Rectangle(0,0,32,32)}
        };

        private readonly Dictionary<string, SpriteAnimation> _animations = new Dictionary<string, SpriteAnimation>
        {
            {"Cursor1Idle",new SpriteAnimation("Cursor1Idle","Cursor1",
                new List<Rectangle>
                {
                    new Rectangle(0, 0, 32, 32),
                    new Rectangle(32, 0, 32, 32),
                    new Rectangle(64, 0, 32, 32),
                    new Rectangle(96, 0, 32, 32),
                    new Rectangle(128, 0, 32, 32),
                    new Rectangle(160, 0, 32, 32)
                }
                ,0.2f)
            }
        };

        private readonly List<IDrawableEffectOverTime> _effectsToAdd;
        private readonly List<IDrawableEffectOverTime> _effectsToRemove;

          /*------------*/
         /* PROPERTIES */
        /*------------*/
        public List<ISprite> ToUpdate { get; set; }


          /*-------------*/
         /* CONSTRUCTOR */
        /*-------------*/
        public SpriteUpdater()
        {
            _effectsToAdd = new List<IDrawableEffectOverTime>();
            _effectsToRemove = new List<IDrawableEffectOverTime>();
            ToUpdate = new List<ISprite>();
        }

          /*------------*/
         /*   METHODS  */
        /*------------*/
        public void Update(GameTime gameTime)
        {
            AddSpriteEffects();
            RemoveSpriteEffects();

            UpdateSprites(gameTime);
        }

        public void AddToUpdate(ISprite sprite)
        {
            ToUpdate.Add(sprite);
            InitSprite(sprite);
        }

        public void RemoveToUpdate(ISprite sprite)
        {
            if (ToUpdate.Contains(sprite))
            {
                ToUpdate.Remove(sprite);
            }
        }

        public void SetToUpdateList(List<ISprite> spriteList)
        {
            ToUpdate = spriteList;
        }

        public void Reset(IDrawable sprite)
        {
            sprite.Opacity = 1;
            sprite.Rotation = 0;
            sprite.Scale = new Vector2(1,1);
            sprite.CurrentFrame = 1;
            sprite.CurrentAnimation = null;
        }

        public void InitializeSpriteSourceRectangle(ISprite sprite)
        {
            Rectangle temp;
            _initializeSpriteRectangleValue.TryGetValue(sprite.TextureId, out temp);
            if (temp == Rectangle.Empty)
            {
                throw new Exception("ERROR WITH TEXTUREID");
            }
        }

        public void AddSpriteEffects()
        {
            foreach (IDrawableEffectOverTime effect in _effectsToAdd)
            {
                effect.AffectedDrawable.Effects.Add(effect);
            }
            _effectsToAdd.Clear();
        }

        public void RemoveSpriteEffects()
        {
            foreach (IDrawableEffectOverTime effect in _effectsToRemove)
            {
                effect.AffectedDrawable.Effects.Remove(effect);
                if (effect.AffectedDrawable.Effects.Count == 0)
                {
                    ISprite sprite = effect.AffectedDrawable as ISprite;
                    if (sprite != null)
                    {
                        Reset(sprite);
                    }
                }
            }
            _effectsToRemove.Clear();
        }

        public void UpdateSprites(GameTime gameTime)
        {
            foreach (ISprite sprite in ToUpdate)
            {
                UpdateEffect(sprite, gameTime);

                UpdateAnimations(sprite, gameTime);
            }
        }

        public void UpdateEffect(ISprite sprite, GameTime gameTime)
        {
            if (sprite.Effects.Count != 0)
            {
                foreach (IDrawableEffectOverTime spriteEffect in sprite.Effects)
                {
                    if (spriteEffect.TimeSpent >= spriteEffect.Duration)
                    {
                        _effectsToRemove.Add(spriteEffect);
                    }
                    spriteEffect.Affect(gameTime);
                }
            }
        }

        public void UpdateAnimations(ISprite sprite, GameTime gameTime)
        {
            if (sprite.CurrentAnimation != null)
            {
                SpriteAnimation spriteAnimation;
                _animations.TryGetValue(sprite.CurrentAnimation, out spriteAnimation);
                if (spriteAnimation.Name == null)
                {
                    throw new Exception("ERROR : Animation Not found in the animation dictionary");
                }

                if (spriteAnimation.TimeSpent >= spriteAnimation.Speed)
                {
                    if (!spriteAnimation.IsSeesaw)
                    {
                        sprite.CurrentFrame = (sprite.CurrentFrame + 1) % (spriteAnimation.AnimationsTextures.Count - 1);
                    }
                    else
                    {
                        if (sprite.Increase)
                        {
                            sprite.CurrentFrame++;
                            if (sprite.CurrentFrame >= spriteAnimation.AnimationsTextures.Count - 1)
                            {
                                sprite.Increase = false;
                            }
                        }
                        else
                        {
                            sprite.CurrentFrame--;
                            if (sprite.CurrentFrame == 0)
                            {
                                sprite.Increase = true;
                            }
                        }
                    }
                    sprite.TextureSourceRectangle = spriteAnimation.AnimationsTextures[sprite.CurrentFrame];
                }

            }
        }

        public void InitSprite(ISprite sprite)
        {
            Rectangle rectangleInitSource;
            _initializeSpriteRectangleValue.TryGetValue(sprite.TextureId, out rectangleInitSource);
            if (rectangleInitSource == Rectangle.Empty)
            {
                throw new Exception("ERROR : Init value not found in the init Dictionary.");
            }
            sprite.TextureSourceRectangle = rectangleInitSource;
        }
    }
}
