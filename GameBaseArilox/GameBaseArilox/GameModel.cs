using System.Collections.Generic;
using GameBaseArilox.API.Core;
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
        protected GraphicsDeviceManager Graphics;
        protected SpriteBatch SpriteBatch;
        protected SpriteFont SpriteFont;

        public readonly InputsManager InputsManager;

        protected readonly SpriteDrawer SpriteDrawer;
        protected readonly TextSpriteDrawer TextSpriteDrawer;
        protected ShapeDrawer ShapeDrawer;

        protected readonly SpriteUpdater SpriteUpdater;
        protected CursorUpdater CursorUpdater;
        protected readonly TextSpriteUpdater TextSpriteUpdater;
        protected GeneratorUpdater GeneratorUpdater;

        protected readonly TextSpriteLoader TextSpriteLoader;
        protected readonly SpriteLoader SpriteLoader;
        protected ShapeLoader ShapeLoader;

        public Camera2D Camera;


        protected Cursor Cursor;

        protected List<IDrawer> Drawers = new List<IDrawer>();
        protected List<IUpdater> Updaters = new List<IUpdater>();
        protected List<IContentLoader> ContentLoaders = new List<IContentLoader>();

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
            
            // TODO: use this.Content to load your game content here
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            foreach (IUpdater updater in Updaters)
                updater.Update(gameTime);


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

            SpriteBatch.Begin(SpriteSortMode.BackToFront);

            foreach (IDrawer drawer in Drawers)
            {
                drawer.DrawAll(SpriteBatch);
            }

            SpriteBatch.DrawString(SpriteFont, Cursor.ScreenPosition.ToString(), Vector2.Zero, Color.Orange);
            SpriteBatch.End();
            // TODO: Add your drawing code here

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
