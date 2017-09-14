using System;
using GameBaseArilox.API.Shapes;
using GameBaseArilox.Implementation.Core;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Shapes
{
    public static class ShapesHelper
    {
        public static bool Intersects(IRectangle r1, IRectangle r2) => r1.Top <= r2.Bot || r1.Right >= r2.Left;

        public static bool Intersects(ICircle c1, ICircle c2) => DistanceBetweenBounds(c1,c2) <= 0;

        public static bool Intersects(ILine line1, ILine line2) => line1.Slope != line2.Slope;

        public static bool Intersects(ISegment s1, ISegment s2)
        {
            if (s1.Top > s2.Bot) return false;
            if (s1.Bot < s2.Top) return false;
            if (s1.Right < s2.Left) return false;
            if (s1.Left > s2.Right) return false;
            
            ICoordinates intersectionPoint = IntersectionPointBetween(s1, s2);
            if (intersectionPoint == null) return s1.YAt0 == s2.YAt0;
            if (!Contains(s1, intersectionPoint)) return false;
            return Contains(s2, intersectionPoint);
        }

        public static bool Intersects(ITriangle triangle1, ITriangle triangle2)
        {
            if (triangle1.Top > triangle2.Bot) return false;
            if (triangle1.Bot < triangle2.Top) return false;
            if (triangle1.Right < triangle2.Left) return false;
            if (triangle1.Left > triangle2.Right) return false;

            //TODO : Optimize it
            Segment t11 = new Segment(triangle1.Point1, triangle1.Point2);
            Segment t12 = new Segment(triangle1.Point2, triangle1.Point3);
            Segment t13 = new Segment(triangle1.Point1, triangle1.Point3);
            Segment t21 = new Segment(triangle1.Point1, triangle1.Point2);
            Segment t22 = new Segment(triangle1.Point2, triangle1.Point3);
            Segment t23 = new Segment(triangle1.Point1, triangle1.Point3);

            if (Intersects(t11, t21) || Intersects(t11, t22) || Intersects(t11, t23) || 
                Intersects(t12, t21) || Intersects(t12, t22) || Intersects(t12, t23) || 
                Intersects(t13, t21) || Intersects(t13, t22) || Intersects(t13, t23) ) return true;
            return false;
        }


          /***********/
         /* HELPERS */
        /***********/
        public static double DistanceBetween(ICoordinates point1, ICoordinates point2)  =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(Vector2 point1, Vector2 point2)    =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(Point2D point1, Point2D point2)        =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(ICoordinates point1, Vector2 point2)   =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(Vector2 point1, ICoordinates point2)   =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(Vector2 point1, Point2D point2)      =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(Point2D point1, Vector2 point2)      =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(ICoordinates point1, Point2D point2)     =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        public static double DistanceBetween(Point2D point1, ICoordinates point2)     =>  DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);

        public static double DistanceBetween(ICircle circle1, ICircle circle2)
            => DistanceBetween(circle1.Position.X, circle1.Position.Y, circle2.Position.X, circle2.Position.Y);

        public static double DistanceBetween(IRectangle rectangle1, IRectangle rectangle2)
            => DistanceBetween(rectangle1.Center, rectangle2.Center);

        public static double DistanceBetween(Segment segment1, Segment segment2)
        {
            if (Intersects(segment1, segment2)) return 0;

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
            => Math.Sqrt(Math.Pow(point1X - point2X, 2) + Math.Pow(point1Y - point2Y, 2));

        public static ICoordinates IntersectionPointBetween(ILine line1, ILine line2)
        {
            if (line1.Slope == line2.Slope) return null;
            float xIntersection = (line2.YAt0 - line1.YAt0) / (line1.Slope - line2.Slope);
            float yInsersection = xIntersection*line1.Slope+line1.YAt0;
            return new Vector2D(-xIntersection,-yInsersection);
        }

        public static void IntersectionPointBetween(ILine line1, ILine line2, ICoordinates result)
        {
            if (line1.Slope == line2.Slope)
            {
                result.X = 0;
                result.Y = 0;
                return;
            }
            if (result == null) result = new Vector2D();
            result.X = -(line2.YAt0 - line1.YAt0) / (line1.Slope - line2.Slope);
            result.Y = result.X * line1.Slope - line1.YAt0;
        }

        public static bool Contains(ISegment segment, ICoordinates point)
        {
            float test = segment.Slope * -point.X + segment.YAt0;
            test = Math.Abs(test + point.Y);
            if (test >= 0.005) return false;
            return point.X >= segment.Left && point.X <= segment.Right;
        }
        
    }
}
