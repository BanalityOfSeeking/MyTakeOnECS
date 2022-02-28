using System.Collections.Generic;
using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Services.Graphics;

public record class DrawableContainer
{
    // gather figure DrawablePoints
    internal void AddDrawing(IDrawable drawing, Color color)
    {
        Drawables.Add((drawing, color));
    }
    internal readonly List<(IDrawable drawing, Color color)> Drawables = new();
    public void Draw(ICanvas canvas, RectangleF rectangle)
    {
        foreach (var (drawing, color) in Drawables)
        {
            canvas.StrokeColor = color;
            drawing.Draw(canvas, rectangle);
        }        
    }
}


