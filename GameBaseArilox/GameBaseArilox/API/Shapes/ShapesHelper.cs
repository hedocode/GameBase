using System;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Shapes
{
    static class ShapesHelper
    {
        public static bool Intersects(IRectangle r1, IRectangle r2)
        {
            return r1.Top <= r2.Bot || r1.Right >= r2.Left;
        }

        public static bool Intersects(ICircle c1, ICircle c2)
        {
            return DistanceBetween(c1.Position,c2.Position) <= c1.Radius + c2.Radius;
        }

        public static bool Intersects(Segment s1, Segment s2)
        {
            return false;
        }

          /***********/
         /* HELPERS */
        /***********/
        public static double DistanceBetween(Vector2D point1, Vector2D point2)
        {
            return DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        }

        public static double DistanceBetween(Vector2 point1, Vector2 point2)
        {
            return DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        }

        public static double DistanceBetween(Point point1, Point point2)
        {
            return DistanceBetween(point1.X, point1.Y, point2.X, point2.Y);
        }

        public static double DistanceBetween(ICircle circle1, ICircle circle2)
        {
            return DistanceBetween(circle1.Position.X, circle1.Position.Y, circle2.Position.X, circle2.Position.Y);
        }

        public static double DistanceBetween(float point1X, float point1Y, float point2X, float point2Y)
        {
            return Math.Sqrt(Math.Pow(point1X + point2X, 2) + Math.Pow(point1Y + point2Y, 2));
        }

        
    }
}
