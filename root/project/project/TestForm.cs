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

            Point startPoint = new Point(50,  panelDrawingArea.Height - 50);
            exTank = new DrawingRectangle(DrawingArea, startPoint, 25, 15);
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

        private void buttonTry_Click(object sender, EventArgs e)
        {
            DrawingRectangle D =  Groop[0];
            D.startMoving(D.BodyPoint.X,D.BodyPoint.Y,75,75);

            PaintEventArgs ee = new PaintEventArgs(DrawingArea,new Rectangle(0,0,panelDrawingArea.Width,panelDrawingArea.Height));

            OnPaint(ee);
            MessageBox.Show("Complite");
        }
    }

    /// <summary>
    /// Класс умеющие корректно рисовать )) движущийся прямоугольник
    /// </summary>
    public class DrawingRectangle
    {
        private string name; // имя обьекта
        private Point bodyPoint;//точка местоположения - левая нижняя

        public Point BodyPoint
        {
            get
            {
                return bodyPoint;
            }
        }

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

        public DrawingRectangle(Graphics place, Point pointWhere, int xSize, int ySize)
        {
            pen = new Pen(Brushes.Blue);
            drawPlace = place;

            bodyPoint.X = pointWhere.X;
            bodyPoint.Y = (pointWhere.Y - ySize);

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
#warning добавить смену экранов?
            //int xStart, yStart, xEnd, yEnd;
            {
                int dx, dy, s;

                /* Упорядочивание координат и вычисление приращений */
                if (xStart > xEnd)
                {
                    s = xStart; xStart = xEnd; xEnd = s;
                    s = yStart; yStart = yEnd; yEnd = s;
                }
                dx = xEnd - xStart; dy = yEnd - yStart;

                /* Занесение начальной точки вектора */
                //   PutPixLn (xn, yn, Pix_C);
                bodyPoint.X = xStart;
                bodyPoint.Y = yStart;

                Draw();

                if (dx == 0 && dy == 0) return;
                /* Вычисление количества позиций по X и Y */
                dx = dx + 1; dy = dy + 1;

                /* Собственно генерация вектора */
                if (dy == dx)
                {                 /* Наклон == 45 градусов */
                    while (xStart < xEnd)
                    {
                        xStart = xStart + 1;
                        //PutPixLn (xn, xn, Pix_C);
                        bodyPoint.X = xStart;
                        bodyPoint.Y = yStart;
                        Draw();
                    }
                }
                else if (dx > dy)
                {           /* Наклон <  45 градусов */
                    s = 0;
                    while (xStart < xEnd)
                    {
                        xStart = xStart + 1;
                        s = s + dy;
                        if (s >= dx)
                        {
                            s = s - dx; yStart = yStart + 1;
                        }
                        //PutPixLn (xn, yn, Pix_C);
                        bodyPoint.X = xStart;
                        bodyPoint.Y = yStart;
                        Draw();
                    }
                }
                else
                {                        /* Наклон >  45 градусов */
                    s = 0;
                    while (yStart < yEnd)
                    {
                        yStart = yStart + 1;
                        s = s + dx;
                        if (s >= dy)
                        {
                            s = s - dy; xStart = xStart + 1;
                        }
                        //PutPixLn (xn, yn, Pix_C);
                        bodyPoint.X = xStart;
                        bodyPoint.Y = yStart;
                        Draw();
                    }
                }
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
}
