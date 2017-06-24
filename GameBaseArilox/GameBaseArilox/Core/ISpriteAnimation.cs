namespace GameBaseArilox.Core
{
    public interface ISpriteAnimation : IAnimation
    {
        ISprite AnimatedSprite { get; set; }
    }
}
