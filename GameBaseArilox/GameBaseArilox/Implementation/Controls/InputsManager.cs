using System;
using System.Collections.Generic;
using GameBaseArilox.API.Controls;
using GameBaseArilox.API.Core;
using GameBaseArilox.Implementation.Commands;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Controls
{
    public class InputsManager : IUpdater, IContentLoader
    {
        private Dictionary<string, ICommand> _cmdDictionary;

        private List<IInput> _inputs = new List<IInput>();
        private readonly KeyboardInputs _keyboardInputs;
        private readonly GamePadInputs _gamePadInputs;
        private readonly MouseInputs _mouseInputs;

        public MouseInputs MouseInput => _mouseInputs;
        public KeyboardInputs KeyboardInput => _keyboardInputs;
        public GamePadInputs GamePadInputs => _gamePadInputs;

        private Dictionary<List<string>, string> _onPress;     // when pressed : one time
        private Dictionary<List<string>, string> _onHold;      // while hold
        private Dictionary<List<string>, string> _onRelease;   // when button is released
        private Dictionary<List<string>, string> _whileRelease;// while button is realeased

        private Dictionary<string, bool> _oldButtonsState;
        private Dictionary<string, bool> _buttonsState;

        public bool UpdateGamePad;
        private GameModel _game;

        public InputsManager(GameModel game)
        {
            _mouseInputs = new MouseInputs();
            _gamePadInputs = new GamePadInputs();
            _keyboardInputs = new KeyboardInputs();
            _inputs.Add(_mouseInputs);
            _inputs.Add(_gamePadInputs);
            _inputs.Add(_keyboardInputs);

            _oldButtonsState = new Dictionary<string, bool>();
            _buttonsState = new Dictionary<string, bool>();

            _game = game;
            _game.AddToUpdaters(this);
            _game.AddToContentLoader(this);
        }
        
        public void LoadContent()
        {
            _cmdDictionary = new Dictionary<string, ICommand>
            {
                {"generateDustOnClick" , new GenerateDustOnClick(_game,_game.InputsManager.MouseInput)}
            };

            _onHold = new Dictionary<List<string>, string>
            {
                { new List<string> {"LeftCLick"}, "generateDustOnClick"}
            };
            _onPress = new Dictionary<List<string>, string>();
            _onRelease = new Dictionary<List<string>, string>();
            _whileRelease = new Dictionary<List<string>, string>();
        }

        /// <summary>
        /// Update of InputsManager
        /// </summary>
        /// <param name="gameTime">Instance of GameTime, used to Update with the gameTime</param>
        public void Update(GameTime gameTime)
        {
            if (_gamePadInputs.IsActive) UpdateGamePad = true;
            else if (_keyboardInputs.IsActive) UpdateGamePad = false;

            if (UpdateGamePad)
            {
                _gamePadInputs.Update(gameTime);
            }
            else
            {
                _keyboardInputs.Update(gameTime);
                _mouseInputs.Update(gameTime);
            }
            GetButtonStateList();
            CheckButtons(gameTime);
        }

        public void CheckButtons(GameTime gameTime)
        {
            CheckOnPressButtons(gameTime);
            CheckOnHoldButtons(gameTime);
            CheckOnReleasedButtons(gameTime);
            CheckWhileReleasedButtons(gameTime);
        }

        public void CheckOnPressButtons(GameTime gameTime)
        {
            foreach (List<string> buttonList in _onPress.Keys)
            {
                bool listIsValid = true;
                foreach (string buttonName in buttonList)
                {
                    bool wasPressed;
                    bool isPressed;
                    _oldButtonsState.TryGetValue(buttonName, out wasPressed);
                    _buttonsState.TryGetValue(buttonName, out isPressed);
                    if (!(!wasPressed && isPressed))
                    {
                        listIsValid = false;
                        break;
                    }
                }
                if (listIsValid)
                {
                    ExecuteCommandOnPress(buttonList, gameTime);
                }
            }
        }

        public void CheckOnHoldButtons(GameTime gameTime)
        {
            foreach (List<string> buttonList in _onHold.Keys)
            {
                bool listIsValid = true;
                foreach (string buttonName in buttonList)
                {
                    bool wasPressed;
                    bool isPressed;
                    _oldButtonsState.TryGetValue(buttonName, out wasPressed);
                    _buttonsState.TryGetValue(buttonName, out isPressed);
                    if (!isPressed)
                    {
                        listIsValid = false;
                        break;
                    }
                }
                if (listIsValid)
                {
                    ExecuteCommandOnHold(buttonList, gameTime);
                }
            }
        }

        public void CheckOnReleasedButtons(GameTime gameTime)
        {
            foreach (List<string> buttonList in _onRelease.Keys)
            {
                bool listIsValid = true;
                foreach (string buttonName in buttonList)
                {
                    bool wasPressed;
                    bool isPressed;
                    _oldButtonsState.TryGetValue(buttonName, out wasPressed);
                    _buttonsState.TryGetValue(buttonName, out isPressed);
                    if (!(wasPressed && !isPressed))
                    {
                        listIsValid = false;
                        break;
                    }
                }
                if (listIsValid)
                {
                    ExecuteCommandOnRelease(buttonList, gameTime);
                }
            }
        }

        public void CheckWhileReleasedButtons(GameTime gameTime)
        {
            foreach (List<string> buttonList in _whileRelease.Keys)
            {
                bool listIsValid = true;
                foreach (string buttonName in buttonList)
                {
                    bool wasPressed;
                    bool isPressed;
                    _oldButtonsState.TryGetValue(buttonName, out wasPressed);
                    _buttonsState.TryGetValue(buttonName, out isPressed);
                    if (isPressed)
                    {
                        listIsValid = false;
                        break;
                    }
                }
                if (listIsValid)
                {
                    ExecuteCommandWhileRelease(buttonList, gameTime);
                }
            }
        }

        public void GetButtonStateList()
        {
            _oldButtonsState = _buttonsState;
            _buttonsState.Clear();
            foreach (IInput input in _inputs)
            {
                AddListToButtonList(input.GetInputButtons());
            }
        }

        public void AddListToButtonList(List<IInputButton> list)
        {
            foreach (IInputButton button in list)
            {
                _buttonsState.Add(button.Name, button.IsPressed);
            }
            list.Clear();
        }

        public Point GetMousePosition()
        {
            return MouseInput.GetMouseAbsolutePosition();
        }

        public void ExecuteCommand(Dictionary<List<string>, string> dictionary, List<string> key, GameTime gameTime)
        {
            string nomCmd;
            ICommand cmdToExe;
            dictionary.TryGetValue(key, out nomCmd);
            if (nomCmd == null)
            {
                throw new Exception("Error : IInputButton List not found as a dictionary key");
            }
            _cmdDictionary.TryGetValue(nomCmd, out cmdToExe);
            cmdToExe?.Execute(gameTime);
        }

        public void ExecuteCommandOnPress(List<string> buttons, GameTime gameTime)
        {
            ExecuteCommand(_onPress, buttons, gameTime);
        }

        public void ExecuteCommandOnRelease(List<string> buttons, GameTime gameTime)
        {
            ExecuteCommand(_onRelease, buttons, gameTime);
        }

        public void ExecuteCommandOnHold(List<string> buttons, GameTime gameTime)
        {
            ExecuteCommand(_onHold, buttons, gameTime);
        }

        public void ExecuteCommandWhileRelease(List<string> buttons, GameTime gameTime)
        {
            ExecuteCommand(_whileRelease, buttons, gameTime);
        }
    }
}
