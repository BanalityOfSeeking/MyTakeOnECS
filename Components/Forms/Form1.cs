using BonesOfTheFallen.Services.Graphics;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;
using SkiaSharp.Views.Desktop;
using System.Windows.Forms;

namespace BonesOfTheFallen.Services.Components.Forms
{
    public partial class Form1 : Form
    {
        public FigureContainer Drawables = new();
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            skglControl1.PreviewKeyDown += SkglControl1_PreviewKeyDown;
            skglControl1.PaintSurface += SkglControl1_PaintSurface;
        }

        private void SkglControl1_PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
        {
            var MainPoint = Drawables[1];
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
            if (Drawables.DrawablePaths.Count == 0)
            {
                var Ground = FigureContainer.GetFigure();
                Ground.AppendRectangle(0, 0, Right, Height);
                Ground.PathColors.Add(Colors.Green);
                Drawables.SetFigure(Ground);
                var player = FigureContainer.GetFigure();
                player.AppendRectangle(100, Height - 280, 20, 20);
                player.PathColors.Add(Colors.Blue);
                Drawables.SetFigure(player);
                var enemy = FigureContainer.GetFigure();
                enemy.AppendRectangle(Right -100, Height - 280, 20, 20);
                enemy.PathColors.Add(Colors.Red);
                Drawables.SetFigure(enemy);

            }
            Drawables.DrawFigures(canvas, RectangleF.FromLTRB(e.Info.Rect.Left, e.Info.Rect.Top, e.Info.Rect.Right, e.Info.Rect.Bottom));
        }
    }
}
