using GameBaseArilox.API.Shapes;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Detection
{
    struct RectangleArea : IDetectionArea, IRectangle
    {
        private float _x;
        private float _y;

        public Vector2 Position
        {
            get
            {
                return new Vector2(_x, _y);
            }
            set
            {
                _x = value.X;
                _y = value.Y;
            }
        }

        public float Top => Position.Y;
        public float Bot => Position.Y + Height;
        public float Right => Position.X + Width;
        public float Left => Position.X;

        public float Height { get; set; }
        public float Width { get; set; }

        public RectangleArea(Vector2 position, float width, float height)
        {
            _x = position.X;
            _y = position.Y;
            Width = width;
            Height = height;
        }

        public RectangleArea(float x, float y, float width, float height)
        {
            _x = x;
            _y = y;
            Width = width;
            Height = height;
        }

        public bool Contains(Point point)
        {
            return (point.X >= _x) && (point.X <= _x + Width) &&
                (point.Y >= _y) && (point.Y <= _y + Height);
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

        public bool Intersects(RectangleArea rectangleArea)
        {
            return Top <= rectangleArea.Bot || Right >= rectangleArea.Left;
        }

        public bool Intersects(IDetectionArea detectionArea)
        {
            switch (detectionArea.GetType().ToString())
            {
                case "RectangleArea":
                    return Intersects((RectangleArea)detectionArea);
                //case "DiscusArea" :
                default:
                    return false;
            }
        }
    }
}
