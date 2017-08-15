using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox
{
    class GameExample : Game
    {
        private ISprite _sprite;
        public GameExample()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            Content.Load<Texture2D>("");
            base.LoadContent();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
    }
}
