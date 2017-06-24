namespace GameBaseArilox.Core
{
    public interface IGameEntity : INamed, IMoveableGameElement
    {
        ISprite Sprite { get; set; }
    }
}
