using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace project
{
    public partial class TestForm : Form
    {
        readonly Bitmap lBitmapdrawingArea;
        readonly Graphics DrawingArea;

        List<DrawingRectangle> groop = new List<DrawingRectangle>(10);

        DrawingRectangle exTank;


        public TestForm()
        {
            InitializeComponent();

            DrawingArea = panelDrawingArea.CreateGraphics();

            var startPoint = new Point(50,50);
            exTank = new DrawingRectangle( DrawingArea,panelDrawingArea.Size, startPoint, 25, 15);
            groop.Add(exTank);

            lBitmapdrawingArea = new Bitmap(
                this.panelDrawingArea.Width,
                this.panelDrawingArea.Height,
                PixelFormat.Format24bppRgb);  
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var rectangle in groop)
            {
                rectangle.Draw();
            }
        }

        private void buttonTry_Click(object sender, EventArgs e)
        {
            var drawingRectangle =  groop[0];
            groop[0].StartMoving(drawingRectangle.PosX, drawingRectangle.PosY, 75, 75, lBitmapdrawingArea, panelDrawingArea,textBox1);

            textBox1.Text += groop[0].PosX + " " + groop[0].PosY;

            groop[0].StartMoving(drawingRectangle.PosX, drawingRectangle.PosY, 150, 50, lBitmapdrawingArea, panelDrawingArea, textBox1);
            textBox1.Text += groop[0].PosX.ToString() + " " + groop[0].PosY.ToString();
        }
    }

    
}
