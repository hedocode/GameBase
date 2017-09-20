using GameBaseArilox.API.Effects;
using GameBaseArilox.API.Graphic;
using GameBaseArilox.Implementation.Graphic;

namespace GameBaseArilox.UnitTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TestSpriteEffects : GameModel
    {
        private readonly ISprite _sprite;
        private readonly ISprite _sprite2;
        private readonly ISprite _sprite3;
        private readonly ISprite _sprite4;

        public TestSpriteEffects()
        {
            Content.RootDirectory = "Content";
            _sprite = new Sprite(100,100,64,64,"SpriteTest");
            _sprite2 = new Sprite(400, 100, 64, 64, "SpriteTest");
            _sprite3 = new Sprite(100, 400, 64, 64, "SpriteTest");
            _sprite4 = new Sprite(400, 400, 64, 64, "SpriteTest");
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
            // Create a new SpriteBatch, which can be used to draw textures.

            IDrawableEffectOverTime d1 = new DrawableFlashingEffectOverTime(5, 50);
            IDrawableEffectOverTime d4 = new DrawableFlashingEffectOverTime(5, 7);
           
            d1.SetDrawable(_sprite);
            var d2 = new DrawableFlashingEffectOverTime(2, _sprite2, 3);
            var d3 = new DrawableFlashingEffectOverTime(3, _sprite3, 10);
            d4.SetDrawable(_sprite4);

            d2.Frequency = 9;
            d3.Duration = 20;
            //NOT WORKING_sprite.AddEffect(drawableFlashingEffectOverTime);
            //NOT WORKING_sprite4.AddEffect( d2);

            SpriteDrawer.AddSprite(_sprite);
            SpriteUpdater.AddToUpdate(_sprite);

            SpriteDrawer.AddSprite(_sprite2);
            SpriteUpdater.AddToUpdate(_sprite2);

            SpriteDrawer.AddSprite(_sprite3);
            SpriteUpdater.AddToUpdate(_sprite3);

            SpriteDrawer.AddSprite(_sprite4);
            SpriteUpdater.AddToUpdate(_sprite4);
            // TODO: use this.Content to load your game content here
        }
    }
}
