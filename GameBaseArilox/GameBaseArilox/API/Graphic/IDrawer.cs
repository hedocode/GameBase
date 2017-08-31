using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.API.Graphic
{
    public interface IDrawer
    {
        void AddContent(string textureId, object content);
        void DrawAll(SpriteBatch spriteBatch);
    }
}
