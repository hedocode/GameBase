using System;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Shapes
{
    struct Segment : ISegment
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }

        public float Slope
        {
            get
            {
                if (Point1.X < Point2.X)
                {
                    return (Point2.X - Point1.X) / (float)(Point2.Y - Point1.Y);
                }
                if (Point1.X > Point2.X)
                {
                    return (Point1.X - Point2.X) / (float)(Point1.Y - Point2.Y);
                }
                return Single.PositiveInfinity;
            }
            set { }
        }

        public float YAt0
        {
            get { return Slope*Point1.X - Point1.Y; }
            set { }
        }


        public float Top => MathHelper.Max(Point1.Y, Point2.Y);
        public float Bot => MathHelper.Min(Point1.Y, Point2.Y);
        public float Right => MathHelper.Max(Point1.X, Point2.X);
        public float Left => MathHelper.Min(Point1.X, Point2.X);

        public double Lenght => ShapesHelper.DistanceBetween(Point1,Point2);

        public Segment(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
            
        }

        public Segment(Vector2 point1, Vector2 point2)
        {
            Point1 = point1.ToPoint();
            Point2 = point2.ToPoint();
        }

        public bool Contains(Point point)
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
