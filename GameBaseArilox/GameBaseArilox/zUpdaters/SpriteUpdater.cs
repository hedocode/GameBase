using System;
using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Graphic;
using GameBaseArilox.Graphic;
using Microsoft.Xna.Framework;

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

        private readonly List<ISpriteEffect> _effectsToAdd;
        private readonly List<ISpriteEffect> _effectsToRemove;

          /*------------*/
         /* PROPERTIES */
        /*------------*/
        public List<ISprite> ToUpdate { get; set; }


          /*-------------*/
         /* CONSTRUCTOR */
        /*-------------*/
        public SpriteUpdater()
        {
            _effectsToAdd = new List<ISpriteEffect>();
            _effectsToRemove = new List<ISpriteEffect>();
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

        public void Reset(ISprite sprite)
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
            foreach (ISpriteEffect effect in _effectsToAdd)
            {
                effect.AffectedSprite.Effects.Add(effect);
            }
            _effectsToAdd.Clear();
        }

        public void RemoveSpriteEffects()
        {
            foreach (ISpriteEffect effect in _effectsToRemove)
            {
                effect.AffectedSprite.Effects.Remove(effect);
                if (effect.AffectedSprite.Effects.Count == 0)
                {
                    Reset(effect.AffectedSprite);
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
                foreach (IEffect spriteEffect in sprite.Effects)
                {
                    if (spriteEffect.TimeSpent >= spriteEffect.Duration)
                    {
                        _effectsToRemove.Add(spriteEffect as ISpriteEffect);
                    }
                    spriteEffect.Affect(gameTime);
                }
            }
        }

        public void UpdateAnimations(ISprite sprite, GameTime gameTime)
        {
            if (sprite.CurrentAnimation != null)
            {
                sprite.TimeSpent += gameTime.ElapsedGameTime.TotalSeconds;
                SpriteAnimation spriteAnimation;
                _animations.TryGetValue(sprite.CurrentAnimation, out spriteAnimation);
                if (spriteAnimation.Name == null)
                {
                    throw new Exception("ERROR : Animation Not found in the animation dictionary");
                }

                if (sprite.TimeSpent >= spriteAnimation.Speed)
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
                    sprite.TimeSpent = 0;
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
