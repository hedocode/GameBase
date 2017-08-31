using GameBaseArilox.API.Core;
using Microsoft.Xna.Framework;
using IDrawable = GameBaseArilox.API.Graphic.IDrawable;

namespace GameBaseArilox.Graphic
{ 
    class DrawableFlashingEffectOverTime : IDrawableEffectOverTime
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
        public IDrawable AffectedDrawable { get; set; }
       

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

        public void Reset()
        {
            AffectedDrawable.Opacity = 1;
            AffectedDrawable.Rotation = 0;
            AffectedDrawable.Scale = new Vector2(1, 1);
            AffectedDrawable.CurrentFrame = 1;
            AffectedDrawable.CurrentAnimation = null;
        }

          /*-------------*/
         /* CONSTRUCTOR */
        /*-------------*/
        public DrawableFlashingEffectOverTime(int speed, IDrawable drawable, float duration = 5)
        {
            Duration = duration;
            TimeSpent = 0;
            _speed = speed;
            SetDrawable(drawable);
        }

        public DrawableFlashingEffectOverTime(int speed, float duration = 5)
        {
            Duration = duration;
            TimeSpent = 0;
            _speed = speed;
        }

        public void SetDrawable(IDrawable drawable)
        {
            AffectedDrawable = drawable;
            drawable.Effects.Add(this);
        }

          /*------------*/
         /*   METHODS  */
        /*------------*/
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
