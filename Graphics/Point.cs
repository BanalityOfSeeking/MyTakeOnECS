using System;

namespace BonesOfTheFallen.Graphics
{
    public record Point<T> : IPoint<T> where T : INumber<T>
    {
        public Point(T top, T left)
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

        public virtual IPoint<T> MoveTo(T top, T left)
        {
            var dist = DistanceTo(new Point<T>(top, Left));
            return this with { Top =+dist.Top, Left =+dist.Left };
        }

        public virtual IPoint<T> DistanceTo(IPoint<T> other)
        {
            return new Point<T>(Top - other.Top, Left - other.Left);
        }
    }
}


