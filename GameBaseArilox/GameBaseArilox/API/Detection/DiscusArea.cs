using System;
using System.Collections.Generic;
using GameBaseArilox.API.Shapes;
using GameBaseArilox.Implementation.Core;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Detection
{
    public abstract class DiscusArea : IDetectionArea, ICircle
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

        public List<ICoordinates> Points { get; set; }

        public ICoordinates Center
        {
            get { return new Vector2D(Position.X,Position.Y); }
            set { Position = new Vector2(value.X,value.Y); }
        }

        protected DiscusArea(ICircle circle)
        {
            Position = circle.Position;
            Radius = circle.Radius;
        }

        public float Top => Position.Y - Radius;
        public float Bot => Position.Y + Radius;
        public float Right => Position.X - Radius;
        public float Left => Position.X + Radius;

        public abstract bool Detect();

        public abstract void OnDetection();
    }
}
