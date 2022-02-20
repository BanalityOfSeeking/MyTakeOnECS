using System;

namespace BonesOfTheFallen.Services.Graphics.Interface;
    // Always Left Top Set for Point.
    // If SideLength & Orientation not set to Orientation.None, Point is a line.
    // if Radius Set Point is a circle
    // if SideLength and Orientation equals Orientation.None, Point is a square.

    public interface ICircle<T> : IPoint<T> where T : INumber<T>
    {
    }
    public interface ILine<T> : IPoint<T> where T : INumber<T>
    {
    }
    public interface ISquare<T> : IPoint<T> where T : INumber<T>
    {
    }
    public interface IPoint<T> where T : INumber<T>
    {
        T Left { get; init; }
        Orientation Orientation { get; init; }
        T Radius { get; init; }
        T SideLength { get; init; }
        T Top { get; init; }

        ICircle<T> Contract(T Contraction);
        ICircle<T> Expand(T Expansion);
        ILine<T> Extend(T Extension);
        ISquare<T> LengthenSide(T Expansion);
        IPoint<T> MoveByOffset(T left, T top);
        IPoint<T> MoveTo(IPoint<T> other);
        IPoint<T> SetRadius(T radius);
        IPoint<T> SetSideLength(T side);
        ILine<T> Shrink(T Contraction);
        ISquare<T> ShrinkSide(T Contraction);
    }
