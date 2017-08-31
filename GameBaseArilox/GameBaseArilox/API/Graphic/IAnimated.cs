namespace GameBaseArilox.API.Graphic
{
    public interface IAnimated
    {
        string CurrentAnimation { get; set; }
        int CurrentFrame { get; set; }
    }
}
