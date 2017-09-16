using System.Collections.Generic;

namespace GameBaseArilox.API.Controls
{
    public interface IInput
    {
        List<IInputButton> GetInputButtons();
    }
}
