using System;
using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameBaseArilox.Controls
{
    class MouseInputs
    {
        private enum MouseButton
        {
            LeftButton,
            MidButton,
            RightButton
        }
        private Dictionary<string, ICommand> _cmdDictionary;

        private Dictionary<List<MouseButton>, string> _onPress;// quand tu appuis : action UNE FOIS
        private Dictionary<List<MouseButton>, string> _onHold;// pour deplacer : faire TANT QUE appuyé
        private Dictionary<List<MouseButton>, string> _onRelease;// quand tu relaches la touche
        private Dictionary<List<MouseButton>, string> _whileRelease;// tant que la touche est relaché

        private MouseState _oldMouseState;
        private MouseState _mouseState;
        private bool _clicked;

        private Camera2D _camera;
        private readonly GameModel _game;

        public MouseInputs(GameModel game)
        {
            _game = game;
            _camera = _game.Camera;
            _onPress = new Dictionary<List<MouseButton>, string>
            {
                {new List<MouseButton> {MouseButton.LeftButton}, "selectSpeak"},
                {new List<MouseButton> {MouseButton.RightButton}, "selectFocus"  },
                {new List<MouseButton> {MouseButton.MidButton}, "startSelection" }
            };
            _onRelease = new Dictionary<List<MouseButton>, string>
            {
                {new List<MouseButton> {MouseButton.MidButton}, "endSelection"}
            };
        }

        public void LoadContent(Dictionary<string, ICommand> cmdDictionary)
        {
            _cmdDictionary = cmdDictionary;
        }

        public void Update(GameTime gameTime)
        {
            _camera = _game.Camera;
            foreach (List<MouseButton> listMb in _onPress.Keys)
            {
                //PRESSED VERIF
                foreach (MouseButton mb in listMb)
                {
                    switch (mb)
                    {
                        case MouseButton.LeftButton:
                            if (_mouseState.LeftButton == ButtonState.Pressed && _oldMouseState.LeftButton == ButtonState.Released)
                            {
                                string nomCmd;
                                ICommand cmdToExe;
                                _onPress.TryGetValue(listMb, out nomCmd);
                                if (nomCmd == null)
                                {
                                    throw new Exception("Erreur, valeur introuvable dans le dictionnaire des keys");
                                }
                                _cmdDictionary.TryGetValue(nomCmd, out cmdToExe);
                                cmdToExe?.Execute(gameTime);
                            }
                            break;
                        case MouseButton.MidButton:
                            if (_mouseState.MiddleButton == ButtonState.Pressed && _oldMouseState.MiddleButton == ButtonState.Released)
                            {
                                string nomCmd;
                                ICommand cmdToExe;
                                _onPress.TryGetValue(listMb, out nomCmd);
                                if (nomCmd == null)
                                {
                                    throw new Exception("Erreur, valeur introuvable dans le dictionnaire des keys");
                                }
                                _cmdDictionary.TryGetValue(nomCmd, out cmdToExe);
                                cmdToExe?.Execute(gameTime);
                            }
                            break;
                        case MouseButton.RightButton:
                            if (_mouseState.RightButton == ButtonState.Pressed && _oldMouseState.RightButton == ButtonState.Released)
                            {
                                string nomCmd;
                                ICommand cmdToExe;
                                _onPress.TryGetValue(listMb, out nomCmd);
                                if (nomCmd == null)
                                {
                                    throw new Exception("Erreur, valeur introuvable dans le dictionnaire des keys");
                                }
                                _cmdDictionary.TryGetValue(nomCmd, out cmdToExe);
                                cmdToExe?.Execute(gameTime);
                            }
                            break;
                    }
                }
            }

            //RELEASED VERIF
            foreach (List<MouseButton> bs in _onRelease.Keys)
            {
                int number = bs.Count;
                int count = 0;
                foreach (MouseButton mb in bs)
                {
                    switch (mb)
                    {
                        case MouseButton.LeftButton:
                            if (_mouseState.LeftButton == ButtonState.Released)
                                count++;
                            break;

                        case MouseButton.MidButton:
                            if (_mouseState.MiddleButton == ButtonState.Released)
                                count++;
                            break;
                        case MouseButton.RightButton:
                            if (_mouseState.RightButton == ButtonState.Released)
                                count++;
                            break;
                    }
                }
                if (count == number)
                {
                    foreach (MouseButton mb in bs)
                    {
                        switch (mb)
                        {
                            case MouseButton.LeftButton:
                                if (_mouseState.LeftButton == ButtonState.Released &&
                                    _oldMouseState.LeftButton == ButtonState.Pressed)
                                {
                                    string nomCmd;
                                    ICommand cmdToExe;
                                    _onRelease.TryGetValue(bs, out nomCmd);
                                    if (nomCmd == null)
                                    {
                                        throw new Exception("Erreur, valeur introuvable dans le dictionnaire des keys");
                                    }
                                    _cmdDictionary.TryGetValue(nomCmd, out cmdToExe);
                                    cmdToExe?.Execute(gameTime);
                                }
                                break;

                            case MouseButton.MidButton:
                                if (_mouseState.MiddleButton == ButtonState.Released &&
                                    _oldMouseState.MiddleButton == ButtonState.Pressed)
                                {
                                    string nomCmd;
                                    ICommand cmdToExe;
                                    _onRelease.TryGetValue(bs, out nomCmd);
                                    if (nomCmd == null)
                                    {
                                        throw new Exception("Erreur, valeur introuvable dans le dictionnaire des keys");
                                    }
                                    _cmdDictionary.TryGetValue(nomCmd, out cmdToExe);
                                    cmdToExe?.Execute(gameTime);
                                }
                                break;

                            case MouseButton.RightButton:
                                if (_mouseState.RightButton == ButtonState.Released &&
                                    _oldMouseState.RightButton == ButtonState.Pressed)
                                {
                                    string nomCmd;
                                    ICommand cmdToExe;
                                    _onRelease.TryGetValue(bs, out nomCmd);
                                    if (nomCmd == null)
                                    {
                                        throw new Exception("Erreur, valeur introuvable dans le dictionnaire des keys");
                                    }
                                    _cmdDictionary.TryGetValue(nomCmd, out cmdToExe);
                                    cmdToExe?.Execute(gameTime);
                                }
                                break;
                        }
                    }
                }
            }
            _oldMouseState = _mouseState;
            _mouseState = Mouse.GetState();
        }

        /// <summary>
        /// Give the Mouse Position on the Window
        /// </summary>
        /// <returns></returns>
        public Vector2 GetMouseAbsolutePosition()
        {
            return new Vector2(_mouseState.X, _mouseState.Y);
        }

        /// <summary>
        /// Give the Mouse Position on the Map
        /// </summary>
        /// <returns></returns>
        public Vector2 GetMouseMapPosition()
        {
            return new Vector2(_mouseState.X + _camera.Position.X, _mouseState.Y + _camera.Position.Y);
        }

        /// <summary>
        /// Give the Tile Position of the Mouse
        /// </summary>
        /// <returns></returns>
        public Vector2 GetMouseTilePosition()
        {
            return new Vector2((int)((_mouseState.X + _camera.Position.X) / 64f), (int)((_mouseState.Y + _camera.Position.Y) / 64f));
        }

        public int GetScrollValue()
        {
            return Mouse.GetState().ScrollWheelValue;
        }

        public bool IsLeftButtonClick()
        {
            return _oldMouseState.LeftButton == ButtonState.Released && _mouseState.LeftButton == ButtonState.Pressed;
        }

        public bool IsLeftClickedValidate()
        {
            return _oldMouseState.LeftButton == ButtonState.Pressed && _mouseState.LeftButton == ButtonState.Released;
        }
    }
}
