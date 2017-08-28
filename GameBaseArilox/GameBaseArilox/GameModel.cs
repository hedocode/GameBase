using GameBaseArilox.API.Graphic;
using GameBaseArilox.Core;
using GameBaseArilox.zDrawers;
using GameBaseArilox.zLoaders;
using GameBaseArilox.zUpdaters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox
{
    public abstract class GameModel : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;

        private SpriteDrawer _spriteDrawer;
        private SpriteUpdater _spriteUpdater;
        private SpriteLoader _spriteLoader;

        public Camera2D Camera;

        private ISprite _sprite;

        public GameModel()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _spriteDrawer = new SpriteDrawer();
            _spriteUpdater = new SpriteUpdater();
            _spriteLoader = new SpriteLoader(Content, _spriteDrawer);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Immediate);

            _spriteDrawer.DrawAll(_spriteBatch);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
    }
}
