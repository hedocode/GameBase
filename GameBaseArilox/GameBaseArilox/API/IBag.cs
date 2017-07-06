namespace GameBaseArilox.API
{
    interface IBag : IStuff, IInventory
    {
        int MaxVolume { get; set; }
    }
}
