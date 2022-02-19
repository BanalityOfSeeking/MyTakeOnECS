using BonesOfTheFallen.Services.Graphics.Interface;
using System;

namespace BonesOfTheFallen.Services.Graphics;

    public enum Orientation
    {
        Horizontal,
        Vertical,
    }
public record Line<T> : Point<T>, IPoint<T>, ILine<T> where T : INumber<T>
{
    public Line(IPoint<T> start, T distance, Orientation orientation) : base(start.Left, start.Top)
    {
        Orientation = orientation;
        SideLength = distance;
    }
    public Orientation Orientation { get; init; }
    public IPoint<T> LineStart { get => new Point<T>(Left, Top); }
}