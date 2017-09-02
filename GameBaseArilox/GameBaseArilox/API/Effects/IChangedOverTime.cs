namespace GameBaseArilox.API.Effects
{
    public interface IChangedOverTime
    {
        double TimeSpent { get; set; }
        bool Increase { get; set; }
    }
}
