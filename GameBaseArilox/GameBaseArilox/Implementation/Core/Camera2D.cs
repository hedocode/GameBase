using System.Collections.Generic;
using GameBaseArilox.API.Entities;
using GameBaseArilox.API.Enums;
using GameBaseArilox.API.Environment;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Implementation.Core
{
    public class Camera2D : IGameElement
    {
        public CameraType Type { get; }
        public IGameEntity ToFollow { get; }
        public List<Vector2> NextPosition = new List<Vector2>();

        public Vector2 Position { get; set; }


        public float X { get; set; }
        public float Y { get; set; }

        public float Speed { get; set; }

        public float Rotation { get; set; }
        public float Zoom { get; set; }
        public Vector2 Origin { get; set; }


        public Camera2D(Viewport viewport, IGameEntity toFollow, CameraType type)
        {
            Rotation = 0;
            Zoom = 1;
            Speed = 10;
            Origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
            Position = Vector2.Zero;
            ToFollow = toFollow;
            Type = type;
        }

        public void AddTravellingTo(Vector2 coord)
        {
            NextPosition.Add(coord);
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
    }
}
