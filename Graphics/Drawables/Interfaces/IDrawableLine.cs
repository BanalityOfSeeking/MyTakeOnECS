using Microsoft.Maui.Graphics;

namespace BonesOfTheFallen.Graphics
{
    public interface IDrawableLine
    {
        void Draw(ICanvas canvas, RectangleF dirtyRect);
        bool Equals(object? obj);
    }
}