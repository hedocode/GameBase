using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Detection
{ 
    public interface IDetectionArea
    {
        bool Contains(Point point);
        bool Intersects(IDetectionArea detectionArea);
    }
}