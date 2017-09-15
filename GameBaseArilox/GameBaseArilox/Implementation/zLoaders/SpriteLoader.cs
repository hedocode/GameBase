using GameBaseArilox.API.Core;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Implementation.zLoaders
{
    public class SpriteLoader : IContentLoader
    {
        //private const string SpriteContentFolder = "Content/SPRITES";
        private readonly ContentManager _contentManager;

        private readonly IDrawer _spriteDrawer;

        public SpriteLoader(GameModel game, ContentManager contentManager, IDrawer spriteDrawer)
        {
            _contentManager = contentManager;
            _contentManager.RootDirectory = "Content";
            _spriteDrawer = spriteDrawer;
            game.AddToContentLoader(this);
        }

        public void LoadContent()
        {
            //TODO : Load all cursors from Content/CURSORS by finding all files
            //TODO : Load all Sprites Textures from Content/SPRITES by finding all files
            /*
            string[] ContentDirectories = new string[Directory.GetDirectories(SpriteContentFolder).Length];
            ContentDirectories = Directory.GetDirectories(SpriteContentFolder);
            foreach (string path in ContentDirectories)
            {
                foreach (string subPath in Directory.GetDirectories(path))
                {
                    
                }
            }*/
            LoadSprites();
            LoadCursors();
        }

        public void LoadCursors()
        {
            //TODO : Load all cursors from Content/CURSORS by finding all files
            LoadCursor("Cursor1");
            LoadCursor("Cursor2");
        }

        public void LoadSprites()
        {
            LoadSprite("SpriteTest");
            LoadParticle("dustParticle");
        }

        public void LoadParticle(string particle)
        {
            Texture2D texture2D = _contentManager.Load<Texture2D>("Sprites/Particles/" + particle);
            _spriteDrawer.AddContent(particle, texture2D);
        }

        public void LoadSprite(string spriteName)
        {
            Texture2D texture2D = _contentManager.Load<Texture2D>("Sprites/"+spriteName);
            _spriteDrawer.AddContent(spriteName, texture2D);
        }

        public void LoadCursor(string cursorName)
        {
            Texture2D texture2D = _contentManager.Load<Texture2D>("Sprites/Cursors/"+cursorName);
            _spriteDrawer.AddContent(cursorName, texture2D);
        }
    }
}
