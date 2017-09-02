using System.Collections.Generic;
using GameBaseArilox.API.Shapes;
using GameBaseArilox.Core;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Detection
{
    public abstract class RectangleArea : IDetectionArea, IRectangle
    {
        private float _x;
        private float _y;

        public Vector2 Position
        {
            get
            {
                return new Vector2(_x, _y);
            }
            set
            {
                _x = value.X;
                _y = value.Y;
            }
        }

        public float Top => Position.Y;
        public float Bot => Position.Y + Height;
        public float Right => Position.X + Width;
        public float Left => Position.X;
        public List<ICoordinates> Points { get; set; }
        public ICoordinates Center => new Vector2D(Left+Width/2,Top+Height/2);

        public float Height { get; set; }
        public float Width { get; set; }

        protected RectangleArea(Vector2 position, float width, float height)
        {
            Points = new List<ICoordinates>
            {
                new Vector2D(position),
                new Vector2D(position.X+width,position.Y),
                new Vector2D(position.X,position.Y+height),
                new Vector2D(position.X+width,position.Y+height)
            };
            _x = position.X;
            _y = position.Y;
            Width = width;
            Height = height;
        }

        protected RectangleArea(float x, float y, float width, float height)
        {
            _x = x;
            _y = y;
            Width = width;
            Height = height;
        }

        public abstract bool Detect();
        public abstract void OnDetection();
        public float Rotation { get; set; }
    }
}
