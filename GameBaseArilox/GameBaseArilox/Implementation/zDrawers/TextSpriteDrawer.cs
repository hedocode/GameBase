using System;
using System.Collections.Generic;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Implementation.zDrawers
{
    public class TextSpriteDrawer : IDrawer
    {
        /*------------*/
        /* ATTRIBUTES */
        /*------------*/
        private Dictionary<string, SpriteFont> _spriteFonts;
        private List<ITextSprite> _toDraw;

        /*------------*/
        /* PROPERTIES */
        /*------------*/

        /*-------------*/
        /* CONSTRUCTOR */
        /*-------------*/
        public TextSpriteDrawer(GameModel game)
        {
            _spriteFonts = new Dictionary<string, SpriteFont>();
            _toDraw = new List<ITextSprite>();
            game.AddToDrawers(this);
        }



        /*------------*/
        /*   METHODS  */
        /*------------*/

        public void AddTextSprite(ITextSprite toAdd)
        {
            _toDraw.Add(toAdd);
        }

        public void RemoveTextSprite(ITextSprite toRemove)
        {
            if (_toDraw.Contains(toRemove))
            {
                _toDraw.Remove(toRemove);
            }
        }

        public void AddContent(string contentId, object content)
        {
            SpriteFont spriteFont = content as SpriteFont;
            if (spriteFont != null)
                _spriteFonts.Add(contentId, spriteFont);
        }

        public void DrawAll(SpriteBatch spriteBatch)
        {
            foreach (ITextSprite sprite in _toDraw)
            {
                Draw(spriteBatch, sprite);
            }
        }

        public void Draw(SpriteBatch spriteBatch, ITextSprite textSprite)
        {
            SpriteFont spriteFont;
            _spriteFonts.TryGetValue(textSprite.FontName, out spriteFont);
            if (spriteFont == null) throw new Exception("SpriteFont not found in the dictionary");
            spriteBatch.DrawString(spriteFont,textSprite.Text,textSprite.Position, textSprite.Color, 
                textSprite.Rotation, textSprite.Origin, textSprite.Scale, textSprite.SpriteEffect, textSprite.Depth);
        }
    }
}
