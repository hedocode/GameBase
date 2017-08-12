using GameBaseArilox.API.Core;

namespace GameBaseArilox.API.Graphic
{
    public interface IDisplayed : IScreenPositioned
    {
        ISprite Sprite { get; set; }
        IHitBox Hitbox { get; set; }
    }
}
