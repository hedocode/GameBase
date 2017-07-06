namespace GameBaseArilox.API
{
    public interface ITextSpriteAnimation : IAnimation
    {
        ITextSprite AnimatedTextSprite { get; set; }
    }
}
