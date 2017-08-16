using System;
using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.zUpdaters
{
    class SpriteUpdater : IUpdater
    {
        private readonly Dictionary<string, Rectangle> _initializeSpriteRectangleValue = new Dictionary<string, Rectangle>()
        {
            {"SpriteTest",new Rectangle(0,0,64,64)}
        };

        private readonly List<ISpriteEffect> _animationsToAdd;
        private readonly List<ISpriteEffect> _animationsToRemove;

        public List<ISprite> ToUpdate { get; set; }

        public SpriteUpdater()
        {
            _animationsToAdd = new List<ISpriteEffect>();
            _animationsToRemove = new List<ISpriteEffect>();
            ToUpdate = new List<ISprite>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (ISpriteEffect spriteAnimation in _animationsToAdd)
            {
                spriteAnimation.AffectedSprite.Effects.Add(spriteAnimation);
            }
            _animationsToAdd.Clear();

            foreach (ISpriteEffect spriteAnimation in _animationsToRemove)
            {
                spriteAnimation.AffectedSprite.Effects.Remove(spriteAnimation);
                if (spriteAnimation.AffectedSprite.Effects.Count == 0)
                {
                    Reset(spriteAnimation.AffectedSprite);
                }
            }
            _animationsToRemove.Clear();

            foreach (ISprite sprite in ToUpdate)
            {
                if (sprite.Effects.Count != 0)
                {
                    foreach (ISpriteEffect spriteAnimation in sprite.Effects)
                    {

                        if (spriteAnimation.TimeSpent >= spriteAnimation.Duration)
                        {
                            _animationsToRemove.Add(spriteAnimation);

                        }
                        spriteAnimation.Affect(gameTime);
                    }
                }
            }
        }

        public void AddToUpdate(ISprite sprite)
        {
            ToUpdate.Add(sprite);
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
        }

        public void InitializeSpriteSourceRectangle(ISprite sprite)
        {
            Rectangle temp;
            _initializeSpriteRectangleValue.TryGetValue(sprite.TextureId, out temp);
            if (temp == new Rectangle(0,0,0,0))
            {
                throw new Exception("ERROR WITH TEXTUREID");
            }
        }
    }
}
