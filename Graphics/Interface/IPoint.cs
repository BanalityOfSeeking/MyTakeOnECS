using System;

namespace BonesOfTheFallen.Graphics
{
    public interface IPoint<T> where T : INumber<T>
    {

        public T Top { get; }
        public T Left { get; }

        IPoint<T> DistanceTo(IPoint<T> other);
        IPoint<T> MoveTo(T left, T top);
    }
}

