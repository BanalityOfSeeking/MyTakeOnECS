using System;

namespace BonesOfTheFallen.Graphics
{
    public interface ICircle<T> : IPoint<T> where T : INumber<T>
    {
        public T Radius { get; }

        ICircle<T> Contract(T Contraction);
        ICircle<T> Expand(T Expansion);
    }

}
