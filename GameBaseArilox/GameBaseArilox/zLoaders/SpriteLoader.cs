using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using GameBaseArilox.API.Graphic;

namespace GameBaseArilox.zLoaders
{
    class SpriteLoader
    {
        private const string SpriteContentFolder = "Content/SPRITES";
        private readonly ContentManager _contentManager;

        private IDrawer _spriteDrawer;

        public SpriteLoader(ContentManager contentManager, IDrawer spriteDrawer)
        {
            _contentManager = contentManager;
            _spriteDrawer = spriteDrawer;
        }

        public void LoadAllTextures()
        {
            string[] ContentDirectories = new string[Directory.GetDirectories(SpriteContentFolder).Length];
            ContentDirectories = Directory.GetDirectories(SpriteContentFolder);
            foreach (string path in ContentDirectories)
            {
                foreach (string subPath in Directory.GetDirectories(path))
                {
                    
                }
            }
        }

        public void LoadSpriteTest()
        {
            _spriteDrawer.AddContent("SpriteTest",_contentManager.Load<Texture2D>("SPRITES/SpriteTest"));
        }

        public void LoadCursor1()
        {
            _spriteDrawer.AddContent("Cursor1",_contentManager.Load<Texture2D>("CURSORS/Cursor1/Cursor1"));
        }
    }
}
