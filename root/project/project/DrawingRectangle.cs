using System.Drawing;
using System.Windows.Forms;

namespace project
{
    /// <summary>
    /// Класс умеющие корректно рисовать )) движущийся прямоугольник
    /// </summary>
    public class DrawingRectangle
    {
        private Point bodyPoint;//точка местоположения - левая нижняя
        private Size maxPoint;

        public int PosX
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
        public int PosY
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

        public string Name { get; set; }

        private Rectangle bodyRectangle;

        private Pen pen; // контур

        private Brush brush = Brushes.Blue; // для заливки

        /// <summary>
        /// Создает Рисуемый прямоугольник
        /// </summary>
        /// <param name="place">Где</param>
        /// <param name="sizeOfPanel">размеры панели в которой рисование</param>
        /// <param name="pointWhere">левая нижняя точка</param>
        /// <param name="xSize">ширина</param>
        /// <param name="ySize">высота</param>
        public DrawingRectangle(Graphics place,Size sizeOfPanel , Point pointWhere, int xSize, int ySize)
        {
            pen = new Pen(Brushes.Blue);
            drawPlace = place;
            maxPoint = sizeOfPanel;

            PosX = pointWhere.X;
            PosY = pointWhere.Y;
                       
            bodyRectangle = new Rectangle(PosX, bodyPoint.Y -  ySize, xSize, ySize);
        }

        public void Draw()
        {
            drawPlace.DrawRectangle(new Pen(Brushes.Blue), bodyRectangle);
            drawPlace.FillRectangle(brush, bodyRectangle);
        }

        public void Draw(Graphics Exsacly)
        {
            bodyRectangle = new Rectangle(bodyPoint.X, bodyPoint.Y-bodyRectangle.Height, bodyRectangle.Width, bodyRectangle.Height);
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
        public void StartMoving(int xStart, int yStart, int xEnd, int yEnd, Bitmap param, Panel panelWhereShow,TextBox calledFromForm)
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
            PosX = xStart;
            PosY = yStart;

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

                    PosX = xStart;
                    PosY = yStart;
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

                    PosX = xStart;
                    PosY = yStart;
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

                    PosX = xStart;
                    PosY = yStart;
                    Draw(lGraphics);

                    Graphics lGraphicsForm = panelWhereShow.CreateGraphics();
                    lGraphicsForm.DrawImage(lBitmap, new Point(0, 0));
                    lGraphicsForm.Dispose();

                    buffer += xStart.ToString() + " " + yStart.ToString() + " " + "\r\n";
                }
            }
            calledFromForm.Text = buffer;            
        }
    }
}