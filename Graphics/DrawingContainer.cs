using System.Collections.Generic;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Services.Graphics;

public static class GameGraphics
    {
        internal static ICanvas GameCanvas = default!;
        internal static RectangleF rectangle = default!;
    }
internal class DrawablePath : PathF, IDrawable
{
    public List<Color> PathColors = new();
    public void Draw(ICanvas canvas, RectangleF dirtyRect)
    {
        canvas.FillPath(this);        
    }
}
public record FigureContainer
{
    internal static DrawablePath GetFigure() => new();
    // gather figure DrawablePoints
    internal void SetFigure(DrawablePath figure)
    {
        DrawablePaths.Add(figure);
    }
    internal readonly List<DrawablePath> DrawablePaths = new();
    internal DrawablePath this[int index] { get => DrawablePaths[index]; set => DrawablePaths[index] = value; }
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


