using GameBaseArilox.API.Entities;
using GameBaseArilox.Implementation.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Entities
{
    public class Moumoune : GameEntity
    {
        public Moumoune(int x, int y)
        {
            Position = new Vector2(x,y);
            Sprite = new Sprite(x,y,32,32, "Moumoune" , new Vector2(16,16),"MoumouneBotLeft",1f);
        }

        public override void OnDeath()
        {
            throw new System.NotImplementedException();
        }

        public override void OnHit()
        {
            throw new System.NotImplementedException();
        }

        public override void OnClick()
        {
            throw new System.NotImplementedException();
        }

        public override void OnHover()
        {
            throw new System.NotImplementedException();
        }

        public override void OnPressed()
        {
            throw new System.NotImplementedException();
        }

        public override void OnRelease()
        {
            throw new System.NotImplementedException();
        }

        public override void OnSpawn()
        {
            throw new System.NotImplementedException();
        }
    }
}
