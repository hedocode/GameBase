using System;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Shapes
{
    struct Line : IShapeCollider
    {
        private float _slope;
        private float _yAt0;

        public float Root => -_yAt0/_slope;

        public Line(int slope, int yAt0)
        {
            _slope = slope;
            _yAt0 = yAt0;
        }

        public bool Contains(Point point)
        {
            return Math.Abs(_slope*point.X + _yAt0 - point.Y) < 0.00001;
        }

        public bool Contains(Vector2 point)
        {
            return Math.Abs(_slope*point.X + _yAt0 - point.Y) < 0.00001;
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
