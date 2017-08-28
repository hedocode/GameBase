using GameBaseArilox.API.Detection;

namespace GameBaseArilox.API.Graphic
{
    public interface IDisplayed
    {
        ISprite Sprite { get; set; }
        IDetectionArea Hitbox { get; set; }
    }
}
