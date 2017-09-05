using GameBaseArilox.API.Core;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Implementation.zLoaders
{
    public class ShapeLoader : IContentLoader
    {
        private readonly ContentManager _contentManager;

        private GraphicsDevice _graphics;

        private readonly IDrawer _shapeDrawer;

        public ShapeLoader(GameModel game, ContentManager contentManager, IDrawer shapeDrawer)
        {
            _contentManager = contentManager;
            _shapeDrawer = shapeDrawer;
            _graphics = game.GraphicsDevice;
            game.AddToContentLoader(this);
        }

        public void LoadContent()
        {
            LoadSegmentTexture();
            LoadPointTexture();
        }

        public void LoadPointTexture()
        {
            Texture2D pointTexture = new Texture2D(_graphics,3,3);
            pointTexture.SetData(new[]
            {
                Color.White*0,Color.Red, Color.White*0,
                Color.Red, Color.Red, Color.Red,
                Color.White*0, Color.Red, Color.White*0
            });

            _shapeDrawer.AddContent("PointTexture",pointTexture);
        }

        public void LoadSegmentTexture()
        {
            Texture2D pointTexture = new Texture2D(_graphics, 1, 1);
            pointTexture.SetData(new[]
            {
                Color.Black
            });

            _shapeDrawer.AddContent("SegmentTexture", pointTexture);
        }
    }
}
