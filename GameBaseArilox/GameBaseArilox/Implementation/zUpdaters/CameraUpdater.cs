using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Enums;
using GameBaseArilox.API.Environment;
using GameBaseArilox.Implementation.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameBaseArilox.Implementation.zUpdaters
{
    public class CameraUpdater : IUpdater
    {
        private readonly GameModel _game;
        private readonly List<Camera2D> _cameras = new List<Camera2D>();
        private int _actualCameraNumero;

        public Camera2D CurrentCamera => _cameras[_actualCameraNumero];

        public Vector2 DirectionWanted;

        private IGameGrid TileMap => _game.TileMap;
        private Viewport Viewport => _game.Viewport;

        public Matrix GetCurrentCameraViewMatrix => CurrentCamera.GetViewMatrix();

        public Vector2 CurrentCameraEndPosition => new Vector2(CurrentCamera.Position.X + Viewport.Width, CurrentCamera.Position.Y + Viewport.Height);
        public Point CurrentCameraMapStartPointPosition => new Point((int)(CurrentCamera.Position.X / 64), (int)(CurrentCamera.Position.Y / 64));
        public Point CurrentCameraMapEndPointPosition => new Point((int)(CurrentCamera.Position.X + Viewport.Width * 1) / 64 + 1, (int)(CurrentCamera.Position.Y + Viewport.Height * 1) / 64 + 1);

        //Dernière valeur de scroll
        private int _previousScrollValue;

        public CameraUpdater(GameModel game)
        {
            _game = game;
            _game.AddToUpdaters(this);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Camera2D camera in _cameras)
            {
                switch (camera.Type)
                {
                    case CameraType.Fixed:
                        break;
                    case CameraType.Free:
                        if(DirectionWanted != Vector2.Zero)
                            camera.Position += DirectionWanted / DirectionWanted.Length() * camera.Speed;
                        break;
                    case CameraType.Programmed:
                        if (camera.NextPosition.Count != 0)
                        {
                            if ((camera.NextPosition[0] - camera.Position).Length() <= camera.Speed)
                            {
                                camera.Position = camera.NextPosition[0];
                                camera.NextPosition.RemoveAt(0);
                                break;
                            }
                            DirectionWanted = new Vector2(camera.NextPosition[0].X - camera.Position.X, camera.NextPosition[0].Y - camera.Position.Y);
                            camera.Position += DirectionWanted / DirectionWanted.Length() * camera.Speed;
                        }
                        break;
                    case CameraType.TrackEntity:
                        CurrentCamera.Position = new Vector2(CurrentCamera.ToFollow.Position.X, CurrentCamera.ToFollow.Position.Y) - new Vector2(Viewport.Width / 2f, Viewport.Height / 2f);
                        break;
                }
            }

            if (Mouse.GetState().ScrollWheelValue < _previousScrollValue)
            {
                CurrentCamera.Zoom -= 0.5f;
            }
            else if (Mouse.GetState().ScrollWheelValue > _previousScrollValue)
            {
                CurrentCamera.Zoom += 0.5f;
            }

            if (CurrentCamera.Zoom < 1)
                CurrentCamera.Zoom = 1;
            if (CurrentCamera.Zoom > 10)
                CurrentCamera.Zoom = 10;
            _previousScrollValue = Mouse.GetState().ScrollWheelValue;

            DirectionWanted = Vector2.Zero;
        }

        public void SetCurrentCamera(Camera2D camera)
        {
            _actualCameraNumero = _cameras.IndexOf(camera);
        }

        public void AddCamera(Camera2D camera)
        {
            _cameras.Add(camera);
        }

        public void SetCameraPositionInMap(Vector2 value)
        {
            Vector2 position = CurrentCamera.Position;
            if (value.X > 0 && value.X < (TileMap.XTiles - 1) * 64 - TileMap.XTiles)
            {
                position.X = value.X;
            }
            if (value.Y > 0 && value.Y < (TileMap.YTiles - 1) * 64 - TileMap.YTiles)
            {
                position.Y = value.Y;
            }
            CurrentCamera.Position = position;
        }

        public void SetDirectionFromVector(Vector2 vector)
        {
            DirectionWanted = vector;
        }

        public void RequestTop()
        {
            DirectionWanted += new Vector2(0, -1);
        }

        public void RequestBot()
        {
            DirectionWanted += new Vector2(0, 1);
        }

        public void RequestLeft()
        {
            DirectionWanted += new Vector2(-1, 0);
        }

        public void RequestRight()
        {
            DirectionWanted += new Vector2(1, 0);
        }
    }
}