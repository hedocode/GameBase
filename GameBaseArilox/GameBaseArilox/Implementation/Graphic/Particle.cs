using System.Collections.Generic;
using GameBaseArilox.API.Effects;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Implementation.Graphic
{
    public class Particle : ISprite, IEffectOverTime
    {
        public Point ScreenPosition { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Rotation { get; set; }
        public List<IDrawableEffectOverTime> Effects { get; set; }
        public void AddEffect(IDrawableEffectOverTime effectOverTime)
        {
            throw new System.NotImplementedException();
        }

        public string CurrentAnimation { get; set; }
        public int CurrentFrame { get; set; }
        public bool Visible { get; set; }
        public float Opacity { get; set; }
        public Vector2 Origin { get; set; }
        public float Depth { get; set; }
        public Color Color { get; set; }
        public SpriteEffects SpriteEffect { get; set; }
        public double TimeSpent { get; set; }
        public bool Increase { get; set; }
        public string TextureId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle TextureSourceRectangle { get; set; }
        public float Duration { get; set; }
        public float EffectSpeed { get; set; }
    }
}
