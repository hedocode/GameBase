using System.Collections.Generic;

namespace GameBaseArilox.API
{
    interface IInventory
    {
        List<IItem> Content { get; set; }
    }
}
