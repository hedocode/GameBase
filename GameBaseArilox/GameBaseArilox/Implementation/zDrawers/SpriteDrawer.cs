using System;
using System.Collections.Generic;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Cursor = GameBaseArilox.Implementation.GUI.Cursor;

namespace GameBaseArilox.Implementation.zDrawers
{
    public class SpriteDrawer : IDrawer
    {
          /*------------*/
         /* ATTRIBUTES */
        /*------------*/
        private Dictionary<string, Texture2D> _spriteSets;
        private List<ISprite> _toDraw;
        public int DrawableNumber => _toDraw.Count;

        /*------------*/
        /* PROPERTIES */
        /*------------*/

        /*-------------*/
        /* CONSTRUCTOR */
        /*-------------*/
        public SpriteDrawer(GameModel game)
        {
            _spriteSets = new Dictionary<string, Texture2D>();
            _toDraw = new List<ISprite>();
            game.AddToDrawers(this);
        }

          /*------------*/
         /*   METHODS  */
        /*------------*/
        public void DrawAll(SpriteBatch spriteBatch)
        {
            foreach (ISprite sprite in _toDraw)
            {
                if(sprite.Visible)
                    Draw(spriteBatch, sprite);
            }
        }

        public void Draw(SpriteBatch spriteBatch, ISprite sprite)
        {
            Texture2D spriteTexture;
            if (sprite.CurrentAnimation == null)
            {
                _spriteSets.TryGetValue(sprite.TextureId, out spriteTexture);
            }
            else
            {
                _spriteSets.TryGetValue(sprite.CurrentAnimation, out spriteTexture);
            }
            if (spriteTexture == null) throw new Exception("Texture not found in the dictionary");
            spriteBatch.Draw(spriteTexture,new Rectangle(sprite.ScreenPosition.X, sprite.ScreenPosition.Y, (int)(sprite.Width*sprite.Scale.X),(int)(sprite.Height *sprite.Scale.Y)), sprite.TextureSourceRectangle,sprite.Color*sprite.Opacity,sprite.Rotation,sprite.Origin,sprite.SpriteEffect,sprite.Depth);
        }

        public void AddContent(string contentId, object content)
        {
            Texture2D texture = content as Texture2D;
            if(texture != null)
            _spriteSets.Add(contentId, texture);
        }

        public void AddSprite(ISprite toAdd)
        {
            _toDraw.Add(toAdd);
        }

        public void AddSprite(Cursor toAdd)
        {
            _toDraw.Add(toAdd.Sprite);
        }

        public void RemoveSprite(ISprite toRemove)
        {
            if (_toDraw.Contains(toRemove))
            {
                _toDraw.Remove(toRemove);
            }
        }
    }
}
