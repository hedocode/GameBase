using System.Collections.Generic;
using GameBaseArilox.API.Shapes;
using GameBaseArilox.Implementation.Core;

namespace GameBaseArilox.Implementation.Shapes
{
    public struct Point2D : IShape, ICoordinates
    {
        private List<ICoordinates> _point;
        public float Top => Y;
        public float Bot => Y;
        public float Right => X;
        public float Left => X;

        public List<ICoordinates> Points
        {
            get { return _point; }
            set
            {
                if (value.Count == 1)
                    _point = value;
            }
        }

        public ICoordinates Center => new Vector2D(X,Y);
        public float X { get; set; }
        public float Y { get; set; }

        public Point2D(float x, float y)
        {
            X = x;
            Y = y;
            _point = new List<ICoordinates> {new Vector2D(x,y)};
        }

        public Point2D(Vector2D vector2)
        {
            X = vector2.X;
            Y = vector2.Y;
            _point = new List<ICoordinates> {vector2};
        }

        public Point2D(ICoordinates coords)
        {
            X = coords.X;
            Y = coords.Y;
            _point = new List<ICoordinates> {coords};
        }
    }
}
