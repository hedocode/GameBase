using System;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Shapes
{
    public static class ShapesHelper
    {
        public static bool Intersects(IRectangle r1, IRectangle r2) => r1.Top <= r2.Bot || r1.Right >= r2.Left;

        public static bool Intersects(ICircle c1, ICircle c2) => DistanceBetweenBounds(c1,c2) <= 0;

        public static bool Intersects(Segment s1, Segment s2)
        {
            return false;
        }

          /***********/
         /* HELPERS */
        /***********/
        public static double DistanceBetween(ICoordinates point1, ICoordinates point2)  =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(Vector2 point1, Vector2 point2)    =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(Point point1, Point point2)        =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(ICoordinates point1, Vector2 point2)   =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(Vector2 point1, ICoordinates point2)   =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(Vector2 point1, Point point2)      =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(Point point1, Vector2 point2)      =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(ICoordinates point1, Point point2)     =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(Point point1, ICoordinates point2)     =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);

        public static double DistanceBetween(ICircle circle1, ICircle circle2)
            => DistanceBetween(circle1.Position.X, circle1.Position.Y, circle2.Position.X, circle2.Position.Y);

        public static double DistanceBetween(IRectangle rectangle1, IRectangle rectangle2)
            => DistanceBetween(rectangle1.Center, rectangle2.Center);

        public static double DistanceBetween(Segment segment1, Segment segment2)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (segment1.Slope == segment2.Slope)
            {
                return Math.Sin(AngleHelper.SlopeToRadian(segment1.Slope))
                    *(segment1.Slope*Math.Abs(segment1.YAt0-segment2.YAt0));
            }
            if (segment1.Slope > segment2.Slope)
            {
                return DistanceBetween(segment1.Point2, segment2.Point2);
            }
            return DistanceBetween(segment1.Point1, segment2.Point1);
        }


        public static double DistanceBetweenEdges(IRectangle rectangle1, IRectangle rectangle2)
        {
            if (Intersects(rectangle1, rectangle2))
            {
                return 0;
            }

            if (rectangle1.Left > rectangle2.Left && rectangle1.Left < rectangle2.Right ||
            rectangle1.Right < rectangle2.Right && rectangle1.Right > rectangle2.Left)
            {
                if (rectangle1.Bot < rectangle2.Top)
                {
                    return rectangle2.Top - rectangle1.Bot;
                }
                return rectangle1.Top - rectangle2.Bot;
            }
            if (rectangle1.Top > rectangle2.Top && rectangle1.Top < rectangle2.Bot ||
                rectangle1.Bot > rectangle2.Bot && rectangle1.Bot < rectangle2.Top)
            {
                if (rectangle1.Right < rectangle2.Left)
                {
                    return rectangle2.Left - rectangle1.Top;
                }
                return rectangle1.Left - rectangle2.Right;
            }
            if (rectangle1.Left > rectangle2.Right)
            {
                if (rectangle1.Top > rectangle2.Bot)
                {
                    return DistanceBetween(rectangle1.Left, rectangle1.Top, rectangle2.Right, rectangle2.Bot);
                }
                return DistanceBetween(rectangle1.Left, rectangle1.Bot, rectangle2.Right, rectangle2.Top);
            }
            if (rectangle1.Top > rectangle2.Bot)
            {
                return DistanceBetween(rectangle1.Right, rectangle1.Top, rectangle2.Left, rectangle2.Bot);
            }
            return DistanceBetween(rectangle1.Right, rectangle1.Bot, rectangle2.Left, rectangle2.Top);
        }

        public static double DistanceBetweenBounds(ICircle circle1, ICircle circle2)
            => DistanceBetween(circle1.Position.X, circle1.Position.Y, circle2.Position.X, circle2.Position.Y) - circle1.Radius - circle2.Radius;

        public static double DistanceBetween(float point1X, float point1Y, float point2X, float point2Y)
            => Math.Sqrt(Math.Pow(point1X + point2X, 2) + Math.Pow(point1Y + point2Y, 2));
       

        
    }
}
