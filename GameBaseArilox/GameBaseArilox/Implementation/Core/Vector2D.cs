using GameBaseArilox.API.Shapes;
using GameBaseArilox.Implementation.Shapes;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Core
{
    public struct Vector2D : ICoordinates
    {
        public float X { get; set; }
        public float Y { get; set; }

        public double Lenght()
        {
            return ShapesHelper.DistanceBetween(0,0,X,Y);
        }

        public void SetLenght(float f)
        {
            this = (Vector2D)AngleHelper.AngleToVector(AngleHelper.VectorToAngle(this), f);
        }

        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2D(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public Vector2D(Vector2 vector)
        {
            X = vector.X;
            Y = vector.Y;
        }

        


        /*CAST OPERATOR*/
        public static explicit operator Vector2D(Vector2 vector2)
        {
            return new Vector2D(vector2.X,vector2.Y);
        }

        public static implicit operator Vector2(Vector2D vector2D)
        {
            return new Vector2(vector2D.X,vector2D.Y);
        }

        public static explicit operator Vector2D(Point point)
        {
            return new Vector2D(point.X, point.Y);
        }

        public static implicit operator Point(Vector2D vector2D)
        {
            return new Point((int)vector2D.X, (int)vector2D.Y);
        }

        public static implicit operator Point2D(Vector2D vector2D)
        {
            return new Point2D(vector2D.X, vector2D.Y);
        }

        public static explicit operator Vector2D(Point2D point)
        {
            return new Vector2D(point.X, point.Y);
        }

        public static Vector2D operator + (Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X+v2.X, v1.Y+v2.Y);
        }

        public static Vector2D operator - (Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2D operator *(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X * v2.X, v1.Y + v2.Y);
        }

        public override bool Equals(object obj)
        {
            ICoordinates coordinates = obj as ICoordinates;
            return coordinates?.X == X && coordinates.Y == Y;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
