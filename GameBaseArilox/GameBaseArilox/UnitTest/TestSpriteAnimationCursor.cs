using GameBaseArilox.Implementation.GUI;

namespace GameBaseArilox.UnitTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TestSpriteAnimationCursor : GameModel
    {
        public TestSpriteAnimationCursor()
        {
            Cursor = new Cursor("MoumouneBotLeft", "MoumouneBotLeft",64,64);
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

            IsMouseVisible = false;
            
            base.Initialize();
        }
        
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
    }
}
