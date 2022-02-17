using System;

namespace BonesOfTheFallen.Services.Graphics.Interface;

public interface ISquare<T> : IPoint<T> where T : INumber<T>
{
    public T SideLength { get; }
}

