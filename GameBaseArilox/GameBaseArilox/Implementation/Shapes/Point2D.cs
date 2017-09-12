using GameBaseArilox.API.Shapes;
using GameBaseArilox.Implementation.Core;

namespace GameBaseArilox.Implementation.Shapes
{
    public struct Point2D : ICoordinates
    {
        public ICoordinates Center => new Vector2D(X,Y);
        public float X { get; set; }
        public float Y { get; set; }

        public Point2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Point2D(Vector2D vector2)
        {
            X = vector2.X;
            Y = vector2.Y;
        }

        public Point2D(ICoordinates coords)
        {
            X = coords.X;
            Y = coords.Y;
        }
    }
}
