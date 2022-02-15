using System;

namespace BonesOfTheFallen.Graphics
{
    public interface ISquare<T> : IPoint<T> where T : INumber<T>
    {
        public T SideLength { get; }
    }
}

