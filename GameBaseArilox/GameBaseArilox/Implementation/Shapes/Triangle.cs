using System.Collections.Generic;
using GameBaseArilox.API.Shapes;
using GameBaseArilox.Implementation.Core;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Shapes
{
    public struct Triangle : ITriangle
    {
        public float Top => MathHelper.Min(MathHelper.Min(Point1.Y, Point2.Y),Point3.Y);
        public float Bot => MathHelper.Max(MathHelper.Max(Point1.Y, Point2.Y), Point3.Y);
        public float Right => MathHelper.Max(MathHelper.Max(Point1.X, Point2.X), Point3.X);
        public float Left => MathHelper.Min(MathHelper.Min(Point1.X, Point2.X), Point3.X);
        public List<ICoordinates> Points { get; set; }
        public ICoordinates Center => new Vector2D(Left+(Right-Left)/2, Top + (Bot-Top/2));
        public ICoordinates Point1 { get; set; }
        public ICoordinates Point2 { get; set; }
        public ICoordinates Point3 { get; set; }

        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            Point1 = (Vector2D)p1;
            Point2 = (Vector2D)p2;
            Point3 = (Vector2D)p3;
            Points = new List<ICoordinates> { Point1, Point2, Point3 };
        }

        public Triangle(Vector2 p1, Vector2 p2, ICoordinates p3)
        {
            Point1 = (Vector2D)p1;
            Point2 = (Vector2D)p2;
            Point3 = p3;
            Points = new List<ICoordinates> { Point1, Point2, Point3 };
        }

        public Triangle(ICoordinates p1, ICoordinates p2, ICoordinates p3)
        {
            Point1 = p1;
            Point2 = p2;
            Point3 = p3;
            Points = new List<ICoordinates> { Point1, Point2, Point3 };
        }
    }
}
