using System;
using BonesOfTheFallen.Services.Graphics.Interface;
using Microsoft.Maui.Graphics;


namespace BonesOfTheFallen.Services.Graphics.Drawables;

public record DrawableLine : ReadOnlyLine<float>, IReadOnlyLine<float>, IDrawable
{
    public DrawableLine(ReadOnlyPosition<float> Origin, ReadOnlyPosition<float> End) : base(Origin, End)
    {
    }

    public DrawableLine(float x1, float y1, float x2, float y2) : base(x1, y1, x2, y2)
    {
    }

    protected DrawableLine(ReadOnlyLine<float> original) : base(original)
    {
    }

    public void Draw(ICanvas canvas, RectangleF dirtyRect)
    {
        canvas.StrokeColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));

        canvas.DrawLine(Origin.X, Origin.Y, End.X, End.Y);
    }
}




