using BonesOfTheFallen.Services.Graphics.Interface;
using System;

namespace BonesOfTheFallen.Services.Graphics;

    public record Point<T> : IPoint<T> where T : INumber<T>
    {
        public Point() : this(T.Zero,T.Zero)
        { }
        public Point(T left, T top)
        {
            Left = left;
            Top = top;
        }

        public Point<T> SetRadius(T radius)
        {
            return this with { Radius = radius };
        }
        public Point<T> SetSideLength(T side)
        {
            return this with { SideLength = side };
        }
        public T Top { get; init; } = default!;
        public T Left { get; init; } = default!;
        public T SideLength { get; init; } = default!;
        public T Radius {get; init;} = default!;
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
            if(SideLength != default!)
            {
                return (ISquare<T>)(this with { SideLength = SideLength + Expansion });
            }
            return (ISquare<T>)(this);
        }

        public ISquare<T> ShrinkSide(T Contraction)
        {
            if(SideLength - Contraction > T.Zero)
            {
                return (ISquare<T>)(this with { SideLength = SideLength - Contraction });
            }
            return (ISquare<T>)this;
        }

        public ICircle<T> Expand(T Expansion)
        {
            if(Radius != default!)
            {
                return (ICircle<T>)(this with { Radius = Radius + Expansion });
            }
            return (ICircle<T>)this;
        }

        public ICircle<T> Contract(T Contraction)
        {
            if(Radius - Contraction > T.Zero)
            {
                return (ICircle<T>)(this with { Radius = Radius - Contraction });
            }
            return (ICircle<T>)this;
        }
    }


