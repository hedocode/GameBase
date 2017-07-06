namespace GameBaseArilox.API
{
    public interface ISpriteAnimation : IAnimation
    {
        ISprite AnimatedSprite { get; set; }
    }
}
