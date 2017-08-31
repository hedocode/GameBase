namespace GameBaseArilox.API.Core
{
    public interface IEffectOverTime
    {
        float Duration { get; set; }
        float TimeSpent { get; set; }
        float Speed { get; set; }
    }
}
