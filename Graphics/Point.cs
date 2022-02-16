using System;

namespace BonesOfTheFallen.Graphics
{
    public record Point<T> : IPoint<T> where T : INumber<T>
    {
        public Point(T left, T top)
        {
            Top=top;
            Left=left;
        }

        public T Top { get; init; } = default!;
        public T Left { get; init; } = default!;

        public override int GetHashCode()
        {
            return HashCode.Combine(Top, Left);
        }

        public virtual IPoint<T> MoveTo(T left, T top)
        {
            var dist = DistanceTo(new Point<T>(left, top));
            return this with { Left = Left - dist.Left, Top = Top - dist.Top };
        }

        public virtual IPoint<T> DistanceTo(IPoint<T> other)
        {
            return new Point<T>(Left - other.Left, Top - other.Top);
        }
    }
}


