using System;
using System.Collections.Generic;
using System.IO;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Implementation.zLoaders
{
    public class SpriteLoader : IContentLoader
    {
        private const string SpriteContentFolder = "Content/";
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
            

            LoadSprites();
            LoadCursors();
        }

        public void LoadCursors()
        {
            //TODO : Load all cursors from Content/CURSORS by finding all files
            /*//TODO : Load all cursors from Content/CURSORS by finding all files
            DirectoryInfo dirInfo = new DirectoryInfo(SpriteContentFolder+"Sprites/Cursors/");
            foreach (FileInfo file in dirInfo.EnumerateFiles())
            {
                if(file.Extension == "xnb")
                    LoadCursor(file.Name.Replace(".xnb",""));
            }*/

            LoadCursor("Cursor1");
            LoadCursor("Cursor2");
        }

        public void LoadSprites()
        {
            LoadSprite("SpriteTest");
            LoadParticle("dustParticle");
            LoadMonsters();
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

        public void LoadMonster(string monster)
        {
            DirectoryInfo d = new DirectoryInfo(SpriteContentFolder+"Sprites/Monsters/"+monster+"/");
            IEnumerable<FileInfo> d2 = d.EnumerateFiles();
            foreach (FileInfo file in d2)
            {
                if (file.Extension == ".png")
                {
                    Texture2D texture2D = _contentManager.Load<Texture2D>("Sprites/Monsters/"+monster+"/"+file.Name.Replace(file.Extension,""));
                    _spriteDrawer.AddContent(file.Name.Replace(file.Extension,""), texture2D);
                }
            }
        }

        public void LoadMonsters()
        {
            DirectoryInfo mainDirectory = new DirectoryInfo(SpriteContentFolder + "Sprites/Monsters/");
            foreach (DirectoryInfo monsterDirectory in mainDirectory.EnumerateDirectories())
            {
                LoadMonster(monsterDirectory.Name);
            }
        }

        public void LoadCursor(string cursorName)
        {
            Texture2D texture2D = _contentManager.Load<Texture2D>("Sprites/Cursors/"+cursorName);
            _spriteDrawer.AddContent(cursorName, texture2D);
        }
    }
}
