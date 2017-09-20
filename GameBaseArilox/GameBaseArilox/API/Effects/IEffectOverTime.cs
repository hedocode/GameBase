namespace GameBaseArilox.API.Effects
{
    public interface IEffectOverTime : ILimitedLifeTime
    {
        float Frequency { get; set; }
    }
}
