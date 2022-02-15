using System.Collections.Generic;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;

namespace BonesOfTheFallen.Graphics
{
    public static class GameGraphics
    {
        internal static SkiaCanvas GameCanvas = default!;
        internal static RectangleF rectangle = new(0, 0, 1600, 1000);
    }

    public sealed record DrawingContainer
    {
        private readonly List<IDrawable> Drawables = new();
        public void Add(IDrawable shape)
        {
            Drawables.Add(shape);
        }

        public void Draw()
        {
            Drawables.ForEach((shape) => shape.Draw(GameGraphics.GameCanvas, GameGraphics.rectangle));
        }
    }
}


