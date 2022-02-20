using System;
using BonesOfTheFallen.Services.Graphics.Drawables.Interfaces;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Services.Graphics.Drawables;

public record DrawableSquare : DrawablePoint, IMainDrawable, ISubDrawable
{
    public DrawableSquare(float top, float left, float sideLength) : base(top, left)
    {
        SideLength = sideLength;
    }

    protected DrawableSquare(Square<float> original) : base(original)
    {
    }

    public override void Draw(ICanvas canvas, RectangleF dirtyRect)
    {
        canvas.FillColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
        canvas.FillRectangle(Left, Top, SideLength, SideLength);
    }
}


