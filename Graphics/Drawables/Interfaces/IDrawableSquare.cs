using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Graphics
{
    public interface IDrawableSquare
    {
        void Draw(ICanvas canvas, RectangleF dirtyRect);
    }
}