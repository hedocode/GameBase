using System;
using System.Collections.Generic;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Graphic
{
    struct TextSpriteHorizontalScrolling : ITextSpriteAnimation
    {
        private double _timeSinceLast;

        
        public float Duration { get; set; }
        public double ElapsedLifeTime { get; set; }
        public bool Increase { get; set; }
        public float Frequency { get; set; }
        public string Name { get; set; }
        public ITextSprite AffectedTextSprite { get; set; }
        public List<string> AnimationTexts { get; set; }
        public bool IsSeesaw { get; set; }
        public object BaseObject { get; }
        public object AffectedObject
        {
            get { return AffectedTextSprite; }
            set
            {
                ITextSprite textSprite = value as ITextSprite;
                if(textSprite != null)AffectedTextSprite = textSprite;
            }
        }

        public TextSpriteHorizontalScrolling(float frequency, float duration, ITextSprite textSprite, bool isSeesaw = false)
        {
            _timeSinceLast = 0;
            var nbCharDisplayed = 13;
            Duration = duration;
            ElapsedLifeTime = 0;
            Frequency = frequency;
            Name = "TextSpriteHorizontalScrolling";
            AffectedTextSprite = textSprite;
            AnimationTexts = new List<string>();
            textSprite.CurrentAnimation = Name;
            BaseObject = textSprite;

            string txt = textSprite.Text;
            AnimationTexts.Add(txt);
            for (int i = 0; i < textSprite.Text.Length; i++)
            {
                char temp = txt[0];
                txt = txt.Remove(0,1);
                txt = txt.Insert(txt.Length, temp.ToString());

                string test="";
                for (int j = 0; j < nbCharDisplayed; j++)
                {
                    test = test.Insert(j,txt[j].ToString());
                }
                AnimationTexts.Add(test);
            }
            IsSeesaw = isSeesaw;
            Increase = true;
            textSprite.Animation = this;
        }

        public void Affect(GameTime gameTime)
        {
            _timeSinceLast += gameTime.ElapsedGameTime.TotalSeconds;
            ElapsedLifeTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timeSinceLast >= 1/Frequency)
            {
                
                if (IsSeesaw)
                {
                    if (Increase)
                    {
                        AffectedTextSprite.CurrentFrame++;
                        if (AffectedTextSprite.CurrentFrame == AnimationTexts.Count-1)
                            Increase = false;
                    }
                    else
                    {
                        AffectedTextSprite.CurrentFrame--;
                        if (AffectedTextSprite.CurrentFrame == 0)
                            Increase = true;
                    }
                }
                else
                {
                    AffectedTextSprite.CurrentFrame++;
                    if (AffectedTextSprite.CurrentFrame > AnimationTexts.Count-1)
                        AffectedTextSprite.CurrentFrame = 0;
                }
                AffectedTextSprite.Text = AnimationTexts[AffectedTextSprite.CurrentFrame];
                _timeSinceLast = 0;
            }
        }


        public void Reset()
        {
            ITextSprite textSprite = (ITextSprite)BaseObject;
            if (textSprite == null) { throw new InvalidCastException("ERROR : CAST FROM OBJECT TO IDRAWABLE FAILED"); }
            AffectedTextSprite.Opacity = textSprite.Opacity;
            AffectedTextSprite.Rotation = textSprite.Rotation;
            AffectedTextSprite.Scale = textSprite.Scale;
            AffectedTextSprite.CurrentFrame = textSprite.CurrentFrame;
            AffectedTextSprite.CurrentAnimation = textSprite.CurrentAnimation;
            AffectedTextSprite.Text = textSprite.Text;
        }

    }
}
