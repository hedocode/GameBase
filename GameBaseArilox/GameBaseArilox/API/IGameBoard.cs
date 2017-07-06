namespace GameBaseArilox.API
{
    public interface IGameBoard
    {
        IGameGrid GameGrid { get; set; }
        IBackground Background { get; set; }
    }
}
