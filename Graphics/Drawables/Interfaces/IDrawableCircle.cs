using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Graphics
{
    public interface IDrawableCircle
    {
        void Draw(ICanvas canvas, RectangleF dirtyRect);
    }
}