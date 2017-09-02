namespace GameBaseArilox.API.Detection
{ 
    public interface IDetectionArea
    {
        bool Detect();
        void OnDetection();
    }
}