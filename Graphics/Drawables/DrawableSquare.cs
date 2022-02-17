using System;
using BonesOfTheFallen.Services.Graphics.Drawables.Interfaces;
using BonesOfTheFallen.Services.Graphics.Interface;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Services.Graphics.Drawables;

public record DrawableSquare<T> : Square<T>, ISquare<T>, IDrawableSquare<T> where T : INumber<T>
{
    public DrawableSquare(T top, T left, T sideLength) : base(top, left, sideLength)
    {
    }

    protected DrawableSquare(Square<T> original) : base(original)
    {
    }

    public void Draw(ICanvas canvas, RectangleF dirtyRect)
    {
        canvas.FillColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
        var left = float.Parse(Left.ToString()!);
        var top = float.Parse(Top.ToString()!);
        var side = float.Parse(SideLength.ToString()!);
        canvas.FillRectangle(left, top, side, side);
    }
}


