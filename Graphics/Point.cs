using BonesOfTheFallen.Services.Graphics.Interface;
using System;

namespace BonesOfTheFallen.Services.Graphics;

    public record Point<T> : IPoint<T>, ILine<T>, ICircle<T>, ISquare<T> where T : INumber<T>
    {
        public Point() : this(T.Zero, T.Zero)
        { }
        public Point(T left, T top)
        {
            Left = left;
            Top = top;
        }

        public IPoint<T> SetRadius(T radius)
        {
            return this with { Radius = radius };
        }
        public IPoint<T> SetSideLength(T side)
        {
            return this with { SideLength = side };
        }
        public T Top { get; init; } = T.Zero;
        public T Left { get; init; } = T.Zero;
        public T SideLength { get; init; } = T.Zero;
        public Orientation Orientation { get; init; } = Orientation.None;
        public T Radius { get; init; } = T.Zero;
        public override int GetHashCode()
        {
            return HashCode.Combine(Top, Left);
        }
        public IPoint<T> MoveTo(IPoint<T> other)
         => this with { Left = other.Left, Top = other.Top };

        public IPoint<T> MoveByOffset(T left, T top)
        {
            return this with { Left = Left + left, Top = Top + top };
        }

        public ISquare<T> LengthenSide(T Expansion)
        {
            return this with { SideLength = SideLength + Expansion };
        }
        public ISquare<T> ShrinkSide(T Contraction)
        {
            return this with { SideLength = SideLength - Contraction };
        }
        public ILine<T> Shrink(T Contraction)
        {
            return this with { SideLength = SideLength - Contraction };
        }
        public ICircle<T> Expand(T Expansion)
        {
            return this with { Radius = Radius + Expansion };
        }
        public ICircle<T> Contract(T Contraction)
        {
            return this with { Radius = Radius - Contraction };
        }
        public ILine<T> Extend(T Extension)
        {
            return this with { SideLength = SideLength + Extension };
        }
    }


