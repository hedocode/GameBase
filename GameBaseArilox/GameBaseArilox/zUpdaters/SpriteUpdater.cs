using System.Collections.Generic;
using GameBaseArilox.API;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.zUpdaters
{
    class SpriteUpdater : IUpdater
    {
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
                spriteAnimation.AffectedSprite.Animations.Add(spriteAnimation);
            }
            _animationsToAdd.Clear();

            foreach (ISpriteEffect spriteAnimation in _animationsToRemove)
            {
                spriteAnimation.AffectedSprite.Animations.Remove(spriteAnimation);
                if (spriteAnimation.AffectedSprite.Animations.Count == 0)
                {
                    Reset(spriteAnimation.AffectedSprite);
                }
            }
            _animationsToRemove.Clear();

            foreach (ISprite sprite in ToUpdate)
            {
                if (sprite.Animations.Count != 0)
                {
                    foreach (ISpriteEffect spriteAnimation in sprite.Animations)
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
    }
}
