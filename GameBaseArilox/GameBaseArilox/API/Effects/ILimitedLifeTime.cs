namespace GameBaseArilox.API.Effects
{
    public interface ILimitedLifeTime
    {
        float Duration { get; set; }
        double ElapsedLifeTime { get; set; }
    }
}
