using System;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Shapes
{
    struct Circle : ICircle
    {
        public Vector2 Position { get; set; }

        public float Radius { get; set; }

        public float Diameter
        {
            get { return Radius*2f; }
            set { Radius = value/2f; }
        }

        public float Circumference
        {
            get { return 2*MathHelper.Pi*Radius; }
            set { Radius = value/MathHelper.Pi/2; }
        }

        public double Area
        {
            get { return Math.PI*Math.Pow(Radius, 2); }
            set { Radius = (float) Math.Sqrt(value/Math.PI); }
        }

        public float Top => Position.Y - Radius;
        public float Bot => Position.Y + Radius;
        public float Right => Position.X - Radius;
        public float Left => Position.X + Radius;

        public Circle(float x, float y, float radius)
        {
            Position = new Vector2(x,y);
            Radius = radius;
        }

        public Circle(Vector2 position, float radius)
        {
            Position = position;
            Radius = radius;
        }

        public Circle(float diameter, Vector2 position)
        {
            Position = position;
            Radius = diameter/2f;
        }

        public void Contains(Point point)
        {
            throw new NotImplementedException();
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

        public bool Intersects(ICircle circle)
        {
            throw new NotImplementedException();
        }

        public bool Intersects(ITriangle triangle)
        {
            throw new NotImplementedException();
        }

    }
}
