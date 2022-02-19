using System;
using System.Collections.Generic;
using System.Numerics;
namespace BonesOfTheFallen.Services.Components
{
    public struct Position<TResult> : IEquatable<Position<TResult>> where TResult : struct, INumber<TResult>
    {
        public TResult X;
        public TResult Y;
        public TResult Z;
        
        private static readonly TResult ResultZero = TResult.Zero;

        public Position(TResult x, TResult y, TResult z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Position(Span<TResult> xyz)
        {
            if(xyz.Length < 3)
            {
                X = ResultZero;
                Y = ResultZero;
                Z = ResultZero;
            }
            else
            {
                X = xyz[0];
                Y = xyz[1];
                Z = xyz[2];
            }
        }
        public Position(Vector<TResult> xyz)
        {

            if (xyz[2] == default!)
            {
                X = ResultZero;
                Y = ResultZero;
                Z = ResultZero;
            }
            else
            {
                X = xyz[0];
                Y = xyz[1];
                Z = xyz[2];
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Position<TResult> position && Equals(position);
        }

        public bool Equals(Position<TResult> other)
        {
            return EqualityComparer<TResult>.Default.Equals(X, other.X) &&
                   EqualityComparer<TResult>.Default.Equals(Y, other.Y) &&
                   EqualityComparer<TResult>.Default.Equals(Z, other.Z);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public static bool operator ==(Position<TResult> left, Position<TResult> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Position<TResult> left, Position<TResult> right)
        {
            return !(left == right);
        }
    }
}
