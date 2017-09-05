using GameBaseArilox.API.Core;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Implementation.zLoaders
{
    public class TextSpriteLoader : IContentLoader
    {
        private IDrawer _textSpriteDrawer;
        private ContentManager _contentManager;


        public TextSpriteLoader(GameModel game, ContentManager contentManager, IDrawer textSpriteDrawer)
        {
            _contentManager = contentManager;
            _textSpriteDrawer = textSpriteDrawer;
            game.AddToContentLoader(this);
        }

        public void LoadContent()
        {
            LoadArial12();
        }

        public void LoadArial12()
        {
            _textSpriteDrawer.AddContent("Arial12", _contentManager.Load<SpriteFont>("FONTS/Arial12"));
        }
    }
}
