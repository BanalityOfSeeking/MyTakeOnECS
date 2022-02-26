using System;
using BonesOfTheFallen.Services.Graphics.Interface;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Services.Graphics.Drawables;

public record DrawableRectangle : ReadOnlyRectangle<float>, IDrawable
{
    public DrawableRectangle(ReadOnlyPosition<float> left, ReadOnlyPosition<float> right, ReadOnlyPosition<float> top, ReadOnlyPosition<float> bottom) : base(left, right, top, bottom)
    {
    }

    protected DrawableRectangle(ReadOnlyRectangle<float> original) : base(original)
    {
    }

    public void Draw(ICanvas canvas, RectangleF dirtyRect)
    {
        canvas.FillColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
        canvas.FillRectangle(Left, Top, Right.X - Left.X, Bottom.Y - Top.Y);
    }
}


