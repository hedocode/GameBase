using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Environment
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
