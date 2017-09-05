using System;
using GameBaseArilox.Implementation.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace GameBaseArilox.UnitTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TestAngle : Game
    {
        // ReSharper disable once NotAccessedField.Local
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;

        private Angle _angle1;
        private Angle _angle2;
        private readonly Angle _angle3;
        private readonly float _angle1Degree;

        public TestAngle()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _angle1 = new Angle(30);
            _angle2 = new Angle(50);
            _angle1Degree = _angle1;      //Testing Cast from angle to float
            _angle3 = (Angle)61.5f;  // Testing cast from float to Angle
            Console.WriteLine("Angle1 : " + _angle1);
            Console.WriteLine("Angle2 : " + _angle2);
            Console.WriteLine("Angle2-Angle1 : " + (_angle2 - _angle1));
            Console.WriteLine("Angle1 - 45 : " + (_angle1 - 45));
            Console.WriteLine("Angle2*2 : " + _angle2 * 2);
            Console.WriteLine("8*Angle2 : " + 8 * _angle2);
            Console.WriteLine("Angle1 == Angle2 : " + (_angle1 == _angle2) + " | " + _angle1.Degrees + "==" + _angle2.Degrees + (_angle1.Degrees == _angle2.Degrees));
            Console.WriteLine("Angle1 == 30 : " + (_angle1 == 30) + " | " + _angle1.Degrees + "==" + _angle1.Degrees + (_angle1.Degrees == 30));
            Console.WriteLine("Angle1 != Angle2 : " + (_angle1 != _angle2) + " | " + _angle1.Degrees + "!=" + _angle2.Degrees + (_angle1.Degrees != _angle2.Degrees));
            Console.WriteLine("Angle1 >= 30 : " + (_angle1 >= 30) + " | " + _angle1.Degrees + ">=" + _angle1.Degrees + (_angle1.Degrees >= 30));
            Console.WriteLine("Angle1 >= Angle2 : " + (_angle1 >= _angle2) + " | " + _angle1.Degrees + ">=" + _angle2.Degrees + (_angle1.Degrees == _angle2.Degrees));
            Console.WriteLine("Angle2 < Angle1 : " + (_angle2 < _angle1) + " | " + _angle2.Degrees + "<" + _angle1.Degrees + (_angle2.Degrees < _angle1.Degrees));
            Console.WriteLine("Angle2 > Angle1 : " + (_angle2 > _angle1) + " | " + _angle2.Degrees + ">" + _angle1.Degrees + (_angle2.Degrees > _angle1.Degrees));
            Console.WriteLine("float Angle1Degree = Angle1 : " + _angle1Degree);
            Console.WriteLine("Angle3 = 61.5f : " + _angle3);
            Console.WriteLine("HellYeah");
            Console.WriteLine("Angles are easy");
            Console.WriteLine("Degrees > Radian");
            Console.WriteLine("Pi > All");
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
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteFont = Content.Load<SpriteFont>("FONTS/Arial12");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.FrontToBack,BlendState.AlphaBlend,SamplerState.PointClamp,null,null,null,null);

            _spriteBatch.DrawString(_spriteFont, "Angle1 : "+_angle1, Vector2.Zero, Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle2 : " + _angle2, new Vector2(0,25), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle2-Angle1 : "+ (_angle2-_angle1), new Vector2(0, 50), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle1 - 45 : " + (_angle1-45), new Vector2(0, 75), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle2*2 : " + _angle2*2, new Vector2(0, 100), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "8*Angle2 : " + 8*_angle2, new Vector2(0, 125), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle1 + Angle2 : " + (_angle1+_angle2), new Vector2(0, 150), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle2 + 180 : " + (_angle2+180), new Vector2(0, 175), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle2/2 : " + _angle2/2, new Vector2(0, 200), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle1 == Angle2 : " + (_angle1==_angle2) + " | " + _angle1.Degrees + "==" + _angle2.Degrees + (_angle1.Degrees == _angle2.Degrees), new Vector2(0, 225), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle1 == 30 : " + (_angle1 == 30) + " | " + _angle1.Degrees +"=="+_angle1.Degrees+(_angle1.Degrees==30), new Vector2(0, 250), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle1 != Angle2 : " + (_angle1 != _angle2) + " | " + _angle1.Degrees + "!=" + _angle2.Degrees + (_angle1.Degrees != _angle2.Degrees), new Vector2(0, 275), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle1 >= 30 : " + (_angle1 >= 30) + " | " + _angle1.Degrees + ">=" + _angle1.Degrees + (_angle1.Degrees >= 30), new Vector2(0, 300), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle1 >= Angle2 : " + (_angle1 >= _angle2) + " | " + _angle1.Degrees + ">=" + _angle2.Degrees + (_angle1.Degrees == _angle2.Degrees), new Vector2(0, 325), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle2 < Angle1 : " + (_angle2 < _angle1) + " | " + _angle2.Degrees + "<" + _angle1.Degrees + (_angle2.Degrees < _angle1.Degrees), new Vector2(0, 350), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle2 > Angle1 : " + (_angle2 > _angle1) + " | " + _angle2.Degrees + ">" + _angle1.Degrees + (_angle2.Degrees > _angle1.Degrees), new Vector2(0, 375), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "float Angle1Degree = Angle1 : " + _angle1Degree, new Vector2(0, 400), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Angle3 = 61.5f : " + _angle3, new Vector2(0, 425), Color.Black);


            _spriteBatch.End();
            // TODO: Add your drawing code here
            
            base.Draw(gameTime);
        }
    }
}
