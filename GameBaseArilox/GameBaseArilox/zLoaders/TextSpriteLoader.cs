using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.zLoaders
{
    class TextSpriteLoader
    {
        private IDrawer _textSpriteDrawer;
        private ContentManager _contentManager;


        public TextSpriteLoader(ContentManager contentManager, IDrawer textSpriteDrawer)
        {
            _contentManager = contentManager;
            _textSpriteDrawer = textSpriteDrawer;
        }


        public void LoadArial12()
        {
            _textSpriteDrawer.AddContent("Arial12", _contentManager.Load<SpriteFont>("FONTS/Arial12"));
        }
    }
}
