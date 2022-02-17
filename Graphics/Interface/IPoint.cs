using System;

namespace BonesOfTheFallen.Services.Graphics.Interface;

public interface IPoint<T> where T : INumber<T>
{
    public T Top { get; init; }
    public T Left { get; init; }

    IPoint<T> MoveByOffset(T left, T top);
    IPoint<T> MoveTo(IPoint<T> point);
}

