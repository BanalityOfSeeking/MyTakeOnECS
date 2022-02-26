using BonesOfTheFallen.Services.Graphics.Interface;
using System;

namespace BonesOfTheFallen.Services.Graphics;

public record class ReadOnlyCircle<T>(ReadOnlyPosition<T> Center, T Radius) : IReadOnlyCircle<T>
    where T : INumber<T>, new()
{
    public T Circumference => T.Parse(((T.One + T.One) * T.Create(MathF.PI) * Radius).ToString()!, default!);

    public static ReadOnlyCircle<T> operator +(ReadOnlyCircle<T> left, ReadOnlyCircle<T> right)
    {
        return new ReadOnlyCircle<T>(new ReadOnlyPosition<T>(left.Center.X + right.Center.X, left.Center.Y + right.Center.Y), left.Radius + right.Radius);
    }
    public static ReadOnlyCircle<T> operator +(ReadOnlyCircle<T> left, ReadOnlyPosition<T> right)
    {
        return new ReadOnlyCircle<T>(new ReadOnlyPosition<T>(left.Center.X + right.X, left.Center.Y + right.Y), left.Radius);
    }
    public static ReadOnlyCircle<T> operator +(ReadOnlyCircle<T> left,  T radius)
    {
        return new ReadOnlyCircle<T>(left.Center, left.Circumference + radius);
    }
    public static ReadOnlyCircle<T> operator -(ReadOnlyCircle<T> left, ReadOnlyCircle<T> right)
    {
        return left - right;
    }
    public static ReadOnlyCircle<T> operator -(ReadOnlyCircle<T> left, ReadOnlyPosition<T> right)
    {
        return new ReadOnlyCircle<T>(new ReadOnlyPosition<T>(left.Center.X - right.X, left.Center.Y - right.Y), left.Radius);
    }
    public static ReadOnlyCircle<T> operator -(ReadOnlyCircle<T> left, T right)
    {
        return new ReadOnlyCircle<T>(left.Center, left.Radius - right);
    }
}
