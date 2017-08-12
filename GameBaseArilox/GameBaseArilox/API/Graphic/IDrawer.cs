using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.API.Graphic
{
    public interface IDrawer
    {
        List<ISprite> ToDraw { get; set; }
        void DrawAll(SpriteBatch spriteBatch);
        void Draw(SpriteBatch spriteBatch, ISprite sprite);
    }
}
