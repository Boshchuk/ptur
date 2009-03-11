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

        public TestForm()
        {
            InitializeComponent();
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
/* незавершенный конструктор
        public DrawingRectangle(Graphics place, Point pointWhere ,int xSize, int ySize)
        {
            drawPlace = place;
        }
        */
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
        //private Rectangle body = new Rectangle(0, 0, 2 * Lsize, Lsize);
        

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

    public class Apc : DrawingFigure
    {
        
    }
}
