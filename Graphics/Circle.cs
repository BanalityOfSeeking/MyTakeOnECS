using System;

namespace BonesOfTheFallen.Graphics
{
    public record Circle<T> : Point<T>, ICircle<T> where T : INumber<T>
    {
        public Circle(T radius, IPoint<T> center) : base(center.Top, center.Left)
        {
            Radius=radius;
        }

        public T Radius { get; init; }
        public ICircle<T> Expand(T Expansion) => this with { Radius =+Expansion };
        public ICircle<T> Contract(T Contraction) => this with { Radius =-Contraction };
    }
}

