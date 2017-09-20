using System.Collections.Generic;
using System.Diagnostics;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Enums;
using GameBaseArilox.API.Graphic;
using GameBaseArilox.Implementation.Controls;
using GameBaseArilox.Implementation.Core;
using GameBaseArilox.Implementation.GUI;
using GameBaseArilox.Implementation.zDrawers;
using GameBaseArilox.Implementation.zLoaders;
using GameBaseArilox.Implementation.zUpdaters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = GameBaseArilox.API.Graphic.IDrawable;

namespace GameBaseArilox
{
    public abstract class GameModel : Game
    {
        //GameStates
        private GameStateType _oldGameState;
        private GameStateType _currentGameState;

        //StopWatch Update / Draw execution times
        private float _deltaTimeUpdate;
        private float _deltaTimeDraw;

        protected GraphicsDeviceManager Graphics;
        protected SpriteBatch SpriteBatch;
        protected SpriteFont SpriteFont;

        public readonly InputsManager InputsManager;

        //Drawers
        protected List<IDrawer> Drawers = new List<IDrawer>();
        public readonly SpriteDrawer SpriteDrawer;
        protected readonly TextSpriteDrawer TextSpriteDrawer;
        protected ShapeDrawer ShapeDrawer;

        //Updaters
        protected List<IUpdater> Updaters = new List<IUpdater>();
        protected readonly SpriteUpdater SpriteUpdater;
        protected CursorUpdater CursorUpdater;
        protected readonly TextSpriteUpdater TextSpriteUpdater;
        protected GeneratorUpdater GeneratorUpdater;

        //Loaders
        protected List<IContentLoader> ContentLoaders = new List<IContentLoader>();
        protected readonly TextSpriteLoader TextSpriteLoader;
        protected readonly SpriteLoader SpriteLoader;
        protected ShapeLoader ShapeLoader;

        public Camera2D Camera;
        protected Cursor Cursor;

        // Window size Properties.
        public int WindowWidth
        {
            get { return Graphics.GraphicsDevice.Viewport.Width; }
            set { Graphics.PreferredBackBufferWidth = value; Graphics.ApplyChanges(); }
        }

        public int WindowHeight
        {
            get { return Graphics.GraphicsDevice.Viewport.Height; }
            set { Graphics.PreferredBackBufferHeight = value; Graphics.ApplyChanges(); }
        }


        //Screen size Properties.
        public int ScreenWidth => GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public int ScreenHeight => GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        protected GameModel()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            SpriteDrawer = new SpriteDrawer(this);
            SpriteUpdater = new SpriteUpdater(this);
            SpriteLoader = new SpriteLoader(this, Content, SpriteDrawer);
            InputsManager = new InputsManager(this);
            TextSpriteDrawer = new TextSpriteDrawer(this);
            TextSpriteUpdater = new TextSpriteUpdater(this);
            TextSpriteLoader = new TextSpriteLoader(this,Content,TextSpriteDrawer);
            GeneratorUpdater = new GeneratorUpdater(this);
            Cursor = new Cursor(this);
            ShapeDrawer = new ShapeDrawer(this);
            _currentGameState = GameStateType.Game;
        }

        protected override void Initialize()
        {
            CursorUpdater = new CursorUpdater(this, Cursor, InputsManager.MouseInput);
            ShapeLoader = new ShapeLoader(this, Content, ShapeDrawer);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Camera = new Camera2D(GraphicsDevice.Viewport, null, null);
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFont = Content.Load<SpriteFont>("FONTS/Arial12");

            foreach (IContentLoader contentLoader in ContentLoaders)
            {
                contentLoader.LoadContent();
            }
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            switch (_currentGameState)
            {
                case GameStateType.Menu:
                    InputsManager.UpdateMenu(gameTime);
                    break;
                case GameStateType.Cinematics:
                    InputsManager.UpdateCinematic(gameTime);
                    break;
                case GameStateType.Game:
                    foreach (IUpdater updater in Updaters)
                        updater.Update(gameTime);
                    break;
                case GameStateType.DeveloperConsole:
                    InputsManager.KeyboardInput.GetPressedKeys();
                    break;


            }

            sw.Stop();
            _deltaTimeUpdate = (float)sw.Elapsed.TotalSeconds;

            Window.Title = $"Update : {_deltaTimeUpdate} - Draw : {_deltaTimeDraw}";
            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin(SpriteSortMode.BackToFront);

            foreach (IDrawer drawer in Drawers)
            {
                drawer.DrawAll(SpriteBatch);
            }

            SpriteBatch.DrawString(SpriteFont, Cursor.ScreenPosition.ToString(), Vector2.Zero, Color.Orange);
            SpriteBatch.End();
            sw.Stop();
            _deltaTimeDraw = (float)sw.Elapsed.TotalSeconds;
            
            base.Draw(gameTime);
        }

        public void AddToUpdaters(IUpdater updater)
        {
            Updaters.Add(updater);
        }

        public void AddToDrawers(IDrawer drawer)
        {
            Drawers.Add(drawer);
        }

        public void AddToContentLoader(IContentLoader contentLoader)
        {
            ContentLoaders.Add(contentLoader);
        }

        public void AddDrawable(IDrawable drawable)
        {
            ISprite sprite = drawable as ISprite;
            if (sprite != null)
            {
                SpriteDrawer.AddSprite(sprite);
                SpriteUpdater.AddToUpdate(sprite);
            }

            ITextSprite textSprite = drawable as ITextSprite;
            if (textSprite != null)
            {
                TextSpriteDrawer.AddTextSprite(textSprite);
                TextSpriteUpdater.AddToUpdate(textSprite);
            }
        }
    }
}
