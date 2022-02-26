using System.Collections.Generic;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Services.Graphics;

public static class GameGraphics
{
    internal static ICanvas GameCanvas = default!;
    internal static RectangleF rectangle = default!;
}
public record FigureContainer
{
    internal static PathF GetFigure() => new();
    // gather figure DrawablePoints
    internal void SetFigure(PathF figure)
    {
        DrawablePaths.Add(figure);
    }
    internal readonly List<PathF> DrawablePaths = new();
    internal PathF this[int index] { get => DrawablePaths[index]; set => DrawablePaths[index] = value; }
    public void DrawFigures(ICanvas canvas, RectangleF rectangle)
    {
        int i = 0;
        foreach (var dg in DrawablePaths)
        {
            canvas.FillColor = dg.PathColors[i];
            dg.Draw(canvas, rectangle);
        }        
    }
}


