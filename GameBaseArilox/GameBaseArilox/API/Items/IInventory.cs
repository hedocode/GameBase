using System.Collections.Generic;

namespace GameBaseArilox.API.Items
{
    interface IInventory
    {
        List<IItem> Content { get; set; }
    }
}
