using BonesOfTheFallen.Services.Graphics.Interface;
using System;

namespace BonesOfTheFallen.Services.Graphics;

public record class ReadOnlyRectangle<T> : IReadOnlyRectangle<T> where T : INumber<T>, new()
{
    public ReadOnlyRectangle(ReadOnlyPosition<T> left, ReadOnlyPosition<T> right, ReadOnlyPosition<T> top, ReadOnlyPosition<T> bottom)
    {
        Left = left;
        Top = top;
        Right = right;
        Bottom = bottom;
    }
    public ReadOnlyPosition<T> Left { get; }
    public ReadOnlyPosition<T> Top { get; }
    public ReadOnlyPosition<T> Right { get; }
    public ReadOnlyPosition<T> Bottom { get;}

}


