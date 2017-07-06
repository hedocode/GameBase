using System.Collections.Generic;
using GameBaseArilox.API;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Environment
{
    class ParalaxBackground : IBackground, IUpdater
    {
        public List<ISprite> BackgroundSprites { get; set; }

        public void Update(object o, GameTime gameTime)
        {
            foreach (ISprite sprite in BackgroundSprites)
            {
                foreach (ISpriteAnimation animation in sprite.Animations)
                {
                    animation.Animate(gameTime);
                }
            }
        }
    }
}
