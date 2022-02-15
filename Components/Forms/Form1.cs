using BonesOfTheFallen.Graphics;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;
using OpenTK.Graphics;
using SkiaSharp.Views.Desktop;
using System.Windows.Forms;

namespace BonesOfTheFallen.Services.Components.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            skglControl1.PaintSurface += SkglControl1_PaintSurface;
        }

        private void SkglControl1_PaintSurface(object? sender, SKPaintGLSurfaceEventArgs e)
        {

            ICanvas canvas = new SkiaCanvas() { Canvas = e.Surface.Canvas };

            canvas.FillColor = Colors.Navy;
            canvas.FillRectangle(0, 0, skglControl1.Width, skglControl1.Height);


            DrawableCircle dc = new(5, new Point<float>(100, 100));
            dc.Draw(canvas, GameGraphics.rectangle);
        }
    }
}
