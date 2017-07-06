using Microsoft.Xna.Framework;

namespace GameBaseArilox.API
{
    public interface IHitBox
    {
        void Contains(Point point);
        void Intersects(Rectangle rectangle);
        void Intersects(IHitBox hitBox);
    }
}