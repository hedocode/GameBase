using System.Collections.Generic;
using GameBaseArilox.API.Enums;
using GameBaseArilox.Implementation.Graphic;
using GameBaseArilox.Implementation.Shapes;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.UnitTest
{
    public class TestParticleGenerator : GameModel
    {
        private ParticleGenerator _particleGenerator;
        public TestParticleGenerator()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"dustParticle", 100},
                {"SpriteTest", 0}
            };
            _particleGenerator = new ParticleGenerator(400,300,dictionary,Direction.Right,0,999,0.2f,10);
            GeneratorUpdater.AddGenerator(_particleGenerator);
            GeneratorUpdater.AddGenerator(new ParticleGenerator(250, 250, dictionary, Direction.Top, new Angle(45), 10, 0.5f, 4));
        }

        protected override void Initialize()
        {
            base.Initialize();
            //WindowWidth = ScreenWidth;
            //WindowHeight = ScreenHeight;
            //Graphics.IsFullScreen = true;
            //Graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _particleGenerator.Rotation += 0.1f;
            _particleGenerator.SprayAngle += 0.1f;
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            SpriteBatch.Begin();
            SpriteBatch.DrawString(SpriteFont, InputsManager.MouseInput.IsLeftButtonPressed().ToString(), new Vector2(5, 50), Color.Orange);
            SpriteBatch.DrawString(SpriteFont, SpriteDrawer.DrawableNumber.ToString(), new Vector2(5, 100), Color.Orange);
            SpriteBatch.DrawString(SpriteFont, SpriteUpdater.ToUpdateNumber.ToString(), new Vector2(5, 150), Color.Orange);
            SpriteBatch.End();
        }
    }
}
