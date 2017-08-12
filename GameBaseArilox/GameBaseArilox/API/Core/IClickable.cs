using GameBaseArilox.API.Graphic;

namespace GameBaseArilox.API.Core
{
    interface IClickable : IDisplayed
    {
        void OnClick();
        void OnHover();
        void OnPressed();
        void OnRelease();
    }
}
