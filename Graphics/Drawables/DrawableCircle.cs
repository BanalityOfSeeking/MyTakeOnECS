using System;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Graphics
{
    public record DrawableCircle<T> : Circle<T>, IDrawableCircle<T> where T : INumber<T>
    {
        public DrawableCircle(T radius, IPoint<T> center) : base(radius, center)
        {
        }

        protected DrawableCircle(Circle<T> original) : base(original)
        {
        }

        public void Draw(ICanvas canvas, RectangleF dirtyRect)
        {
            canvas.FillColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
            var left = float.Parse(Left.ToString()!); 
            var top = float.Parse(Top.ToString()!);
            var radius = float.Parse(Radius.ToString()!); 
            canvas.FillCircle(left,top, radius);
        }
    }
}

