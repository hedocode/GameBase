using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Graphic
{
    struct Sprite : ISprite
    {

          /*------------*/
         /* PROPERTIES */
        /*------------*/
        public float X { get; set; }
        public float Y { get; set; }
        public string TextureId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle TextureSourceRectangle { get; set; }
        public float Opacity { get; set; }
        public Vector2 Origin { get; set; }
        public float Depth { get; set; }
        public Color Color { get; set; }
        public double TimeSpent { get; set; }
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; }
        public SpriteEffects SpriteEffect { get; set; }
        public string CurrentAnimation { get; set; }
        public int CurrentFrame { get; set; }
        public bool Increase { get; set; }
        public List<IDrawableEffectOverTime> Effects { get; set; }
        public bool Visible { get; set; }
        public Point ScreenPosition
        {
            get { return new Point((int)X, (int)Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }
        public Vector2 Position
        {
            get
            {
                return new Vector2(X, Y);
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

          /*--------------*/
         /* CONSTRUCTORS */
        /*--------------*/
        public Sprite(string textureId)
        {
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;
            TextureSourceRectangle = new Rectangle(0, 0, 0, 0);
            Origin = new Vector2(0, 0);
            Rotation = 0f;
            SpriteEffect = SpriteEffects.None;
            CurrentAnimation = null;
            Effects = new List<IDrawableEffectOverTime>();
            Opacity = 1.0f;
            Scale = new Vector2(1, 1);
            TextureId = textureId;
            CurrentFrame = 0;
            Increase = true;
            Depth = 1f;
            TimeSpent = 0;
            Visible = true;
            Color = Color.White;
        }

        public Sprite(int x, int y, string textureId) : this(textureId)
        {
            X = x;
            Y = y;
        }

        public Sprite(int x, int y, int width, int height, string textureId) : this(x, y, textureId)
        {
            Width = width;
            Height = height;
            Origin = new Vector2(Width/2f, Height/2f);
        }

        public Sprite(int x, int y, int width, int height, string textureId, Vector2 origin)
            : this(x, y, width, height, textureId)
        {
            Origin = origin;
        }

        public Sprite(int x, int y, int width, int height, string textureId, Vector2 origin, string currentAnimation)
            : this(x, y, width, height, textureId, origin)
        {
            CurrentAnimation = currentAnimation;
        }

        public Sprite(int x, int y, int width, int height, string textureId, Vector2 origin, string currentAnimation,
            float depth) : this(x, y, width, height, textureId, origin, currentAnimation)
        {
            Depth = depth;
        }


          /*------------*/
          /*   METHODS  */
          /*------------*/
        public void AddEffect(IDrawableEffectOverTime effectOverTime)
        {
            effectOverTime.SetDrawable(this);
        }

        public void AddFlashingEffect(DrawableFlashingEffectOverTime effect)
        {
            effect.SetDrawable(this);
        }
    }
}
