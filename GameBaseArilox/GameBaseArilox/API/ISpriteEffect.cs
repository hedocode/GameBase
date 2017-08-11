namespace GameBaseArilox.API
{
    public interface ISpriteEffect : IEffect
    {
        ISprite AffectedSprite { get; set; }
    }
}
