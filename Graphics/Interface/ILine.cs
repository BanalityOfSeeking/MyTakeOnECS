using System;

namespace BonesOfTheFallen.Services.Graphics.Interface;

public interface ILine<T> : IPoint<T> where T : INumber<T>
{
    public IPoint<T> LineStart { get => new Point<T>(Top, Left); }
    public Point<T> LineEnd { get; }
}
