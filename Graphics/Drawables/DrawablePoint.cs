using System;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Graphics
{
    public record DrawablePoint : Point<float>, IDrawable, IDrawablePoint
    {
        public DrawablePoint(float top, float left) : base(top, left)
        {
        }

        protected DrawablePoint(Point<float> original) : base(original)
        {
        }

        public void Draw(ICanvas canvas, RectangleF dirtyRect)
        {
            canvas.FillColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
            canvas.FillCircle(Top, Left, 1.0f);
        }
    }
}


