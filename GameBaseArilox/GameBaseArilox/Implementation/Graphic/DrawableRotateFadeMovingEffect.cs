using System;
using GameBaseArilox.API.Effects;
using GameBaseArilox.Implementation.Shapes;
using Microsoft.Xna.Framework;
using IDrawable = GameBaseArilox.API.Graphic.IDrawable;

namespace GameBaseArilox.Implementation.Graphic
{
    public class DrawableRotateFadeMovingEffect : IDrawableEffectOverTime
    {
        private Vector2 _velocity;
        public float Duration { get; set; }
        public float EffectSpeed { get; set; }

        public object AffectedObject
        {
            get
            {
                return AffectedDrawable;
            }
            set
            {
                IDrawable sprite = value as IDrawable;
                if (sprite != null)
                {
                    AffectedDrawable = sprite;
                }
            }
        }
        public object BaseObject { get; }
        public double TimeSpent { get; set; }
        public bool Increase { get; set; }
        public IDrawable AffectedDrawable { get; set; }
        public void SetDrawable(IDrawable drawable)
        {
            AffectedDrawable = drawable;
            drawable.Effects.Add(this);
        }

        public void Reset()
        {
            IDrawable drawable = (IDrawable)BaseObject;
            if (drawable == null) { throw new InvalidCastException("ERROR : CAST FROM OBJECT TO IDRAWABLE FAILED"); }
            AffectedDrawable.Opacity = drawable.Opacity;
            AffectedDrawable.Rotation = drawable.Rotation;
            AffectedDrawable.Scale = drawable.Scale;
            AffectedDrawable.CurrentFrame = drawable.CurrentFrame;
            AffectedDrawable.CurrentAnimation = drawable.CurrentAnimation;
        }

        /*-------------*/
        /* CONSTRUCTOR */
        /*-------------*/
        public DrawableRotateFadeMovingEffect(int animationEffectSpeed, IDrawable drawable, float duration, float velocity, Angle direction)
        {
            Duration = duration;
            TimeSpent = 0;
            EffectSpeed = animationEffectSpeed;
            SetDrawable(drawable);
            BaseObject = drawable;
            _velocity = direction.GetVector(velocity);
        }

        public DrawableRotateFadeMovingEffect(int effectSpeed, float duration = 5)
        {
            Duration = duration;
            TimeSpent = 0;
            EffectSpeed = effectSpeed;
        }

        /*------------*/
        /*   METHODS  */
        /*------------*/
        public void Affect(GameTime gameTime)
        {
            AffectedDrawable.Position += _velocity*(float)gameTime.ElapsedGameTime.TotalSeconds;
            if (TimeSpent <= EffectSpeed)
            {
                AffectedDrawable.Opacity -= 1/Duration;
                AffectedDrawable.Rotation += 0.01f;
                TimeSpent = 0;
            }
            TimeSpent += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
