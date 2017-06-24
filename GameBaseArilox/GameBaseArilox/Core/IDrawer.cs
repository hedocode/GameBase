using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Core
{
    public interface IDrawer
    {
        List<ISprite> ToDraw { get; set; }
        void DrawAll(SpriteBatch spriteBatch);
        void Draw(SpriteBatch spriteBatch, ISprite sprite);
    }
}
