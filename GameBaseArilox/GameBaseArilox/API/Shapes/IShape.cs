using System.Collections.Generic;

namespace GameBaseArilox.API.Shapes
{
    public interface IShape
    {
        List<ICoordinates> Points { get; set; }
        ICoordinates Center { get; }
    }
}
