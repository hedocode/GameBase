using GameBaseArilox.API.Controls;
using GameBaseArilox.API.Enums;

namespace GameBaseArilox.Implementation.Controls
{
    struct InputButton : IInputButton
    {
        public InputType InputType { get; }
        public string Name { get; }
        public bool IsPressed => _isPressed;
        public bool IsReleased => !_isPressed;

        private readonly bool _isPressed;

        public InputButton(string name, bool isPressed, InputType inputType = InputType.Keyboard)
        {
            InputType = inputType;
            Name = name;
            _isPressed = isPressed;
        }
    }
}
