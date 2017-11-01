using GameBaseArilox.API.Graphic;

namespace GameBaseArilox.API.Core
{
    public interface IClickable : IDisplayed
    {
        void OnClick();
        void OnHover();
        void OnPressed();
        void OnRelease();
    }
}
