using GameBaseArilox.API;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Environment
{
    class FlashingAnimation : ISpriteAnimation
    {
        private readonly int _speed;
        private bool _increase;
        public float Duration { get; set; }
        public float TimeSpent { get; set; }
        public void Animate(GameTime gameTime)
        {
            if (AnimatedSprite.Opacity <= 0)
            {
                _increase = true;
            }
            else if (AnimatedSprite.Opacity >= 1)
            {
                _increase = false;
            }
            if (_increase)
            {
                AnimatedSprite.Opacity += _speed*(float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                AnimatedSprite.Opacity -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            TimeSpent += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public ISprite AnimatedSprite { get; set; }

        public FlashingAnimation(int speed, ISprite sprite)
        {
            Duration = 5;
            TimeSpent = 0;
            _speed = speed;
            AnimatedSprite = sprite;
            sprite.Animations.Add(this);
        }
    }
}
