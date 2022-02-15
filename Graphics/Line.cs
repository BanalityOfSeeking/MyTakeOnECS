using System;

namespace BonesOfTheFallen.Graphics
{
    public enum Orientation
    {
        Horizontal,
        Vertical,
    }
    public record Line<T> : Point<T>, ILine<T> where T : INumber<T>
    {
        public Line(IPoint<T> start, T distance, Orientation orientation) : base(start.Top, start.Left)
        {
            LineStart = start;
            LineEnd = (Point<T>)start;
            if (orientation == Orientation.Horizontal)
            {
                LineEnd = LineEnd with { Left =+distance };
            }
            else
            {
                LineEnd = LineEnd with { Top =+distance };
            }

        }

        public Point<T> LineEnd { get; init; }

        public IPoint<T> LineStart { get; init; }

        public IPoint<T> Distance => LineStart.DistanceTo(LineEnd);
    }
}

