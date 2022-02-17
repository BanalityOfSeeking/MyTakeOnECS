using System;

namespace BonesOfTheFallen.Graphics
{
    public record Point<T> : IPoint<T> where T : INumber<T>
    {
        public Point(T left, T top)
        {
            Top = top;
            Left = left;
        }

        public T Top { get; init; } = default!;
        public T Left { get; init; } = default!;

        public override int GetHashCode()
        {
            return HashCode.Combine(Top, Left);
        }
        public IPoint<T> MoveTo(IPoint<T> other)
         => this with { Left = other.Left, Top = other.Top };

        public IPoint<T> MoveByOffset(T left, T top)
        {
             return this with { Left = Left + left, Top =  Top + top };
        }
    }
}


