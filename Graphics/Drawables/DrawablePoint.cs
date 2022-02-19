using System;
using BonesOfTheFallen.Services.Graphics.Drawables.Interfaces;
using BonesOfTheFallen.Services.Graphics.Interface;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Services.Graphics.Drawables;

    public record DrawablePoint : Point<float>, IPoint<float>, IDrawable, IDrawablePoint<float>, IMainDrawable, ISubDrawable
    {
        public DrawablePoint(float left, float top) : base(left, top)
        {
        }

        protected DrawablePoint(Point<float> original) : base(original)
        {
        }
        public float Offset { get; init; } = default!;
        public void Draw(ICanvas canvas, RectangleF dirtyRect)
        {
            canvas.FillColor = Color.FromRgb(Random.Shared.Next(50, 255), Random.Shared.Next(50, 255), Random.Shared.Next(50, 255));
    
            canvas.FillCircle(Left, Top, 1.0f);
        }
    }


