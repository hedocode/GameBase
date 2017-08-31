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
                foreach (ISpriteEffectOverTime animation in sprite.Effects)
                {
                    animation.Affect(gameTime);
                }
            }
        }
    }
}
