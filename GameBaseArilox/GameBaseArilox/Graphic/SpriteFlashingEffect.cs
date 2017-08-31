﻿using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Graphic
{ 
    class SpriteFlashingEffect : ISpriteEffect
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
        public ISprite AffectedSprite { get; set; }

          /*-------------*/
         /* CONSTRUCTOR */
        /*-------------*/
        public SpriteFlashingEffect(int speed, ISprite sprite)
        {
            Duration = 5;
            TimeSpent = 0;
            _speed = speed;
            AffectedSprite = sprite;
            sprite.Effects.Add(this);
        }

          /*------------*/
         /*   METHODS  */
        /*------------*/
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
                AffectedSprite.Opacity += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                AffectedSprite.Scale -= new Vector2(0.1f, 0.1f);
            }
            else
            {
                AffectedSprite.Opacity -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                AffectedSprite.Scale += new Vector2(0.1f, 0.1f);
            }
            AffectedSprite.Rotation += (float)(1 * gameTime.ElapsedGameTime.TotalSeconds);
            TimeSpent += (float)gameTime.ElapsedGameTime.TotalSeconds;

        }

    }
}