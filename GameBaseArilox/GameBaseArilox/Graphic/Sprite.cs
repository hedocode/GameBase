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
        public List<ISpriteEffect> Animations { get; set; }

        public void AfterLoad()
        {
            Origin = new Vector2(Texture.Width/2f,Texture.Height/2f);
            Width = Texture.Width;
            Height = Texture.Height;
        }

        public Sprite()
        {
            X = 100;
            Y = 100;
            Animations = new List<ISpriteEffect>();
            Opacity = 1;
            Scale = new Vector2(1,1);
        }

        public Sprite(int x, int y)
        {
            X = x;
            Y = y;
            Animations = new List<ISpriteEffect>();
            Opacity = 1;
            Scale = new Vector2(1, 1);
        }
    }
}
