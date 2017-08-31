using System.Collections.Generic;

namespace GameBaseArilox.API.Core
{
    public interface IAffected
    {
        List<IEffect> Effects { get; set; }
        bool Increase { get; set; }
        double TimeSpent { get; set; }
    }
}
