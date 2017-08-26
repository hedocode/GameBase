using System;
using System.Collections.Generic;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.zDrawers
{
    class SpriteDrawer : IDrawer
    {
          /*------------*/
         /* ATTRIBUTES */
        /*------------*/
        private Dictionary<string, Texture2D> _spriteSets;


          /*------------*/
         /* PROPERTIES */
        /*------------*/
        public List<ISprite> ToDraw { get; set; }

          /*-------------*/
         /* CONSTRUCTOR */
        /*-------------*/
        public SpriteDrawer()
        {
            _spriteSets = new Dictionary<string, Texture2D>();
            ToDraw = new List<ISprite>();
        }

        /*------------*/
        /*   METHODS  */
        /*------------*/
        public void DrawAll(SpriteBatch spriteBatch)
        {
            foreach (ISprite sprite in ToDraw)
            {
                Draw(spriteBatch, sprite);
            }
        }

        public void Draw(SpriteBatch spriteBatch, ISprite sprite)
        {
            Texture2D spriteTexture;
            _spriteSets.TryGetValue(sprite.TextureId, out spriteTexture);
            if(spriteTexture == null) throw new Exception("Texture not found in the dictionary");
            spriteBatch.Draw(spriteTexture, sprite.ScreenPosition, sprite.TextureSourceRectangle, Color.White * sprite.Opacity, sprite.Rotation, sprite.Origin, sprite.Scale, sprite.SpriteEffect, 0);
        }

        public void AddTexture2D(string textureId, Texture2D texture)
        {
            _spriteSets.Add(textureId, texture);
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
