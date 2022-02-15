using System;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Graphics
{
    public record DrawableCircle : Circle<float>, IDrawable, IDrawableCircle
    {
        public DrawableCircle(float radius, IPoint<float> center) : base(radius, center)
        {
        }

        protected DrawableCircle(Circle<float> original) : base(original)
        {
        }

        public void Draw(ICanvas canvas, RectangleF dirtyRect)
        {
            canvas.FillColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
            canvas.FillCircle(Top, Left, Radius);
        }
    }
}

