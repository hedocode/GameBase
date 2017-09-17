using System;
using System.Collections.Generic;
using System.Linq;
using GameBaseArilox.API.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameBaseArilox.Implementation.Controls
{
    public class KeyboardInputs : IInput
    {
        private KeyboardState _keyboardState;
        private Keys[] _lastPressedKeys = new Keys[0];
        private Keys[] _pressedKeys;
        private List<Keys> _newPressedKeys = new List<Keys>();


        private Dictionary<Keys, string> _buttonsName = new Dictionary<Keys, string>
        {
            {Keys.A, "A" }, {Keys.B, "B" }, {Keys.C, "C" }, {Keys.D, "D" }, {Keys.E, "E" }, {Keys.F, "F" },
            {Keys.G, "G" }, {Keys.H, "H" }, {Keys.I, "I" }, {Keys.J, "J" }, {Keys.K, "K" }, {Keys.L, "L" },
            {Keys.M, "M" }, {Keys.N, "N" }, {Keys.O, "O" }, {Keys.P, "P" }, {Keys.Q, "Q" }, {Keys.R, "R" },
            { Keys.S, "S" }, {Keys.T, "T" }, {Keys.U, "U" }, {Keys.V, "V" }, {Keys.W, "W" }, {Keys.X, "X" },
            { Keys.Y, "Y" }, {Keys.Z, "Z" }, 
            {Keys.F1, "F1"}, {Keys.F2, "F2"}, {Keys.F3, "F3"}, {Keys.F4, "F4"}, {Keys.F5, "F5"}, {Keys.F6, "F6"},
            {Keys.F7, "F7"}, {Keys.F8, "F8"}, {Keys.F9, "F9"}, {Keys.F10, "F10"}, {Keys.F11, "F11"}, {Keys.F12, "F12"},
            {Keys.NumPad0, "Numpad0" }, {Keys.NumPad1, "Numpad1" }, {Keys.NumPad2, "Numpad2" }, {Keys.NumPad3, "Numpad3" },
            {Keys.NumPad4, "Numpad4" }, {Keys.NumPad5, "Numpad5" }, {Keys.NumPad6, "Numpad6" }, {Keys.NumPad7, "Numpad7" },
            {Keys.NumPad8, "Numpad8" }, {Keys.NumPad9, "Numpad9" }, {Keys.NumLock, "Numlock" },
            {Keys.Divide, "/" }, {Keys.Multiply, "*"}, {Keys.Subtract, "-" }, {Keys.Add, "+" },
            {Keys.Enter, "Enter" }, {Keys.Back, "Back" }, {Keys.Delete, "Delete" },
            {Keys.Decimal, "." },
            {Keys.Up, "Up" }, {Keys.Down, "Down" }, {Keys.Right, "Right" }, {Keys.Left, "Left" },
            {Keys.LeftControl, "CtrlLeft" }, {Keys.RightControl, "CtrlRight" }, {Keys.LeftAlt, "AltLeft" }, {Keys.RightAlt, "AltRight" },
            {Keys.LeftWindows, "WindowLeft" }, {Keys.RightWindows, "WindowRight" },
            {Keys.LeftShift, "ShiftLeft"}, {Keys.RightShift, "ShiftRight" }
        };

        public bool IsActive => Keyboard.GetState().GetPressedKeys().Length != 0;

        
        public void LoadContent()
        {

        }

        /// <summary>
        /// Update the Game with keyboards inputs
        /// </summary>
        /// <param name="gameTime">Give Time informations</param>
        public void Update(GameTime gameTime)
        {
            _newPressedKeys.Clear();
            _keyboardState = Keyboard.GetState();
            _pressedKeys = _keyboardState.GetPressedKeys();

            foreach (Keys k in _pressedKeys)
            {
                if (!_lastPressedKeys.Contains(k))
                {
                    _newPressedKeys.Add(k);
                }
            }
        }
        
        public void UpdateNewPressedKeys()
        {
            _newPressedKeys.Clear();
            _keyboardState = Keyboard.GetState();
            _pressedKeys = _keyboardState.GetPressedKeys();

            foreach (Keys k in _pressedKeys)
            {
                if (!_lastPressedKeys.Contains(k))
                {
                    _newPressedKeys.Add(k);
                }
            }
            _lastPressedKeys = _pressedKeys;
        }


        public List<IInputButton> GetInputButtons()
        {
            List<IInputButton> result = new List<IInputButton>();
            foreach (Keys key in _buttonsName.Keys)
            {
                string buttonName;
                _buttonsName.TryGetValue(key, out buttonName);
                if (buttonName == null)
                {
                    throw new Exception("ERROR : BUTTON NAME NOT FOUND IN THE DICTIONARY");
                }
                result.Add(new InputButton(buttonName, _keyboardState.IsKeyDown(key)));
            }
            return result;
        }

        /// <summary>
        /// Return last pressed keys
        /// </summary>
        public Keys[] GetPressedKeys()
        {
            return _lastPressedKeys;
        }

        /// <summary>
        /// Returns the new pressed keys
        /// </summary>
        /// <returns></returns>
        public List<Keys> GetNewPressedKeys()
        {
            return _newPressedKeys;
        }
    }
}
