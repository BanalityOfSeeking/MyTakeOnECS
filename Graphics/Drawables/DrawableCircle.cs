using System;
using BonesOfTheFallen.Services.Graphics.Drawables.Interfaces;
using BonesOfTheFallen.Services.Graphics.Interface;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Services.Graphics.Drawables;

public record DrawableCircle : Circle<float>, ICircle<float>, IDrawableCircle<float>, IMainDrawable, ISubDrawable
{
    public DrawableCircle(Point<float> center, float radius) : base(radius, center)
    {
    }

    protected DrawableCircle(Circle<float> original) : base(original)
    {
    }
    public float Offset { get; init; } = default!;
    public void Draw(ICanvas canvas, RectangleF dirtyRect)
    {
        canvas.StrokeColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
        canvas.FillCircle(Left, Top, Radius);
    }
}

