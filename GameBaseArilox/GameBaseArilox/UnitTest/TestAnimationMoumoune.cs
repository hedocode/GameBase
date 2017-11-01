using GameBaseArilox.API.Graphic;
using GameBaseArilox.Implementation.Entities;

namespace GameBaseArilox.UnitTest
{
    public class TestAnimationMoumoune : GameModel
    {
        private ISprite _sprite;

        public TestAnimationMoumoune()
        {
            Moumoune m = new Moumoune(100,100);
            AddEntity(m);
        }

        public void Initialize()
        {
            
        }
    }
}
