using System;
using System.Collections.Generic;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Graphic
{
    public struct SpriteAnimation : ISpriteAnimation
    {
          /*------------*/
         /* PROPERTIES */
        /*------------*/
        public string TargetContentId { get; set; }
        public float Duration { get; set; }
        public double ElapsedLifeTime { get; set; }
        public string Name { get; set; }
        public List<Rectangle> AnimationsTextures { get; set; }
        public float Frequency { get; set; }

        public bool IsSeesaw { get; set; }
        public object AffectedObject { get; set; }

        /*-------------*/
        /* CONSTRUCTOR */
        /*-------------*/
        public SpriteAnimation(string name, List<Rectangle> animation)
        {
            TargetContentId = "SpriteTest";
            Duration = 0;
            Name = name;
            AnimationsTextures = animation;
            Frequency = 1;
            IsSeesaw = true;
            AffectedObject = null;
            ElapsedLifeTime = 0;
        }

        public SpriteAnimation(string name, string id, List<Rectangle> animation) : this(name,animation)
        {
            TargetContentId = id;
        }

        public SpriteAnimation(string name, string id, List<Rectangle> animation, float frequency) : this(name, id, animation)
        {
            Frequency = frequency;
        }

        public SpriteAnimation(string name, string id, List<Rectangle> animation, float frequency, bool isSeesaw) : this(name, id, animation, frequency)
        {
            IsSeesaw = isSeesaw;
        }

        /*------------*/
        /*   METHODS  */
        /*------------*/
        public void Affect(GameTime gameTime)
        {
            throw new NotImplementedException("Not used inherited Method");
        }
    }
}
