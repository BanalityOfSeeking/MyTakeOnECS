using BonesOfTheFallen.Services.Graphics;
using BonesOfTheFallen.Services.Graphics.Drawables;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;
using SkiaSharp.Views.Desktop;
using System.Windows.Forms;

namespace BonesOfTheFallen.Services.Components.Forms
{
    public partial class Form1 : Form
    {
        public DrawableContainer DrawableContainer = new();
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            skglControl1.PreviewKeyDown += SkglControl1_PreviewKeyDown;
            skglControl1.PaintSurface += SkglControl1_PaintSurface;
        }

        private void SkglControl1_PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
        {
            var MainPoint = DrawableContainer.Drawables[1];
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (MainPoint.FirstPoint.Y - 5 > Height - 310)
                    {
                        MainPoint.Move(0, -5);
                    }
                    else
                    { 
                        MainPoint.Move(0, 5);
                    }
                    break;
                case Keys.Down:
                    if (MainPoint.LastPoint.Y + 5 <= Height - 200)
                    {
                        MainPoint.Move(0, 5);
                    }
                    else
                    {
                        MainPoint.Move(0, -5);
                    }
                    break;
                case Keys.Left:
                    MainPoint.Move(-5, 0);
                    break;
                case Keys.Right:
                    MainPoint.Move(5, 0);
                    break;
                default:
                    break;
            }
            skglControl1.Invalidate();
        }

        private void SkglControl1_PaintSurface(object? sender, SKPaintGLSurfaceEventArgs e)
        {
            e.Surface.Canvas.Clear();
            ICanvas canvas = new SkiaCanvas() { Canvas = e.Surface.Canvas };
            DrawableContainer.AddDrawing(new DrawableCircle(new ReadOnlyPosition<float>(500, 500), 50), Colors.MidnightBlue);
            DrawableContainer.Draw(canvas, RectangleF.FromLTRB(e.Info.Rect.Left, e.Info.Rect.Top, e.Info.Rect.Right, e.Info.Rect.Bottom));
        }
    }
}
