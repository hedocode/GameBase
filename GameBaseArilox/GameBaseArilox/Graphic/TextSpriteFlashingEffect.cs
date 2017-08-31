using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Graphic
{
    class TextSpriteFlashingEffect : ITextSpriteEffect
    {
        /*------------*/
        /* ATTRIBUTES */
        /*------------*/
        private readonly int _speed;
        private bool _increase;

        /*------------*/
        /* PROPERTIES */
        /*------------*/
        public float Duration { get; set; }
        public float TimeSpent { get; set; }
        public ITextSprite AffectedTextSprite { get; set; }

        /*-------------*/
        /* CONSTRUCTOR */
        /*-------------*/
        public TextSpriteFlashingEffect(int speed, ITextSprite textTextSprite)
        {
            Duration = 5;
            TimeSpent = 0;
            _speed = speed;
            AffectedTextSprite = textTextSprite;
            textTextSprite.Effects.Add(this);
        }

        /*------------*/
        /*   METHODS  */
        /*------------*/
        public void Affect(GameTime gameTime)
        {
            if (AffectedTextSprite.Opacity <= 0)
            {
                _increase = true;
            }
            else if (AffectedTextSprite.Opacity >= 1)
            {
                _increase = false;
            }
            if (_increase)
            {
                AffectedTextSprite.Opacity += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                AffectedTextSprite.Scale -= new Vector2(0.1f, 0.1f);
            }
            else
            {
                AffectedTextSprite.Opacity -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                AffectedTextSprite.Scale += new Vector2(0.1f, 0.1f);
            }
            AffectedTextSprite.Rotation += (float)(1 * gameTime.ElapsedGameTime.TotalSeconds);
            TimeSpent += (float)gameTime.ElapsedGameTime.TotalSeconds;

        }
    }
}
