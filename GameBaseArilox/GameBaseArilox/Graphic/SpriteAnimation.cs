using System;
using System.Collections.Generic;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Graphic
{
    public struct SpriteAnimation : ISpriteAnimation
    {
          /*------------*/
         /* PROPERTIES */
        /*------------*/
        public string TargetContentId { get; set; }
        public float Duration { get; set; }
        public float TimeSpent { get; set; }
        public string Name { get; set; }
        public List<Rectangle> AnimationsTextures { get; set; }
        public float Speed { get; set; }
        public bool IsSeesaw { get; set; }

          /*-------------*/
         /* CONSTRUCTOR */
        /*-------------*/
        public SpriteAnimation(string name, List<Rectangle> animation)
        {
            TargetContentId = "SpriteTest";
            Duration = 0;
            TimeSpent = 0;
            Name = name;
            AnimationsTextures = animation;
            Speed = 1;
            IsSeesaw = true;
        }

        public SpriteAnimation(string name, string id, List<Rectangle> animation) : this(name,animation)
        {
            TargetContentId = id;
        }

        public SpriteAnimation(string name, string id, List<Rectangle> animation, float speed) : this(name, id, animation)
        {
            Speed = speed;
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
