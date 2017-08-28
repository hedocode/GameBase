using System;
using GameBaseArilox.API.Shapes;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Detection
{
    struct DiscusArea : IDetectionArea, ICircle
    {
        public Vector2 Position { get; set; }

        public float Radius { get; set; }

        public float Diameter
        {
            get { return Radius * 2f; }
            set { Radius = value / 2f; }
        }

        public float Circumference
        {
            get { return 2 * MathHelper.Pi * Radius; }
            set { Radius = value / MathHelper.Pi / 2; }
        }

        public double Area
        {
            get { return Math.PI * Math.Pow(Radius, 2); }
            set { Radius = (float)Math.Sqrt(value / Math.PI); }
        }

        public DiscusArea(ICircle circle)
        {
            Position = circle.Position;
            Radius = circle.Radius;
        }

        public float Top => Position.Y - Radius;
        public float Bot => Position.Y + Radius;
        public float Right => Position.X - Radius;
        public float Left => Position.X + Radius;

        public bool Contains(Point point)
        {
            return Math.Sqrt(Math.Pow(point.X - Position.X,2)+Math.Pow(point.Y - Position.Y,2)) <= Radius;
        }

        public bool Intersects(ISegment segment)
        {
            throw new NotImplementedException();
        }

        public bool Intersects(IRectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public bool Intersects(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Vector2 vector)
        {
            return Contains(vector.ToPoint());
        }

        void IShapeCollider.Contains(Point point)
        {
            throw new NotImplementedException();
        }

        public bool Intersects(ICircle circle)
        {
            return Math.Sqrt(Math.Pow(circle.Position.X - Position.X, 2) + Math.Pow(circle.Position.Y - Position.Y, 2)) 
                <= circle.Radius + Radius;
        }

        public bool Intersects(ITriangle triangle)
        {
            throw new NotImplementedException();
        }


        public bool Intersects(IDetectionArea detectionArea)
        {
            switch (detectionArea.GetType().ToString())
            {
                case "RectangleArea":
                    return Intersects((RectangleArea)detectionArea);
                case "DiscusArea":
                    return Intersects((ICircle) detectionArea);
                default:
                    return false;
            }
        }

    }
}
