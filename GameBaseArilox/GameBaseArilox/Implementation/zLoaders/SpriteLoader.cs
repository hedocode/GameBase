using GameBaseArilox.API.Core;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Implementation.zLoaders
{
    public class SpriteLoader : IContentLoader
    {
        private const string SpriteContentFolder = "Content/SPRITES";
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
            /*
            string[] ContentDirectories = new string[Directory.GetDirectories(SpriteContentFolder).Length];
            ContentDirectories = Directory.GetDirectories(SpriteContentFolder);
            foreach (string path in ContentDirectories)
            {
                foreach (string subPath in Directory.GetDirectories(path))
                {
                    
                }
            }*/
            LoadSpriteTest();
            LoadCursor1();
        }

        public void LoadSpriteTest()
        {
            Texture2D texture2D = _contentManager.Load<Texture2D>("SPRITES/SpriteTest");
            _spriteDrawer.AddContent("SpriteTest", texture2D);
        }

        public void LoadCursor1()
        {
            Texture2D texture2D = _contentManager.Load<Texture2D>("CURSORS/Cursor1/Cursor1");
            _spriteDrawer.AddContent("Cursor1", texture2D);
        }
    }
}
