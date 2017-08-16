using System.Collections.Generic;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Graphic
{
    public struct SpriteAnimation : ISpriteAnimation
    {
        public float Duration { get; set; }
        public float TimeSpent { get; set; }

        public void Affect(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public string Name { get; set; }
        public List<Rectangle> AnimationsTextures { get; set; }
        public float Speed { get; set; }
        public bool IsSeesaw { get; set; }

        public SpriteAnimation(string name)
        {
            Duration = 0;
            TimeSpent = 0;
            Name = name;
            AnimationsTextures = new List<Rectangle>();
            Speed = 1;
            IsSeesaw = true;
        }
    }
}
