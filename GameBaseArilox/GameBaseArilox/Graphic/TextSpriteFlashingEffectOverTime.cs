using GameBaseArilox.API.Core;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;
using IDrawable = GameBaseArilox.API.Graphic.IDrawable;

namespace GameBaseArilox.Graphic
{
    class TextSpriteFlashingEffectOverTime : IDrawableEffectOverTime
    {
          /*------------*/
         /* ATTRIBUTES */
        /*------------*/
        private float _speed;
        private bool _increase;

          /*------------*/
         /* PROPERTIES */
        /*------------*/
        public float Duration { get; set; }
        public float TimeSpent { get; set; }
        public float Speed { get { return _speed; } set { _speed = value; } }

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

        public void Reset()
        {
            AffectedDrawable.Opacity = 1;
            AffectedDrawable.Rotation = 0;
            AffectedDrawable.Scale = new Vector2(1, 1);
            AffectedDrawable.CurrentFrame = 1;
            AffectedDrawable.CurrentAnimation = null;
        }

        public IDrawable AffectedDrawable { get; set; }

        /*-------------*/
        /* CONSTRUCTOR */
        /*-------------*/
        public TextSpriteFlashingEffectOverTime(int speed, ITextSprite textTextSprite, float duration = 5)
        {
            Duration = duration;
            TimeSpent = 0;
            _speed = speed;

            AffectedDrawable = textTextSprite;
            textTextSprite.Effects.Add(this);
        }

        public TextSpriteFlashingEffectOverTime(int speed, float duration = 5)
        {
            Duration = duration;
            TimeSpent = 0;
            _speed = speed;
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
                _increase = true;
            }
            else if (AffectedDrawable.Opacity >= 1)
            {
                _increase = false;
            }
            if (_increase)
            {
                AffectedDrawable.Opacity += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                AffectedDrawable.Scale -= new Vector2(0.1f, 0.1f);
            }
            else
            {
                AffectedDrawable.Opacity -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                AffectedDrawable.Scale += new Vector2(0.1f, 0.1f);
            }
            AffectedDrawable.Rotation += (float)(1 * gameTime.ElapsedGameTime.TotalSeconds);
            TimeSpent += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}