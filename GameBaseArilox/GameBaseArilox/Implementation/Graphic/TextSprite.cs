using System.Collections.Generic;
using GameBaseArilox.API.Effects;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Implementation.Graphic
{
    struct TextSprite : ITextSprite
    {
        public Point ScreenPosition { get; set; }
        public string FontName { get; set; }
        public string Text { get; set; }
        public ITextSpriteAnimation Animation { get; set; }
        public Color Color { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public Vector2 Scale { get; set; }
        public float Depth { get; set; }
        public float Opacity { get; set; }
        public void AddEffect(IDrawableEffectOverTime effectOverTime)
        {
            Effects.Add(effectOverTime);
        }

        public SpriteEffects SpriteEffect { get; set; }
        public Vector2 Position { get; set; }
        public List<IDrawableEffectOverTime> Effects { get; set; }
        public bool Visible { get; set; }
        public string CurrentAnimation { get; set; }
        public int CurrentFrame { get; set; }

        public TextSprite(Point screenPosition, string text)
        {
            Position = screenPosition.ToVector2();
            FontName = "Arial12";
            ScreenPosition = screenPosition;
            Text = text;
            Animation = null;
            Color = Color.Black;
            Rotation = 0f;
            Origin = Vector2.Zero;
            Scale = Vector2.One;
            Depth = 0;
            Opacity = 1f;
            SpriteEffect = SpriteEffects.None;
            Effects = new List<IDrawableEffectOverTime>();
            Visible = true;
            CurrentAnimation = null;
            CurrentFrame = 0;
        }

        public TextSprite(Point screenPosition, string text, GameModel game) : this(screenPosition, text)
        {
            game.AddDrawable(this);
        }
    }
}
