using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Environment;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Graphic
{
    struct TextSprite : ITextSprite
    {
        public Point ScreenPosition { get; set; }
        public string FontName { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public Vector2 Scale { get; set; }
        public float Depth { get; set; }
        public float Opacity { get; set; }
        public double TimeSpent { get; set; }
        public SpriteEffects SpriteEffect { get; set; }

        public Vector2 Position { get; set; }
        public List<IEffect> Effects { get; set; }
        public bool Increase { get; set; }
        public bool Visible { get; set; }

        public TextSprite(Point screenPosition, string text)
        {
            Position = screenPosition.ToVector2();
            FontName = "Arial12";
            ScreenPosition = screenPosition;
            Text = text;
            Color = Color.Black;
            Rotation = 0f;
            Origin = Vector2.Zero;
            Scale = Vector2.One;
            Depth = 0;
            Opacity = 1f;
            TimeSpent = 0;
            SpriteEffect = SpriteEffects.None;
            Effects = new List<IEffect>();
            Increase = false;
            Visible = true;
        }

    }
}
