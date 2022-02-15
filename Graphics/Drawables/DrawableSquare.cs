using System;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Graphics
{
    public record DrawableSquare : Square<float>, IDrawable, IDrawableSquare
    {
        public DrawableSquare(float top, float left, float sideLength) : base(top, left, sideLength)
        {
        }

        protected DrawableSquare(Square<float> original) : base(original)
        {
        }

        public void Draw(ICanvas canvas, RectangleF dirtyRect)
        {
            canvas.FillColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
            canvas.DrawRectangle(Top, Left, SideLength, SideLength);
        }
    }
}


