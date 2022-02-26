using System;

namespace BonesOfTheFallen.Services.Graphics.Interface;

public interface IReadOnlyRectangle<T> 
    where T : INumber<T>, new()
{
    public ReadOnlyPosition<T> Left { get; }
    public ReadOnlyPosition<T> Right { get; }
    public ReadOnlyPosition<T> Top { get; }
    public ReadOnlyPosition<T> Bottom { get; }

    T DistanceXToX => T.Create(Right.X - Left.X);
    T DistanceYToY => T.Create(Top.Y - Right.Y);

    ReadOnlyPosition<T> DistanceTopToBottom => new(Bottom.X - Top.X, Bottom.Y - Top.Y);
    public static IReadOnlyRectangle<T> operator +(IReadOnlyRectangle<T> left, IReadOnlyRectangle<T> right)
    {
         return new ReadOnlyRectangle<T>(left.Left + right.Left, left.Top + right.Top, left.Right + right.Right, left.Bottom + right.Bottom);
    }
    public static IReadOnlyRectangle<T> operator -(IReadOnlyRectangle<T> left, IReadOnlyRectangle<T> right)
    {
        return new ReadOnlyRectangle<T>(left.Left - right.Left, left.Top - right.Top, left.Right - right.Right, left.Bottom - right.Bottom);
    }
}
