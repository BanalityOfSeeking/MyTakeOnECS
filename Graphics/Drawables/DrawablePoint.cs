using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Services.Graphics.Drawables;

public record class DrawablePosition(float X, float Y, Color Color) : ReadOnlyPosition<float>(X, Y), IDrawable
{ 
    public void Draw(ICanvas canvas, RectangleF dirtyRect)
    {
        canvas.StrokeSize = 1;
        canvas.StrokeColor = Color;
        canvas.DrawCircle(new PointF(X, Y), 1);
    }
}