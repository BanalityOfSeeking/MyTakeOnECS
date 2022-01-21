namespace BonesOfTheFallen.Services
{
    public interface IPosition
    {
        ref bool HasHorizontalRef { get; }
        ref bool HasVerticalRef { get; }
        ref bool Monster { get; }
        ref double XRef { get; }
        ref double YRef { get; }
        ref double ZRef { get; }
    }
}