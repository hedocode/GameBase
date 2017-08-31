using System;
using System.Collections.Generic;
using GameBaseArilox.API.Controls;
using GameBaseArilox.API.Core;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Controls
{
    public class InputsManager : IUpdater, IContentLoader
    {
        private Dictionary<string, ICommand> _cmdDictionary;
        
        private readonly KeyboardInputs _keyboardInputs;
        private readonly GamePadInputs _gamePadInputs;
        private readonly MouseInputs _mouseInputs;

        public MouseInputs MouseInput => _mouseInputs;
        public KeyboardInputs KeyboardInput => _keyboardInputs;
        public GamePadInputs GamePadInputs => _gamePadInputs;

        private Dictionary<List<IInputButton>, string> _onPress;     // when pressed : one time
        private Dictionary<List<IInputButton>, string> _onHold;      // while hold
        private Dictionary<List<IInputButton>, string> _onRelease;   // when button is released
        private Dictionary<List<IInputButton>, string> _whileRelease;// while button is realeased

        private Dictionary<IInputButton,bool> _oldButtonsState;
        private Dictionary<IInputButton,bool> _buttonsState;

        private List<IInputButton> _gamePadButtons;
        private List<IInputButton> _mouseButtons;
        private List<IInputButton> _keyboardButtons;

        public bool UpdateGamePad;

        public InputsManager(GameModel game)
        {
            _mouseInputs = new MouseInputs();
            _gamePadInputs = new GamePadInputs();
            _keyboardInputs = new KeyboardInputs();

            _oldButtonsState = new Dictionary<IInputButton, bool>();
            _buttonsState = new Dictionary<IInputButton, bool>();

            _gamePadButtons = new List<IInputButton>();
            _mouseButtons = new List<IInputButton>();
            _keyboardButtons = new List<IInputButton>();
            game.AddToUpdaters(this);
            game.AddToContentLoader(this);
        }
        
        public void LoadContent()
        {

            _cmdDictionary = new Dictionary<string, ICommand>();

            _onHold = new Dictionary<List<IInputButton>, string>();
            _onPress = new Dictionary<List<IInputButton>, string>();
            _onRelease = new Dictionary<List<IInputButton>, string>();
            _whileRelease = new Dictionary<List<IInputButton>, string>();
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
            FusioningButtonList();
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
            foreach (List<IInputButton> buttonList in _onPress.Keys)
            {
                bool listIsValid = true;
                foreach (IInputButton button in buttonList)
                {
                    bool wasPressed;
                    bool isPressed;
                    _oldButtonsState.TryGetValue(button, out wasPressed);
                    _buttonsState.TryGetValue(button, out isPressed);
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
            foreach (List<IInputButton> buttonList in _onHold.Keys)
            {
                bool listIsValid = true;
                foreach (IInputButton button in buttonList)
                {
                    bool wasPressed;
                    bool isPressed;
                    _oldButtonsState.TryGetValue(button, out wasPressed);
                    _buttonsState.TryGetValue(button, out isPressed);
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
            foreach (List<IInputButton> buttonList in _onRelease.Keys)
            {
                bool listIsValid = true;
                foreach (IInputButton button in buttonList)
                {
                    bool wasPressed;
                    bool isPressed;
                    _oldButtonsState.TryGetValue(button, out wasPressed);
                    _buttonsState.TryGetValue(button, out isPressed);
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
            foreach (List<IInputButton> buttonList in _whileRelease.Keys)
            {
                bool listIsValid = true;
                foreach (IInputButton button in buttonList)
                {
                    bool wasPressed;
                    bool isPressed;
                    _oldButtonsState.TryGetValue(button, out wasPressed);
                    _buttonsState.TryGetValue(button, out isPressed);
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

        public void FusioningButtonList()
        {
            _oldButtonsState = _buttonsState;
            _buttonsState.Clear();

            AddListToButtonList(_keyboardButtons);
            AddListToButtonList(_mouseButtons);
            AddListToButtonList(_gamePadButtons);
        }

        public void AddListToButtonList(List<IInputButton> list)
        {
            foreach (IInputButton button in list)
            {
                _buttonsState.Add(button, button.IsPressed);
            }
            list.Clear();
        }

        public Point GetMousePosition()
        {
            return MouseInput.GetMouseAbsolutePosition();
        }

        public void ExecuteCommand(Dictionary<List<IInputButton>, string> dictionary, List<IInputButton> key, GameTime gameTime)
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

        public void ExecuteCommandOnPress(List<IInputButton> buttons, GameTime gameTime)
        {
            ExecuteCommand(_onPress, buttons, gameTime);
        }

        public void ExecuteCommandOnRelease(List<IInputButton> buttons, GameTime gameTime)
        {
            ExecuteCommand(_onRelease, buttons, gameTime);
        }

        public void ExecuteCommandOnHold(List<IInputButton> buttons, GameTime gameTime)
        {
            ExecuteCommand(_onHold, buttons, gameTime);
        }

        public void ExecuteCommandWhileRelease(List<IInputButton> buttons, GameTime gameTime)
        {
            ExecuteCommand(_whileRelease, buttons, gameTime);
        }
    }
}
