using System.Collections.Generic;

namespace GameBaseArilox.API.Shapes
{
    public interface IShape
    {
        float Top { get; }
        float Bot { get; }
        float Right { get; }
        float Left { get; }
        
        List<ICoordinates> Points { get; set; }
        ICoordinates Center { get; }
    }
}
