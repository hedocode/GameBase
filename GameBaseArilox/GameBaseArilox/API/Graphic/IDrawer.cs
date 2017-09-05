using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.API.Graphic
{
    public interface IDrawer
    {
        void AddContent(string contentId, object content);
        void DrawAll(SpriteBatch spriteBatch);
    }
}
