using System.Collections.Generic;
using GameBaseArilox.API;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Graphic
{
    class Sprite : ISprite
    {
        public Vector2 ScreenPosition => new Vector2(X,Y);
        public float X { get; set; }
        public float Y { get; set; }
        public Texture2D Texture { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float Opacity { get; set; }
        public Vector2 Origin { get; set; }
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; }
        public List<ISpriteAnimation> Animations { get; set; }

        public Sprite()
        {
            X = 0;
            Y = 0;
            Animations = new List<ISpriteAnimation>();
            Origin = new Vector2(X,Y);
            Opacity = 1;
        }
    }
}
