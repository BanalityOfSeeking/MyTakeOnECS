using System;
using BonesOfTheFallen.Services.Graphics.Drawables.Interfaces;
using BonesOfTheFallen.Services.Graphics.Interface;
using Microsoft.Maui.Graphics;


namespace BonesOfTheFallen.Services.Graphics.Drawables;

public record DrawableLine : Line<float>, ILine<float>, IDrawableLine<float>, IMainDrawable, ISubDrawable
{
    public DrawableLine(float startLeft, float startTop, float distance, Orientation orientation) : base(new Point<float>(startLeft, startTop), distance, orientation)
    {
    }
    public DrawableLine(IPoint<float> start, float distance, Orientation orientation) : base(start, distance, orientation)
    {
    }

    protected DrawableLine(Line<float> original) : base(original)
    {
    }
    public float Offset { get; init; } = default!;
    public void Draw(ICanvas canvas, RectangleF dirtyRect)
    {
        canvas.StrokeColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
        if (Orientation == Orientation.Horizontal)
        {
            canvas.DrawLine(LineStart.Left, LineStart.Top, LineStart.Left + SideLength, LineStart.Top);
        }
        else
        {
            canvas.DrawLine(LineStart.Left, LineStart.Top, LineStart.Left, LineStart.Top + SideLength);
        }
    }
}




