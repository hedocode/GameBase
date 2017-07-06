using System.Collections.Generic;
using GameBaseArilox.API;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Graphic
{
    class SpriteDrawer : IDrawer
    {
        private List<ISpriteAnimation> _animationsToAdd;
        private List<ISpriteAnimation> _animationsToRemove;

        public List<ISprite> ToDraw { get; set; }
        public void DrawAll(SpriteBatch spriteBatch)
        {
            foreach (ISprite sprite in ToDraw)
            {
                spriteBatch.Draw(sprite.Texture,sprite.ScreenPosition,Color.White*sprite.Opacity);
            }
        }

        public void Draw(SpriteBatch spriteBatch, ISprite sprite)
        {
            throw new System.NotImplementedException();
        }

        public SpriteDrawer()
        {
            _animationsToAdd = new List<ISpriteAnimation>();
            _animationsToRemove = new List<ISpriteAnimation>();


        }
    }
}
