using System;
using BonesOfTheFallen.Services.Graphics.Interface;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Services.Graphics.Drawables;

public record class DrawableCircle(ReadOnlyPosition<float> Center, float Radius) : ReadOnlyCircle<float>(Center, Radius), IReadOnlyCircle<float>, IDrawable
{

    protected DrawableCircle(ReadOnlyCircle<float> original) : this(original.Center, original.Radius)
    {
    }

    public void Draw(ICanvas canvas, RectangleF dirtyRect)
    {
        canvas.StrokeColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
        canvas.FillCircle(Center.X, Center.Y, Radius);
    }
}

