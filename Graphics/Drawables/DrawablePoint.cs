using System;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Graphics
{
    public record DrawablePoint<T> : Point<T>, IDrawable, IDrawablePoint<T> where T : INumber<T>
    {
        public DrawablePoint(T top, T left) : base(top, left)
        {
        }

        protected DrawablePoint(Point<T> original) : base(original)
        {
        }

        public void Draw(ICanvas canvas, RectangleF dirtyRect)
        {
            canvas.FillColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
            var top = float.Parse(Top.ToString()!);
            var left = float.Parse(Left.ToString()!);
            canvas.FillCircle(top, left, 1.0f);
        }
    }
}


