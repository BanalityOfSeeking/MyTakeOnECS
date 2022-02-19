using BonesOfTheFallen.Services.Graphics;
using BonesOfTheFallen.Services.Graphics.Drawables;
using BonesOfTheFallen.Services.Graphics.Drawables.Interfaces;
using BonesOfTheFallen.Services.Graphics.Interface;
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
            var DrawableObject = FigureContainer.GetFigure();

            DrawableObject
                .Add(new DrawableCircle(new Point<float>(500, 500), 20));
            DrawableObject
                .Add(new DrawableLine(new Point<float>(500, 520), 100, Graphics.Orientation.Vertical));
            DrawableObject
                .Add(new DrawableLine(new Point<float>(460, 540), 80, Graphics.Orientation.Horizontal));
            
            Drawables.SetFigure(DrawableObject);
        }

        private void SkglControl1_PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Drawables[0].MainPoint = (IMainDrawable)Drawables[0].MainPoint
                        .MoveByOffset(0, -5);
                    for (var item = 0; item < Drawables[0].Count; item++)
                    {
                        Drawables[0][item] = (ISubDrawable)Drawables[0][item].MoveByOffset(0,-5);
                    }
                    break;
                case Keys.Down:
                    Drawables[0].MainPoint = (IMainDrawable)Drawables[0].MainPoint
                        .MoveByOffset(0, 5);
                    for(var item = 0;item < Drawables[0].Count;item++)
                    {
                        Drawables[0][item] = (ISubDrawable)Drawables[0][item].MoveByOffset(0, 5);
                    }
                    break;
                case Keys.Left:
                    Drawables[0].MainPoint = (IMainDrawable)Drawables[0].MainPoint
                        .MoveByOffset(-5, 0);
                    for (var item = 0; item < Drawables[0].Count; item++)
                    {
                        Drawables[0][item] = (ISubDrawable)Drawables[0][item].MoveByOffset(-5, 0);
                    }
                    break;
                case Keys.Right:
                    Drawables[0].MainPoint = (IMainDrawable)Drawables[0].MainPoint
                        .MoveByOffset(5, 0);
                    for (var item = 0; item < Drawables[0].Count; item++)
                    {
                        Drawables[0][item] = (ISubDrawable)Drawables[0][item].MoveByOffset(5, 0);
                    }
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
            Drawables.DrawFigures();
        }
    }
}
