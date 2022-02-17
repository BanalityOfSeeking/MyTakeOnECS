using System;

namespace BonesOfTheFallen.Services.Graphics.Interface;

public interface ICircle<T> : IPoint<T> where T : INumber<T>
{
    public T Radius { get; }

    public ICircle<T> Expand(T Expansion);
    public ICircle<T> Contract(T Contraction);

}
