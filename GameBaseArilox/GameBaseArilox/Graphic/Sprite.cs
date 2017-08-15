using System.Collections.Generic;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Graphic
{
    class Sprite : ISprite
    {
        public Vector2 ScreenPosition
        {
            get
            {
                return new Vector2(X,Y);
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public float X { get; set; }
        public float Y { get; set; }
        public string TextureId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle TextureSourceRectangle { get; set; }
        public float Opacity { get; set; }
        public Vector2 Origin { get; set; }
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; }
        public SpriteEffects SpriteEffect { get; set; }
        public List<ISpriteAnimation> Animations { get; set; }
        public ISpriteAnimation CurrentAnimation { get; set; }
        public List<ISpriteEffect> Effects { get; set; }

        public Sprite(string textureId)
        {
            TextureId = textureId;
            SpriteEffect = SpriteEffects.None;
            CurrentAnimation = null;
            Effects = new List<ISpriteEffect>();
            Opacity = 1;
            Scale = new Vector2(1,1);
        }

        public Sprite(int x, int y, string textureId) : this(textureId)
        {
            X = x;
            Y = y;
        }

        public Sprite(int x, int y, int width, int height, string textureId) : this(x,y,textureId)
        {
            Width = width;
            Height = height;
            TextureSourceRectangle = new Rectangle(0, 0, 64, 64);
            Origin = new Vector2(Width / 2f, Height / 2f);
        }
    }
}
