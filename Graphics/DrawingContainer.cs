using System.Collections.Generic;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Services.Graphics;

public static class GameGraphics
{
    internal static ICanvas GameCanvas = default!;
    internal static RectangleF rectangle = default!;
}

public sealed record DrawingContainer
{
    internal readonly List<IDrawable> Drawables = new();
    internal bool Drawn = false;
    public void Add(IDrawable shape)
    {
        Drawables.Add(shape);
    }

    public void Draw()
    {
        Drawables.ForEach((shape) => shape.Draw(GameGraphics.GameCanvas, GameGraphics.rectangle));
    }
}


