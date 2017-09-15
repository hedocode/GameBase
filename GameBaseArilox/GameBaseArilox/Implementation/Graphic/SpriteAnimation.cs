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
        public string Name { get; set; }
        public List<Rectangle> AnimationsTextures { get; set; }
        public float EffectSpeed { get; set; }

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
            EffectSpeed = 1;
            IsSeesaw = true;
            AffectedObject = null;
        }

        public SpriteAnimation(string name, string id, List<Rectangle> animation) : this(name,animation)
        {
            TargetContentId = id;
        }

        public SpriteAnimation(string name, string id, List<Rectangle> animation, float effectSpeed) : this(name, id, animation)
        {
            EffectSpeed = effectSpeed;
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
