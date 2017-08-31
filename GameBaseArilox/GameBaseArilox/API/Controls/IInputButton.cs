using GameBaseArilox.API.Enums;

namespace GameBaseArilox.API.Controls
{
    public interface IInputButton
    {
        InputType InputType { get; }
        string Name { get; }
        bool IsPressed { get; }
        bool IsReleased { get; }
    }
}
