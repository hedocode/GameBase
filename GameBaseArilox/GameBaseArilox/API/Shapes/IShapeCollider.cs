using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Shapes
{
    public interface IShapeCollider
    {
        void Contains(Point point);
        bool Intersects(ISegment segment);
        bool Intersects(IRectangle rectangle);
        bool Intersects(Rectangle rectangle);
        bool Intersects(ICircle circle);
        bool Intersects(ITriangle triangle);
    }
}
