using BonesOfTheFallen.Services.Graphics.Interface;
using System;

namespace BonesOfTheFallen.Services.Graphics;

public record class ReadOnlyPosition<T>(T X, T Y) : IReadOnlyPosition<T>
    where T : INumber<T>, new()
{
    public (T X, T Y) XY
    {
        get => (X, Y);
    }

    public static ReadOnlyPosition<T> operator +(ReadOnlyPosition<T> left, ReadOnlyPosition<T> right)
    {
        return new ReadOnlyPosition<T>(left.X + right.X, left.Y + right.Y);
    }

    public static ReadOnlyPosition<T> operator -(ReadOnlyPosition<T> left, ReadOnlyPosition<T> right)
    {
        return new ReadOnlyPosition<T>(left.X - right.X, left.Y - right.Y);
    }
}
