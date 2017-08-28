using GameBaseArilox.API.Detection;
using GameBaseArilox.API.Environment;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.GUI
{
    class Cursor : IDisplayed, IGameElement
    {
        public ISprite Sprite { get; set; }
        public IDetectionArea Hitbox { get; set; }

        public Vector2 Position
        {
            get
            {
                return new Vector2(_x,_y);
            }
            set
            {
                _x = value.X;
                _y = value.Y;
            }
        }

        private float _x;
        private float _y;
    }
}
