using System;
using BonesOfTheFallen.Services.Graphics.Drawables.Interfaces;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Services.Graphics.Drawables;

public record DrawableCircle : DrawablePoint, IMainDrawable, ISubDrawable
{
    public DrawableCircle(float left, float top, float radius) : base(left, top)
    { 
        Radius = radius;
    }
    public DrawableCircle(Point<float> point, float radius) : base(point.Left, point.Top)
    {
        Radius = radius;
    }

    protected DrawableCircle(Circle<float> original) : base(original)
    {
    }
    public override void Draw(ICanvas canvas, RectangleF dirtyRect)
    {
        canvas.StrokeColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
        canvas.FillCircle(Left, Top, Radius);
    }
}

