using GameBaseArilox.API.Graphic;
using GameBaseArilox.Implementation.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.UnitTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TestTextSpritesAnimation : GameModel
    {
        private ITextSprite _textSprite;
        private ITextSprite _textSprite2;


        public TestTextSpritesAnimation()
        {
            _textSprite = new TextSprite(new Point(100,100), "Hello world -     ");
            _textSprite2 = new TextSprite(new Point(100, 200), "Hello world -     ");
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
            base.LoadContent();
            new TextSpriteHorizontalScrolling(5, 20, _textSprite);
            new TextSpriteHorizontalScrolling(5, 30, _textSprite2, true);
            AddDrawable(_textSprite);
            AddDrawable(_textSprite2);
            // TODO: use this.Content to load your game content here
        }
    }
}
