using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace project
{
    public partial class TestForm : Form
    {
        Bitmap lBitmapdrawingArea;
        Graphics DrawingArea;

        
        System.Collections.Generic.List<DrawingRectangle> Groop = new List<DrawingRectangle>(10);

        DrawingRectangle exTank;
       

        public TestForm()
        {
            InitializeComponent();
            

            DrawingArea = panelDrawingArea.CreateGraphics();

            Point startPoint = new Point(50,panelDrawingArea.Height- 50);
            exTank = new DrawingRectangle(DrawingArea, startPoint, 250, 150);
            Groop.Add(exTank);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            for (int i = 0; i < Groop.Count; i++)
            {
                Groop[i].Draw();
            }
        }
    }

    /// <summary>
    /// Класс умеющие корректно рисовать )) движущийся прямоугольник
    /// </summary>
    public class DrawingRectangle
    {
        private string name; // имя обьекта
        private Point startPoint;//точка местоположения - левая нижняя

        private Graphics drawPlace;  //место где рисуется
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private Rectangle body;

        private Pen pen; // контур
        private Brush brush = Brushes.Blue; // для заливки
      
        public DrawingRectangle(Graphics place, Point pointWhere ,int xSize, int ySize)
        {
            pen = new Pen(Brushes.Blue) ;
            drawPlace = place;

            startPoint.X = pointWhere.X;
            startPoint.Y = pointWhere.Y - ySize;
            
            //поскольку для инициализации берется левая верхняя , немного пошаманим
            body = new Rectangle(pointWhere.X, pointWhere.Y - ySize, xSize, ySize);

        }

        public void Draw()
        {
            drawPlace.DrawRectangle(new Pen(Brushes.Blue), body);
            drawPlace.FillRectangle(brush, body);
        }

        /// <summary>
        /// Запускает движение прямоугольника
        /// </summary>
        /// <param name="xStart">начальная координата x</param>
        /// <param name="yStart">начальная координата y</param>
        /// <param name="xEnd">конечная координата x</param>
        /// <param name="yEnd">конечная координата y</param>
        public void startMoving(int xStart, int yStart, int xEnd, int yEnd)
        {
            
        }

    }
    /// <summary>
    /// Инкапсулирует набор рисуемых прямоугольников
    /// </summary>
    public class DrawingFigure
    {
        /// <summary>
        /// Начальная точка - левая нижняя
        /// </summary>
        private Point Position;  //определить за начальную точку брать 
        private Graphics DrawPlace;     

        const int Lsize = 40;

        private Pen pen = new Pen(Brushes.Blue); // контур

        private Brush brush = Brushes.Blue; // для заливки
        private Brush textcolor = Brushes.Red;
        private Rectangle body = new Rectangle(0, 0, 2 * Lsize, Lsize);
        

        public DrawingFigure(int xPos, int yPos, Graphics WhereDraw)
        {
            Position.X = xPos;
            Position.Y = yPos;
           
            DrawPlace = WhereDraw;
        }

        public void Draw(int x, int y)
        {
            body = new Rectangle(x, y, 2 * Lsize, Lsize);
            DrawPlace.DrawRectangle(pen, body);
            DrawPlace.FillRectangle(brush, body);

        }
        public void Draw()
        {
            body = new Rectangle(Position.X, Position.Y, 2 * Lsize + 10, Lsize);

            DrawPlace.DrawRectangle(pen, body);
            DrawPlace.FillRectangle(brush, body);

        }
        public void Draw(bool IsMoving)
        {
            body = new Rectangle(Position.X, Position.Y, 2 * Lsize + 10, Lsize);
            if (IsMoving == false)
            {
                DrawPlace.DrawRectangle(pen, body);
                DrawPlace.FillRectangle(textcolor, body);
            }
            else
            {
                DrawPlace.DrawRectangle(pen, body);
                DrawPlace.FillRectangle(brush, body);
            }

        }
    }

   /* public class Apc : DrawingFigure
    {
        
    }
    * */
}
