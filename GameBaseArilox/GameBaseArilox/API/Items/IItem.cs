using GameBaseArilox.API.Core;

namespace GameBaseArilox.API.Items
{
    public interface IItem : INamed
    {
        int ItemId { get; set; }
        float Weight { get; set; }
        float Volume { get; set; }
    }
}
