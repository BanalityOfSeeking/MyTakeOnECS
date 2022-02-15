using BonesOfTheFallen.Graphics;
using Microsoft.Maui.Graphics;
using System.Windows.Forms;

namespace BonesOfTheFallen.Services.Components.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GameGraphics.GameCanvas = gdiGraphicsView1.Canvas;
        }
    }
}
