namespace GameBaseArilox.Core
{
    public interface ITextSpriteAnimation : IAnimation
    {
        ITextSprite AnimatedTextSprite { get; set; }
    }
}
