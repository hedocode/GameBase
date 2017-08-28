using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Shapes
{
    struct Line : IShapeCollider
    {
        private float _a;
        private float _b;

        public Line(int a, int b)
        {
            _a = a;
            _b = b;
        }


        public void Contains(Point point)
        {
            throw new System.NotImplementedException();
        }

        public bool Intersects(ISegment segment)
        {
            throw new System.NotImplementedException();
        }

        public bool Intersects(IRectangle rectangle)
        {
            throw new System.NotImplementedException();
        }

        public bool Intersects(Rectangle rectangle)
        {
            throw new System.NotImplementedException();
        }

        public bool Intersects(ICircle circle)
        {
            throw new System.NotImplementedException();
        }

        public bool Intersects(ITriangle triangle)
        {
            throw new System.NotImplementedException();
        }
    }
}
