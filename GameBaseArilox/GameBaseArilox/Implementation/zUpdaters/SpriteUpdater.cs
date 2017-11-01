using System;
using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Effects;
using GameBaseArilox.API.Graphic;
using GameBaseArilox.Implementation.Graphic;
using GameBaseArilox.Implementation.GUI;
using GameBaseArilox.Implementation.zDrawers;
using Microsoft.Xna.Framework;
using IDrawable = GameBaseArilox.API.Graphic.IDrawable;

namespace GameBaseArilox.Implementation.zUpdaters
{
    public class SpriteUpdater : IUpdater
    {
          /*------------*/
         /* ATTRIBUTES */
        /*------------*/
        private SpriteDrawer _spriteDrawer;
        

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
            },
            {"MoumouneBotLeft",new SpriteAnimation("MoumouneBotLeft","Moumoune",
                new List<Rectangle>
                {
                    new Rectangle(0, 0, 16, 16),
                    new Rectangle(16, 0, 16, 16),
                    new Rectangle(32, 0, 16, 16),
                    new Rectangle(48, 0, 16, 16),
                    new Rectangle(64, 0, 16, 16),
                    new Rectangle(80, 0, 16, 16),
                    new Rectangle(96, 0, 16, 16),
                    new Rectangle(112,0,16,16)
                }
                ,0.2f, false) }
        };

        private readonly List<IDrawableEffectOverTime> _effectsToAdd;
        private readonly List<IDrawableEffectOverTime> _effectsToRemove;

        private readonly List<ISprite> _spritesToRemove;

          /*------------*/
         /* PROPERTIES */
        /*------------*/
        public List<ISprite> ToUpdate { get; set; }
        public int ToUpdateNumber => ToUpdate.Count;


          /*-------------*/
         /* CONSTRUCTOR */
        /*-------------*/
        public SpriteUpdater(GameModel game)
        {
            _spriteDrawer = game.SpriteDrawer;
            _effectsToAdd = new List<IDrawableEffectOverTime>();
            _effectsToRemove = new List<IDrawableEffectOverTime>();
            _spritesToRemove = new List<ISprite>();
            ToUpdate = new List<ISprite>();
            game.AddToUpdaters(this);
        }

          /*------------*/
         /*   METHODS  */
        /*------------*/
        public void Update(GameTime gameTime)
        {
            AddSpriteEffects();
            RemoveSpriteEffects();
            foreach (ISprite spriteToRemove in _spritesToRemove)
            {
                ToUpdate.Remove(spriteToRemove);
                _spriteDrawer.RemoveSprite(spriteToRemove);
            }
            _spritesToRemove.Clear();
            UpdateSprites(gameTime);
        }

        public void AddToUpdate(ISprite sprite)
        {
            ToUpdate.Add(sprite);
            InitSprite(sprite);
        }

        public void AddToUpdate(Cursor cursor)
        {
            ToUpdate.Add(cursor.Sprite);
            InitSprite(cursor.Sprite);
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
                sprite.ElapsedLifeTime += gameTime.ElapsedGameTime.TotalSeconds;
                if (sprite.ElapsedLifeTime > sprite.Duration)
                {
                    _spritesToRemove.Add(sprite);
                }
                UpdateEffect(sprite, gameTime);
                UpdateAnimations(sprite, gameTime);
            }
        }

        public void UpdateEffect(ISprite sprite, GameTime gameTime)
        {
            if (sprite.Effects.Count == 0) return;
            sprite.Effects?[0].Affect(gameTime);
            if (sprite.Effects?[0].ElapsedLifeTime >= sprite.Effects?[0].Duration)
                _effectsToRemove.Add(sprite.Effects[0]);
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
                if (sprite.TimeSpent >= spriteAnimation.Frequency)
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
                    sprite.TimeSpent = 0;
                    sprite.TextureSourceRectangle = spriteAnimation.AnimationsTextures[sprite.CurrentFrame];
                }
            }
        }

        public void InitSprite(ISprite sprite)
        {
            sprite.TextureSourceRectangle = new Rectangle(0,0,sprite.Width,sprite.Height);
            sprite.Opacity = 1;
            sprite.Color = Color.White;
            sprite.Origin = new Vector2(0,0);
        }
    }
}
