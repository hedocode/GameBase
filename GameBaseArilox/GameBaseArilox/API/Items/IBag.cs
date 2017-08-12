namespace GameBaseArilox.API.Items
{
    interface IBag : IStuff, IInventory
    {
        int MaxVolume { get; set; }
    }
}
