using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Graphics
{
    public interface IDrawablePoint
    {
        void Draw(ICanvas canvas, RectangleF dirtyRect);
    }
}