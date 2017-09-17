using System;
using System.Collections.Generic;
using GameBaseArilox.API.Controls;
using GameBaseArilox.API.Enums;
using GameBaseArilox.Implementation.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameBaseArilox.Implementation.Controls
{
    public class MouseInputs : IInput
    {
        internal enum MouseButton
        {
            LeftButton,
            MidButton,
            RightButton,
            XButton1,
            XButton2
        }


        private Dictionary<MouseButton, string> _buttonsName = new Dictionary<MouseButton, string>
        {
            {MouseButton.RightButton, "RightClick"},
            {MouseButton.MidButton, "MidClick"},
            {MouseButton.LeftButton,"LeftClick"},
            {MouseButton.XButton1, "MousePrevious" },
            {MouseButton.XButton2, "MouseNext" }
        };
        
        private MouseState _mouseState;

        public void LoadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            _mouseState = Mouse.GetState();
        }

        public List<IInputButton> GetInputButtons()
        {
            List<IInputButton> result = new List<IInputButton>();
            foreach (MouseButton b in _buttonsName.Keys)
            {
                string buttonName;
                bool isPressed = false;
                _buttonsName.TryGetValue(b,out buttonName);
                if (buttonName == null)
                {
                    throw new Exception("ERROR : BUTTON NAME NOT FOUND IN THE DICTIONARY");
                }
                switch (b)
                {
                    case MouseButton.LeftButton:
                        isPressed = IsLeftButtonPressed();
                        break;
                    case MouseButton.MidButton:
                        isPressed = IsMiddleButtonPressed();
                        break;
                    case MouseButton.RightButton:
                        isPressed = IsRightButtonPressed();
                        break;
                    case MouseButton.XButton1:
                        isPressed = IsXButton1Pressed();
                        break;
                    case MouseButton.XButton2:
                        isPressed = IsXButton2Pressed();
                        break;
                }
                result.Add(new InputButton(buttonName, isPressed,InputType.Mouse));
            }
            return result;
        }
        
        /// <summary>
        /// Give the Mouse Position on the Window
        /// </summary>
        /// <returns></returns>
        public Point GetMouseAbsolutePosition()
        {
            return new Point(_mouseState.X, _mouseState.Y);
        }
        
        /// <summary>
        /// Give the Mouse Position on the Map
        /// </summary>
        /// <returns></returns>
        public Vector2 GetMouseMapPosition(Camera2D camera)
        {
            return new Vector2(_mouseState.X + camera.Position.X, _mouseState.Y + camera.Position.Y);
        }

        /// <summary>
        /// Give the Tile Position of the Mouse
        /// </summary>
        /// <returns></returns>
        public Point GetMouseTilePosition(Camera2D camera)
        {
            return new Point((int)((_mouseState.X + camera.Position.X) / 64f), (int)((_mouseState.Y + camera.Position.Y) / 64f));
        }

        public int GetScrollValue()
        {
            return _mouseState.ScrollWheelValue;
        }

        public bool IsLeftButtonClick()
        {
            return IsLeftButtonReleased() && IsLeftButtonPressed();
        }

        public bool IsLeftClickedValidate()
        {
            return IsLeftButtonPressed() && IsLeftButtonReleased();
        }

        public bool IsRightButtonPressed()
        {
            return IsPressed(_mouseState.RightButton);
        }

        public bool IsLeftButtonPressed()
        {
            return IsPressed(_mouseState.LeftButton);
        }

        public bool IsMiddleButtonPressed()
        {
            return IsPressed(_mouseState.MiddleButton);
        }

        public bool IsRightButtonReleased()
        {
            return IsReleased(_mouseState.RightButton);
        }

        public bool IsLeftButtonReleased()
        {
            return IsReleased(_mouseState.LeftButton);
        }

        public bool IsMiddleButtonReleased()
        {
            return IsReleased(_mouseState.MiddleButton);
        }

        public bool IsXButton1Released()
        {
            return IsReleased(_mouseState.XButton1);
        }

        public bool IsXButton1Pressed()
        {
            return IsPressed(_mouseState.XButton1);
        }

        public bool IsXButton2Released()
        {
            return IsReleased(_mouseState.XButton2);
        }

        public bool IsXButton2Pressed()
        {
            return IsPressed(_mouseState.XButton2);
        }

        public bool IsPressed(ButtonState buttonState)
        {
            return buttonState == ButtonState.Pressed;
        }

        public bool IsReleased(ButtonState buttonState)
        {
            return buttonState == ButtonState.Released;
        }
    }
}
