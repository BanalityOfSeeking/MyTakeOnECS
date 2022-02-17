using BonesOfTheFallen.Graphics;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;
using SkiaSharp.Views.Desktop;
using System.Windows.Forms;

namespace BonesOfTheFallen.Services.Components.Forms
{
    public partial class Form1 : Form
    {
        public readonly DrawingContainer Drawables = new();
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            skglControl1.PreviewKeyDown += Form1_PreviewKeyDown;
            skglControl1.PaintSurface += SkglControl1_PaintSurface;

            Drawables.Add(new DrawableSquare<float>(500, 500, 100));
        }

        private void Form1_PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Drawables.Drawables[0] =
                    (IDrawable)((IPoint<float>)Drawables.Drawables[0])
                        .MoveByOffset(0, -5);
                    break;
                case Keys.Down:
                    Drawables.Drawables[0] =
                    (IDrawable)((IPoint<float>)Drawables.Drawables[0])
                        .MoveByOffset(0, 5);
                    break;
                case Keys.Left:
                    Drawables.Drawables[0] =
                    (IDrawable)((IPoint<float>)Drawables.Drawables[0])
                        .MoveByOffset(-5, 0);
                    break;
                case Keys.Right:
                    Drawables.Drawables[0] =
                    (IDrawable)((IPoint<float>)Drawables.Drawables[0])
                        .MoveByOffset(5, 0);
                    break;
                default:
                    break;
            }
            skglControl1.Invalidate();
        }

        private void SkglControl1_PaintSurface(object? sender, SKPaintGLSurfaceEventArgs e)
        {
            e.Surface.Canvas.Clear();

            if (GameGraphics.GameCanvas == null)
            {             
                GameGraphics.GameCanvas = new SkiaCanvas() { Canvas = e.Surface.Canvas };

                GameGraphics.rectangle = RectangleF.FromLTRB(e.Info.Rect.Left, e.Info.Rect.Top, e.Info.Rect.Right, e.Info.Rect.Bottom);
            }
            Drawables.Draw();
        }
    }
}
