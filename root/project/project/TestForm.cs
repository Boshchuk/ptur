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

        System.Collections.Generic.List<DrawingRectangle> groop = new List<DrawingRectangle>(10);

        DrawingRectangle exTank;


        public TestForm()
        {
            InitializeComponent();

            DrawingArea = panelDrawingArea.CreateGraphics();

            Point startPoint = new Point(50,50);
            exTank = new DrawingRectangle( DrawingArea,panelDrawingArea.Size, startPoint, 25, 15);
            groop.Add(exTank);



            lBitmapdrawingArea = new Bitmap(
                this.panelDrawingArea.Width,
                this.panelDrawingArea.Height,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);  
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            for (int i = 0; i < groop.Count; i++)
            {
                groop[i].Draw();
            }
        }

        private void buttonTry_Click(object sender, EventArgs e)
        {
            DrawingRectangle D =  groop[0];
            groop[0].startMoving(groop[0].posX, groop[0].posY, 75, 75, lBitmapdrawingArea, panelDrawingArea,textBox1);


            textBox1.Text += groop[0].posX.ToString() + " " + groop[0].posY.ToString();
            //PaintEventArgs ee = new PaintEventArgs(DrawingArea,new Rectangle(0,0,panelDrawingArea.Width,panelDrawingArea.Height));

            //OnPaint(ee);
            //MessageBox.Show("Complite");
        }
    }

    /// <summary>
    /// Класс умеющие корректно рисовать )) движущийся прямоугольник
    /// </summary>
    public class DrawingRectangle
    {
        private string name; // имя обьекта
        private Point bodyPoint;//точка местоположения - левая нижняя
        private Size maxPoint;
       

        public int posX
        {
            get
            {
                return bodyPoint.X;
            }
            set
            {
                bodyPoint.X = (value);
            }
                
        }
        public int posY
        {
            get
            {
                return (maxPoint.Height - bodyPoint.Y);
            }
            set
            {
                bodyPoint.Y = maxPoint.Height- (value);
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

        private Rectangle bodyRectangle;

        private Pen pen; // контур
        private Brush brush = Brushes.Blue; // для заливки

        public DrawingRectangle(Graphics place,Size sizeOfPanel , Point pointWhere, int xSize, int ySize)
        {
            pen = new Pen(Brushes.Blue);
            drawPlace = place;
            maxPoint = sizeOfPanel;

            posX = pointWhere.X;
            posY = pointWhere.Y;
                       
            bodyRectangle = new Rectangle(posX, bodyPoint.Y -  ySize, xSize, ySize);

        }

        public void Draw()
        {
            drawPlace.DrawRectangle(new Pen(Brushes.Blue), bodyRectangle);
            drawPlace.FillRectangle(brush, bodyRectangle);
        }

        public void Draw(Graphics Exsacly)
        {
            Exsacly.DrawRectangle(new Pen(Brushes.Blue), bodyRectangle);
            Exsacly.FillRectangle(brush, bodyRectangle);
        }
        /// <summary>
        /// Запускает движение прямоугольника
        /// </summary>
        /// <param name="xStart">начальная координата x</param>
        /// <param name="yStart">начальная координата y</param>
        /// <param name="xEnd">конечная координата x</param>
        /// <param name="yEnd">конечная координата y</param>
        /// <param name="param">Bitmap incapsulated in form</param>
        /// <param name="panelWhereShow">та на которой и будем рисовать</param>
        public void startMoving(int xStart, int yStart, int xEnd, int yEnd, Bitmap param, Panel panelWhereShow,TextBox calledFromForm)
        {
            
                int dx, dy, s;

                string buffer = "";

                buffer += xStart.ToString() + " " + yStart.ToString()+" " + "\r\n" ;  


                /* Упорядочивание координат и вычисление приращений */
                if (xStart > xEnd)
                {
                    s = xStart;
                    xStart = xEnd;
                    xEnd = s;

                    s = yStart;
                    yStart = yEnd;
                    yEnd = s;
                }
                dx = xEnd - xStart;
                dy = yEnd - yStart;

                /* Занесение начальной точки вектора */
                //   PutPixLn (xn, yn, Pix_C);
                posX = xStart;
                posY = yStart;

                Draw();

                if (dx == 0 && dy == 0) return;
                /* Вычисление количества позиций по X и Y */
                dx = dx + 1; 
                dy = dy + 1;

                /* Собственно генерация вектора */
                if (dy == dx)
                {                
                    /* Наклон == 45 градусов */
                   // MessageBox.Show("Наклон == 45 градусов");
                    while (xStart < xEnd)
                    {
                        xStart = xStart + 1;
                        yStart = yStart + 1;
                      

                        Bitmap lBitmap = (Bitmap) param.Clone();
                        Graphics lGraphics = Graphics.FromImage(lBitmap);

                        posX = xStart;
                        posY = yStart;
                        Draw(lGraphics);

                        lGraphics.Dispose();

                        Graphics lGraphicsForm = panelWhereShow.CreateGraphics();
                        lGraphicsForm.DrawImage(lBitmap, new Point(0, 0));
                        lGraphicsForm.Dispose();

                        buffer += xStart.ToString() + " " + yStart.ToString() + " " + "\r\n";

                    }
                }
                else if (dx > dy)
                {           /* Наклон <  45 градусов */
                   // MessageBox.Show("Наклон <  45 градусов");
                    s = 0;
                    while (xStart < xEnd)
                    {
                        xStart = xStart + 1;
                        s = s + dy;
                        if (s >= dx)
                        {
                            s = s - dx;
                            yStart = yStart + 1;
                        }
                        //PutPixLn (xn, yn, Pix_C);
                        Bitmap lBitmap = (Bitmap)param.Clone();
                        Graphics lGraphics = Graphics.FromImage(lBitmap);

                        posX = xStart;
                        posY = yStart;
                        Draw(lGraphics);

                        Graphics lGraphicsForm = panelWhereShow.CreateGraphics();
                        lGraphicsForm.DrawImage(lBitmap, new Point(0, 0));
                        lGraphicsForm.Dispose();

                        buffer += xStart.ToString() + " " + yStart.ToString() + " " + "\r\n";
                    }
                }
                else
                {                        /* Наклон >  45 градусов */
                    s = 0;
                   // MessageBox.Show("Наклон <  45 градусов");
                    while (yStart < yEnd)
                    {
                        yStart = yStart + 1;
                        s = s + dx;
                        if (s >= dy)
                        {
                            s = s - dy;
                            xStart = xStart + 1;
                        }
                        //PutPixLn (xn, yn, Pix_C);
                        Bitmap lBitmap = (Bitmap)param.Clone();
                        Graphics lGraphics = Graphics.FromImage(lBitmap);

                        posX = xStart;
                        posY = yStart;
                        Draw(lGraphics);

                        Graphics lGraphicsForm = panelWhereShow.CreateGraphics();
                        lGraphicsForm.DrawImage(lBitmap, new Point(0, 0));
                        lGraphicsForm.Dispose();

                        buffer += xStart.ToString() + " " + yStart.ToString() + " " + "\r\n";
                    }
                }

                calledFromForm.Text = buffer;            

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
