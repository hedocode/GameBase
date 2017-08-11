using System.Collections.Generic;
using GameBaseArilox.API;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Environment
{
    class ParalaxBackground : IBackground, IUpdater
    {
        public List<ISprite> BackgroundSprites { get; set; }

        public void Update(GameTime gameTime)
        {
            foreach (ISprite sprite in BackgroundSprites)
            {
                foreach (ISpriteEffect animation in sprite.Animations)
                {
                    animation.Affect(gameTime);
                }
            }
        }
    }
}
