using System;
using BonesOfTheFallen.Services.Graphics.Interface;
using Microsoft.Maui.Graphics;


namespace BonesOfTheFallen.Services.Graphics.Drawables;

public record DrawableLine : DrawablePoint
    {
        public DrawableLine(float left, float top, float distance, Orientation orientation) : base(left, top)
        {
            SideLength = distance;
            Orientation = orientation;
        }
        public DrawableLine(IPoint<float> start, float distance, Orientation orientation) : base(start.Left, start.Top)
        {
            SideLength = distance;
            Orientation = orientation;
        }

        protected DrawableLine(Line<float> original) : base(original)
        {
        }
        public override void Draw(ICanvas canvas, RectangleF dirtyRect)
        {
            canvas.StrokeColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
            if (Orientation == Orientation.Horizontal)
            {
                canvas.DrawLine(Left, Top, Left + SideLength, Top);
            }
            else
            {
                canvas.DrawLine(Left, Top, Left, Top + SideLength);
            }
        }
    }




