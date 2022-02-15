using Microsoft.Maui.Graphics;
using System;

namespace BonesOfTheFallen.Graphics
{
    public record DrawableLine : Line<float>, IDrawable, IDrawableLine
    {
        public DrawableLine(IPoint<float> start, float distance) : base(start, distance, Orientation.Horizontal)
        {
        }

        protected DrawableLine(Line<float> original) : base(original)
        {
        }

        public void Draw(ICanvas canvas, RectangleF dirtyRect)
        {
            canvas.FillColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
            canvas.DrawLine(LineStart.Top, LineStart.Left, LineEnd.Top, LineEnd.Left);
        }
    }
}

