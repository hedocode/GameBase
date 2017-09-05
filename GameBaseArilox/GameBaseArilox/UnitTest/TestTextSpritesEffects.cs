using GameBaseArilox.API.Graphic;
using GameBaseArilox.Implementation.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.UnitTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TestTextSpritesEffects : GameModel
    {
        private ITextSprite _textSprite;
        

        public TestTextSpritesEffects()
        {
            _textSprite = new TextSprite(new Point(100,100), "Hello world");
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            base.LoadContent();
            new TextSpriteFlashingEffectOverTime(1, _textSprite);

            TextSpriteDrawer.AddTextSprite(_textSprite);
            TextSpriteUpdater.AddToUpdate(_textSprite);
            // TODO: use this.Content to load your game content here
        }
    }
}
