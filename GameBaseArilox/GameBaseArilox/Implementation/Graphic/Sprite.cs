using System;
using System.Collections.Generic;
using GameBaseArilox.API.Effects;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Implementation.Graphic
{
    public class Sprite : ISprite
    {
        private float _opacity;
          /*------------*/
         /* PROPERTIES */
        /*------------*/
        public float X { get; set; }
        public float Y { get; set; }
        public string TextureId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle TextureSourceRectangle { get; set; }

        public float Opacity
        {
            get { return _opacity; }
            set
            {
                if (value < 0)
                {
                    _opacity = 0;
                }
                else if (value > 1)
                {
                    _opacity = 1;
                }
                else
                {
                    _opacity = value;
                    Visible = !(Math.Abs(value) < 0.001);
                }
            }
        }

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
            Duration = float.PositiveInfinity;
        }

        public Sprite(float x, float y, string textureId) : this(textureId)
        {
            X = x;
            Y = y;
        }

        public Sprite(float x, float y, int width, int height, string textureId) : this(x, y, textureId)
        {
            Width = width;
            Height = height;
            Origin = new Vector2(Width/2f, Height/2f);
        }

        public Sprite(float x, float y, int width, int height, string textureId, Vector2 origin)
            : this(x, y, width, height, textureId)
        {
            Origin = origin;
        }

        public Sprite(float x, float y, int width, int height, string textureId, Vector2 origin, string currentAnimation)
            : this(x, y, width, height, textureId, origin)
        {
            CurrentAnimation = currentAnimation;
        }

        public Sprite(float x, float y, int width, int height, string textureId, Vector2 origin, string currentAnimation,
            float depth) : this(x, y, width, height, textureId, origin, currentAnimation)
        {
            Depth = depth;
        }


          /*------------*/
          /*   METHODS  */
          /*------------*/
        public void AddEffect(IDrawableEffectOverTime effectOverTime)
        {
            Effects.Add(effectOverTime);
            effectOverTime.SetDrawable(this);
        }

        public float Duration { get; set; }
        public double ElapsedLifeTime { get; set; }
    }
}
