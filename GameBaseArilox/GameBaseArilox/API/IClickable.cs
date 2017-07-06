namespace GameBaseArilox.API
{
    interface IClickable : IDisplayed
    {
        void OnClick();
        void OnHover();
        void OnPressed();
        void OnRelease();
    }
}
