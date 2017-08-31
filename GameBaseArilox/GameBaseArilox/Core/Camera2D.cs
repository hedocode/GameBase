using GameBaseArilox.API.Entities;
using GameBaseArilox.API.Environment;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameBaseArilox.Core
{
    public class Camera2D : IGameElement
    {
       
        private readonly IGameGrid _tileMap;
        private Viewport _viewport;
        private readonly IGameEntity _toFollow;

        private Vector2 _position;
        private float _x;
        private float _y;

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                if (value.X > 0 && value.X < (_tileMap.XTiles - 1) * 64 - _viewport.Width)
                {
                    _position.X = value.X;
                }
                if (value.Y > 0 && value.Y < (_tileMap.YTiles - 1) * 64 - _viewport.Height)
                {
                    _position.Y = value.Y;
                }
            }
        }

        public float X { get; set; }
        public float Y { get; set; }

        public Vector2 EndPosition => new Vector2(Position.X + _viewport.Width, Position.Y + _viewport.Height);
        public Point MapStartPointPosition => new Point((int)(_position.X / 64), (int)(_position.Y / 64));
        public Point MapEndPointPosition => new Point((int)(_position.X + _viewport.Width * 1) / 64 + 1, (int)(_position.Y + _viewport.Height * 1) / 64 + 1);


        public float Rotation { get; set; }
        public float Zoom { get; set; }
        public Vector2 Origin { get; set; }

        //Dernière valeur de scroll
        private int _previousScrollValue;

        public Camera2D(Viewport viewport, IGameEntity toFollow, IGameGrid tileMap)
        {
            Rotation = 0;
            Zoom = 1;
            Origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
            Position = Vector2.Zero;
            _toFollow = toFollow;
            _viewport = viewport;
            _tileMap = tileMap;
        }

        /// <summary>
        /// Return the camera view.
        /// </summary>
        /// <returns>Camera2D Matrix</returns>
        public Matrix GetViewMatrix()
        {
            return
                Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }


        /// <summary>
        /// Actual Update method, will be remove for using Input manager and Commands.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            Position = new Vector2(_toFollow.Position.X, _toFollow.Position.Y) - new Vector2(_viewport.Width / 2f, _viewport.Height / 2f);

            if (Mouse.GetState().ScrollWheelValue < _previousScrollValue)
            {
                Zoom -= 0.5f;
            }
            else if (Mouse.GetState().ScrollWheelValue > _previousScrollValue)
            {
                Zoom += 0.5f;
            }

            if (Zoom < 1)
                Zoom = 1;
            if (Zoom > 10)
                Zoom = 10;
            _previousScrollValue = Mouse.GetState().ScrollWheelValue;
        }

        /// <summary>
        /// Makes the camera move towards Left
        /// </summary>
        /// <param name="gameTime"></param>
        public void Left(GameTime gameTime)
        {
            Position += new Vector2(5, 0);
        }
    }
}
