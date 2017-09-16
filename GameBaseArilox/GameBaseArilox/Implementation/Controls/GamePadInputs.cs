using System;
using System.Collections.Generic;
using GameBaseArilox.API.Controls;
using GameBaseArilox.API.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameBaseArilox.Implementation.Controls
{
    public class GamePadInputs : IInput
    {
        private readonly List<Buttons> _gamePadButtonList = new List<Buttons>
        {
            Buttons.A,Buttons.B, Buttons.X, Buttons.Y,
            Buttons.Back, Buttons.BigButton, Buttons.Start,
            Buttons.DPadUp, Buttons.DPadDown, Buttons.DPadRight, Buttons.DPadLeft,
            Buttons.LeftShoulder, Buttons.RightShoulder,
            Buttons.LeftTrigger, Buttons.RightTrigger,
            Buttons.LeftStick,Buttons.RightStick,
            Buttons.LeftThumbstickUp, Buttons.LeftThumbstickDown,Buttons.LeftThumbstickRight,Buttons.LeftThumbstickLeft,
            Buttons.RightThumbstickUp, Buttons.RightThumbstickDown,  Buttons.RightThumbstickRight, Buttons.RightThumbstickLeft
        };

        private Dictionary<Buttons, string> _buttonsName = new Dictionary<Buttons, string>
        {
            {Buttons.A, "GamepadA"}, {Buttons.B, "GamepadB"}, {Buttons.X, "GamepadX" }, {Buttons.Y, "GamepadY" },
            {Buttons.Back, "GamepadBack" }, {Buttons.BigButton, "GamepadBigButton" }, {Buttons.Start, "GamePadStart" },
            {Buttons.DPadUp, "GamepadDPadUp" }, {Buttons.DPadDown, "GamepadDPadDown" }, {Buttons.DPadRight, "GamepadDPadRight" }, {Buttons.DPadLeft, "GamepadDPadLeft" },
            {Buttons.LeftShoulder, "GamepadLeftShoulder" }, {Buttons.RightShoulder, "GamepadRightShoulder" },
            {Buttons.LeftTrigger, "GamepadLeftTrigger" },  {Buttons.RightTrigger, "GamepadRightTrigger" },
            {Buttons.LeftThumbstickUp, "GamepadLeftThumbstickUp"}, {Buttons.LeftThumbstickDown,"GamepadLeftThumbstickDown"}, {Buttons.LeftThumbstickRight, "GamepadLeftThumbstickRight"}, {Buttons.LeftThumbstickLeft, "GamepadLeftThumbstickLeft"},
            {Buttons.RightThumbstickUp,"GamepadRightThumbstickUp"}, {Buttons.RightThumbstickDown,"GamepadRightThumbstickDown"}, {Buttons.RightThumbstickRight, "GamepadRightThumbstickRight"}, {Buttons.RightThumbstickLeft, "GamepadRightThumbstickLeft"}
        };
        private const GamePadDeadZone DeadZone = GamePadDeadZone.IndependentAxes;

        public bool IsActive
        {
            get
            {
                CheckGamePadsConnection();
                for (int i = 0; i < GamePadCount; i++)
                {
                    GamePadState gamePadState = GamePad.GetState(i, DeadZone);
                    if (gamePadState.IsButtonDown(Buttons.Start))
                        return true;
                }
                return false;
            }
        }

        public int GamePadCount;
        private List<GamePadState> _gamePadStates = new List<GamePadState>();
        private List<GamePadState> _oldGamePadStates = new List<GamePadState>();
        
        public class Comparater : IComparer<List<Buttons>>
        {
            public int Compare(List<Buttons> elem1, List<Buttons> elem2)
            {
                if (elem1 == null || elem2 == null)
                    throw new Exception("Erreur valeurs nulles");

                if (elem1.Count == 0 || elem2.Count == 0)
                    throw new Exception("Erreur liste(s) vide(s)");

                return -elem1.Count.CompareTo(elem2.Count);
            }
        }

        public void LoadContent()
        {

        }

        /// <summary>
        /// Update the Game with gamepads inputs
        /// </summary>
        /// <param name="gameTime">Give Time informations</param>
        public void Update(GameTime gameTime)
        {
            CheckGamePadsConnection();

            for (int i = 0; i < GamePadCount; i++)
            {
                _oldGamePadStates[i] = _gamePadStates[i];
                _gamePadStates[i] = GamePad.GetState(i, DeadZone);
            }
        }
        
        public bool OnPress(Buttons b, int gamePadNumber = 0)
        {
            return _gamePadStates[gamePadNumber].IsButtonDown(b) && _oldGamePadStates[gamePadNumber].IsButtonUp(b);
        }

        public bool OnPress(GamePadState gamePadState, GamePadState oldGamePadState, Buttons b)
        {
            return gamePadState.IsButtonDown(b) && oldGamePadState.IsButtonUp(b);
        }

        public bool IsButtonPressed(Buttons b, int gamePadNumer = 0)
        {
            return _gamePadStates[gamePadNumer].IsButtonDown(b);
        }

        public bool IsButtonPressed(GamePadState gamePadState, Buttons b)
        {
            return gamePadState.IsButtonDown(b);
        }

        public void CheckGamePadsConnection()
        {
            GamePadCount = 0;
            for (int i = 0; i < 8; i++)
            {
                if (GamePad.GetState(i).IsConnected)
                {
                    GamePadCount++;
                }
            }
            /* TO TEST
            while (GamePad.GetState(GamePadCount).IsConnected)
            {
                GamePadCount++;
            }
            */
        }

        /// <summary>
        /// Search for a button down, when find one, returns true, if doesn't find any, returns false.
        /// </summary>
        /// <param name="gamePadState">The gamepad state you want to test</param>
        /// <returns>Return a <see cref="bool"/></returns>
        public bool IsGamePadActive(GamePadState gamePadState)
        {
            foreach (Buttons b in _gamePadButtonList)
            {
                if (gamePadState.IsButtonDown(b))
                {
                    return true;
                }
            }
            return false;
        }


        public List<Buttons> GetPressedButtons(GamePadState gamePadState)
        {
            List<Buttons> pressedButtons = new List<Buttons>();
            foreach (Buttons b in _gamePadButtonList)
            {
                if (gamePadState.IsButtonDown(b))
                {
                    pressedButtons.Add(b);
                }
            }
            return pressedButtons;
        }

        public List<IInputButton> GetInputButtons()
        {
            List<IInputButton> result = new List<IInputButton>();
            foreach (GamePadState gamePadState in _gamePadStates)
            {
                foreach (Buttons b in _gamePadButtonList)
                {
                    string buttonName;
                    _buttonsName.TryGetValue(b,out buttonName);
                    if (buttonName == null)
                    {
                        throw new Exception("ERROR : BUTTON NAME NOT FOUND IN THE DICTIONARY");
                    }
                    result.Add(new InputButton(buttonName,IsButtonPressed(gamePadState,b),InputType.GamePad));
                }
            }
            return result;
        }
       
    }
}
