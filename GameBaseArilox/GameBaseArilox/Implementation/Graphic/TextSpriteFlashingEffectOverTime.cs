using System;
using GameBaseArilox.API.Effects;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;
using IDrawable = GameBaseArilox.API.Graphic.IDrawable;

namespace GameBaseArilox.Implementation.Graphic
{
    class TextSpriteFlashingEffectOverTime : IDrawableEffectOverTime
    {
          /*------------*/
         /* ATTRIBUTES */
        /*------------*/
        private float _frequency;

          /*------------*/
         /* PROPERTIES */
        /*------------*/
        public float Duration { get; set; }
        public double ElapsedLifeTime { get; set; }
        public bool Increase { get; set; }
        public float Frequency { get { return _frequency; } set { _frequency = value; } }

        public object AffectedObject
        {
            get { return AffectedDrawable; }
            set
            {
                IDrawable textSprite = value as IDrawable;
                if (textSprite != null)
                {
                    AffectedDrawable = textSprite;
                }
            }
        }

        public object BaseObject { get; }

        public void Reset()
        {
            IDrawable drawable = (IDrawable)BaseObject;
            if(drawable == null) { throw new InvalidCastException("ERROR : CAST FROM OBJECT TO IDRAWABLE FAILED");}
            AffectedDrawable.Opacity = drawable.Opacity;
            AffectedDrawable.Rotation = drawable.Rotation;
            AffectedDrawable.Scale = drawable.Scale;
            AffectedDrawable.CurrentFrame = drawable.CurrentFrame;
            AffectedDrawable.CurrentAnimation = drawable.CurrentAnimation;
        }

        public IDrawable AffectedDrawable { get; set; }

        /*-------------*/
        /* CONSTRUCTOR */
        /*-------------*/
        public TextSpriteFlashingEffectOverTime(int frequency, ITextSprite textTextSprite, float duration = 5)
        {
            Duration = duration;
            ElapsedLifeTime = 0;
            _frequency = frequency;

            AffectedDrawable = textTextSprite;
            textTextSprite.Effects.Add(this);
            BaseObject = new TextSprite(textTextSprite.ScreenPosition,textTextSprite.Text);
        }

        public TextSpriteFlashingEffectOverTime(int frequency, float duration = 5)
        {
            Duration = duration;
            ElapsedLifeTime = 0;
            _frequency = frequency;
        }



          /*------------*/
         /*   METHODS  */
        /*------------*/
        public void SetDrawable(IDrawable drawable)
        {
            AffectedDrawable = drawable;
            drawable.Effects.Add(this);
        }

        public void Affect(GameTime gameTime)
        {
            if (AffectedDrawable.Opacity <= 0)
            {
                Increase = true;
            }
            else if (AffectedDrawable.Opacity >= 1)
            {
                Increase = false;
            }
            if (Increase)
            {
                AffectedDrawable.Opacity += _frequency * (float)gameTime.ElapsedGameTime.TotalSeconds;
                AffectedDrawable.Scale -= new Vector2(0.1f, 0.1f);
            }
            else
            {
                AffectedDrawable.Opacity -= _frequency * (float)gameTime.ElapsedGameTime.TotalSeconds;
                AffectedDrawable.Scale += new Vector2(0.1f, 0.1f);
            }
            AffectedDrawable.Rotation += (float)(1 * gameTime.ElapsedGameTime.TotalSeconds);
            ElapsedLifeTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}