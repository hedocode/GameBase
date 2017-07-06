namespace GameBaseArilox.API
{
    public interface IDisplayed : IScreenPositioned
    {
        ISprite Sprite { get; set; }
        IHitBox Hitbox { get; set; }
    }
}
