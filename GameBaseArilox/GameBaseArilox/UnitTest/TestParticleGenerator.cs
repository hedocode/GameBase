using System.Collections.Generic;
using GameBaseArilox.API.Enums;
using GameBaseArilox.Implementation.Graphic;
using GameBaseArilox.Implementation.Shapes;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.UnitTest
{
    public class TestParticleGenerator : GameModel
    {
        public TestParticleGenerator()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"dustParticle", 100}
            };
            GeneratorUpdater.AddGenerator(new ParticleGenerator(250, 250, dictionary, Direction.Top, new Angle(45), 10, 0.5f, 4));
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            SpriteBatch.Begin();
            SpriteBatch.DrawString(SpriteFont, InputsManager.MouseInput.IsLeftButtonPressed().ToString(), new Vector2(5, 50), Color.Orange);
            SpriteBatch.End();
        }
    }
}
