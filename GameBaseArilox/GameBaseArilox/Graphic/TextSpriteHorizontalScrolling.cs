using System.Collections.Generic;
using GameBaseArilox.API.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Graphic
{
    struct TextSpriteHorizontalScrolling : ITextSpriteAnimation
    {
        private double _timeSinceLast;
        private string _baseString;
        private bool _increase;
        private int _nbCharDisplayed;

        public float Duration { get; set; }
        public float TimeSpent { get; set; }
        public float Speed { get; set; }
        public string Name { get; set; }
        public ITextSprite AffectedTextSprite { get; set; }
        public List<string> AnimationTexts { get; set; }
        public bool IsSeesaw { get; set; }
        public object AffectedObject
        {
            get { return AffectedTextSprite; }
            set
            {
                ITextSprite textSprite = value as ITextSprite;
                if(textSprite != null)AffectedTextSprite = textSprite;
            }
        }

        public TextSpriteHorizontalScrolling(float speed, float duration, ITextSprite textSprite, bool isSeesaw = false)
        {
            _timeSinceLast = 0;
            _baseString = textSprite.Text;
            _nbCharDisplayed = 13;
            Duration = duration;
            TimeSpent = 0;
            Speed = speed;
            Name = "TextSpriteHorizontalScrolling";
            AffectedTextSprite = textSprite;
            AnimationTexts = new List<string>();
            textSprite.CurrentAnimation = Name;

            string txt = textSprite.Text;
            AnimationTexts.Add(txt);
            for (int i = 0; i < textSprite.Text.Length; i++)
            {
                char temp = txt[0];
                txt = txt.Remove(0,1);
                txt = txt.Insert(txt.Length, temp.ToString());

                string test="";
                for (int j = 0; j < _nbCharDisplayed; j++)
                {
                    test = test.Insert(j,txt[j].ToString());
                }
                AnimationTexts.Add(test);
            }
            IsSeesaw = isSeesaw;
            _increase = true;
            textSprite.Animation = this;
        }

        public void Affect(GameTime gameTime)
        {
            _timeSinceLast += gameTime.ElapsedGameTime.TotalSeconds;
            TimeSpent += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timeSinceLast >= 1/Speed)
            {
                
                if (IsSeesaw)
                {
                    if (_increase)
                    {
                        AffectedTextSprite.CurrentFrame++;
                        if (AffectedTextSprite.CurrentFrame == AnimationTexts.Count-1)
                            _increase = false;
                    }
                    else
                    {
                        AffectedTextSprite.CurrentFrame--;
                        if (AffectedTextSprite.CurrentFrame == 0)
                            _increase = true;
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
            AffectedTextSprite.Opacity = 1;
            AffectedTextSprite.Rotation = 0;
            AffectedTextSprite.Scale = new Vector2(1, 1);
            AffectedTextSprite.CurrentAnimation = null;
            AffectedTextSprite.CurrentFrame = 0;
            AffectedTextSprite.Text = _baseString;
        }
    }
}
