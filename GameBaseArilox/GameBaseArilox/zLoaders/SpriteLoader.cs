using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using GameBaseArilox.zDrawers;

namespace GameBaseArilox.zLoaders
{
    class SpriteLoader
    {
        private const string SpriteContentFolder = "Content/SPRITES";
        private readonly ContentManager _contentManager;

        private SpriteDrawer _spriteDrawer;

        public SpriteLoader(ContentManager contentManager, SpriteDrawer spriteDrawer)
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
            _spriteDrawer.AddTexture2D("SpriteTest",_contentManager.Load<Texture2D>("SPRITES/SpriteTest"));
        }
    }
}
