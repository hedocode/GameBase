using System;
using System.Collections.Generic;
using GameBaseArilox.API.Shapes;
using GameBaseArilox.Implementation.Core;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Shapes
{
    struct Circle : ICircle
    {
        public Vector2 Position { get; set; }

        public List<ICoordinates> Points { get; set; }

        public ICoordinates Center
        {
            get { return new Vector2D(Position.X, Position.Y); }
            set { Position = new Vector2(value.X, value.Y); }
        }

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
        public List<ISegment> Segments { get; set; }

        public Circle(float x, float y, float radius)
        {
            Points = new List<ICoordinates> {new Vector2D(x,y)};
            Position = new Vector2(x,y);
            Radius = radius;
            Segments = new List<ISegment>();
        }

        public Circle(Vector2 position, float radius)
        {
            Points = new List<ICoordinates> { new Vector2D(position.X, position.Y) };
            Position = position;
            Radius = radius;
            Segments = new List<ISegment>();
        }

        public Circle(float diameter, Vector2 position)
        {
            Points = new List<ICoordinates> { new Vector2D(position.X, position.Y) };
            Position = position;
            Radius = diameter/2f;
            Segments = new List<ISegment>();
        }
    }
}
