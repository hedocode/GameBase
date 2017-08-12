using System.Collections.Generic;
using GameBaseArilox.API;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.zDrawers
{
    class SpriteDrawer : IDrawer
    {
        public SpriteDrawer()
        {
            ToDraw = new List<ISprite>();    
        }

        public List<ISprite> ToDraw { get; set; }

        public void DrawAll(SpriteBatch spriteBatch)
        {
            foreach (ISprite sprite in ToDraw)
            {
                Draw(spriteBatch, sprite);
            }
        }

        public void Draw(SpriteBatch spriteBatch, ISprite sprite)
        {
            spriteBatch.Draw(sprite.Texture, sprite.ScreenPosition, new Rectangle(0,0,64,64),Color.White * sprite.Opacity, sprite.Rotation, sprite.Origin, sprite.Scale, SpriteEffects.None, 0);
        }

        public void AddSprite(ISprite toAdd)
        {
            ToDraw.Add(toAdd);
        }

        public void RemoveSprite(ISprite toRemove)
        {
            if (ToDraw.Contains(toRemove))
            {
                ToDraw.Remove(toRemove);
            }
        }
    }
}
