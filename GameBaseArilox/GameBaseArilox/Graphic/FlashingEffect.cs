using GameBaseArilox.API;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Graphic
{ 
    class FlashingEffect : ISpriteEffect
    {
        private readonly int _speed;
        private bool _increase;
        public float Duration { get; set; }
        public float TimeSpent { get; set; }
        public void Affect(GameTime gameTime)
        {
            if (AffectedSprite.Opacity <= 0)
            {
                _increase = true;
            }
            else if (AffectedSprite.Opacity >= 1)
            {
                _increase = false;
            }
            if (_increase)
            {
                AffectedSprite.Opacity += _speed*(float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                AffectedSprite.Opacity -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            AffectedSprite.Rotation += (float)(1 * gameTime.ElapsedGameTime.TotalSeconds);
            TimeSpent += (float)gameTime.ElapsedGameTime.TotalSeconds;

        }

        public ISprite AffectedSprite { get; set; }

        public FlashingEffect(int speed, ISprite sprite)
        {
            Duration = 5;
            TimeSpent = 0;
            _speed = speed;
            AffectedSprite = sprite;
            sprite.Animations.Add(this);
        }
    }
}
