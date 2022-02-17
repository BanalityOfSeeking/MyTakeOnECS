using Microsoft.Maui.Graphics;
using System;

namespace BonesOfTheFallen.Graphics
{
    public record DrawableLine<T> : Line<T>, IDrawableLine<T> where T : INumber<T>
    {
        public DrawableLine(IDrawablePoint<T> start, T distance) : base(start, distance, Orientation.Horizontal)
        {
        }

        protected DrawableLine(Line<T> original) : base(original)
        {
        }

        public void Draw(ICanvas canvas, RectangleF dirtyRect)
        {
            canvas.FillColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
            var lst = float.Parse(LineStart.Top.ToString()!);
            var lsl = float.Parse(LineStart.Left.ToString()!);
            var let = float.Parse(LineEnd.Top.ToString()!);
            var lel = float.Parse(LineEnd.Left.ToString()!);
            canvas.DrawLine(lsl, lst, lel, let);
        }
    }
}

