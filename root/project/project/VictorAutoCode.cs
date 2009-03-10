using System;
using System.Runtime;
using System.Runtime.InteropServices;


using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/*namespace ptur2d
{
    public delegate void MyEventHandler(Form1 sender, int param);

    public partial class Form1 : Form
    {
        Bitmap lBitmapdrawingArea;
        Graphics DrawingArea;

        public event MyEventHandler Preryvanie;
        public const int WsClockSize = 5;
        const int VirtmemorySize = 10;//вместительность виртуальной памяти...
        const int AllSize = 15;

        public int Prohod = 0;

        public int inClock; //считает первые пять страниц
        Queue<Reco> WsClock; //очередь-часы

        System.Collections.Generic.List<Reco> VirtMemory; // виртуальная память
        System.Collections.Generic.List<DrawingRec> Groop;


        public Form1()
        {

            InitializeComponent();

            #region Constuctor

            WsClock = new Queue<Reco>(WsClockSize);
            VirtMemory = new List<Reco>(VirtmemorySize);
            Groop = new List<DrawingRec>(15);

            DrawingArea = panelDrawingArea.CreateGraphics();

            int startX = 540;
            int startY = 10;
            //заполнение виртуальной памяти страницами 
            for (int i = 0; i < VirtmemorySize; i++)
            {
                VirtMemory.Add(new Reco(i));
                Groop.Add(new DrawingRec(startX, startY + 10 + i * 45, VirtMemory[i], this.DrawingArea));
                //Groop[i].Draw(startX, startY + 10 + i * 50);
            }

            Groop.Add(new DrawingRec(150, 100, new Reco(), this.DrawingArea));
            Groop.Add(new DrawingRec(300, 200, new Reco(), this.DrawingArea));
            Groop.Add(new DrawingRec(250, 300, new Reco(), this.DrawingArea));
            Groop.Add(new DrawingRec(75, 300, new Reco(), this.DrawingArea));
            Groop.Add(new DrawingRec(50, 200, new Reco(), this.DrawingArea));

            #endregion
            Preryvanie += new MyEventHandler(MethodObrapotchik);

            lBitmapdrawingArea = new Bitmap(
                this.panelDrawingArea.Width,
                this.panelDrawingArea.Height,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);



            DrawingArea.DrawImage(lBitmapdrawingArea, new Point(0, 0));


        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (int i = 0; i < AllSize; i++)
            {
                // Groop[i].Draw(550, 10 + i * 45);
                Groop[i].Draw();
            }
        }

        public bool IsInVirtPage(int Nomer)
        {
            if (VirtMemory[Nomer] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RefreshList();
        }

        /// <summary>
        /// обновляет содержимое Лист бокса
        /// </summary>
        private void RefreshList()
        {
            listBox1.Items.Clear();

            for (int i = 0; i < VirtmemorySize; i++)
            {
                if (VirtMemory[i] != null)
                {
                    listBox1.Items.Add(VirtMemory[i].ToString());
                }
                else
                {
                    listBox1.Items.Add("Empty or null");
                }
            }
        }

        private void RefreshTextBoxs()
        {
            int j = 0;
            if (inClock > 5)
            {
                while (j != 5)
                {
                    Reco temp = WsClock.Dequeue();
                    switch (j)
                    {
                        case 0:
                            {
                                textBox1.Text = temp.ToString();
                                break;
                            }
                        case 1:
                            {
                                textBox2.Text = temp.ToString();
                                break;
                            }
                        case 2:
                            {
                                textBox3.Text = temp.ToString();
                                break;
                            }
                        case 3:
                            {
                                textBox4.Text = temp.ToString();
                                break;
                            }
                        case 4:
                            {
                                textBox5.Text = temp.ToString();
                                break;
                            }
                    }
                    WsClock.Enqueue(temp);
                    j++;
                }
            }
        }

        private void buttonAddToRam_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBoxPageNumber.Text);
            if (inClock < 5)
            {
                #region пока вся память не задействована
                if (VirtMemory[i] != null)
                {
                    VirtMemory[i].R = 1;
                    VirtMemory[i].LastTimeUsed = DateTime.Now;

                    WsClock.Enqueue(VirtMemory[i]);

                    //warning
                    switch (inClock)
                    {
                        case 0:
                            {
                                textBox1.Text = VirtMemory[i].ToString();
                                break;
                            }
                        case 1:
                            {
                                textBox2.Text = VirtMemory[i].ToString();
                                break;
                            }
                        case 2:
                            {
                                textBox3.Text = VirtMemory[i].ToString();
                                break;
                            }
                        case 3:
                            {
                                textBox4.Text = VirtMemory[i].ToString();
                                break;
                            }
                        case 4:
                            {
                                textBox5.Text = VirtMemory[i].ToString();
                                break;
                            }
                    }
                    VirtMemory[i] = null;
                }
                else
                {
                    MessageBox.Show("Уже в памяти");
                    // что бы +-;
                    inClock--;
                }

                #endregion
            }
            else
            {
                Preryvanie(this, i);
            }
            inClock++;
            RefreshList();
            RefreshTextBoxs();

        }
        /// <summary>
        /// Возникает когда память заполнена
        /// </summary>
        /// <param name="PageId"></param>
        public static void MethodObrapotchik(Form1 sender, int PageId)
        {
            // MessageBox.Show("Замещение страниц: нужна страница"+ PageId.ToString());
            Reco temp;

            if (sender.IsInVirtPage(PageId) == true)
            {//когда нужная страница в виртуальной памяти а не в обычной
                //должно происходить замещение

                //если R=1 (страница используется), R обнуляется, указатель перемещается на следующую страницу; 
                // а когда обнулять m ну, здесь и обнулим
                //что бы можно было использовать потом
                if (sender.WsClock.Peek().R == 1)
                {
                    //move strelka
                    temp = sender.WsClock.Dequeue();
                    temp.R = 0;

                    temp.M = 0;
                    sender.WsClock.Enqueue(temp);

                    MethodObrapotchik(sender, PageId);
                }
                if (sender.WsClock.Peek().R == 0)
                {//вычисляется возраст страницы
                    temp = sender.WsClock.Peek();
                    TimeSpan PageVosrast;
                    PageVosrast = DateTime.Now - temp.LastTimeUsed;

                    if (PageVosrast > Reco.Tay)
                    {//если возраст тау больше, то замещение страниц
                        //замещение:
                        //память из виртуальной в оперативную , из оперативной в виртуальную
                        //страница заместится указатель уйдет дальше  

                        if (temp.M != 1)
                        {
                            temp = sender.WsClock.Dequeue();
                            sender.WsClock.Enqueue(sender.VirtMemory[PageId]);
                            sender.VirtMemory[PageId] = temp;
                        }
                        if (temp.M == 1)
                        {
                            //прокрутка
                            if (sender.Prohod < 5)
                            {
                                temp = sender.WsClock.Dequeue();
                                sender.WsClock.Enqueue(temp);
                                sender.Prohod++;
                                MethodObrapotchik(sender, PageId);
                            }
                            else
                            {
                                temp = sender.WsClock.Dequeue();
                                sender.WsClock.Enqueue(sender.VirtMemory[PageId]);
                                sender.VirtMemory[PageId] = temp;
                                sender.Prohod = 0;
                            }

                        }
                    }
                }
            }
        }

        public void Movment(int id1, int id2)
        {
            DrawingArea.Clear();// этот этап один раз


            //нарисовать все кроме движ?
            //DrawingArea 
        }

    }

    public class Reco
    {
        public static TimeSpan Tay = new TimeSpan(8000);
        private System.Collections.BitArray RML_Map; //инкапсулирует биты R [0] и M [1] 

        public DateTime LastTimeUsed;
        private int Id; // номер в виртуальной памяти

        public Reco()
        {
            RML_Map = new BitArray(3, false);

            LastTimeUsed = DateTime.Now; // устанавливаем текущее время

        }

        public Reco(int count)
        {
            RML_Map = new BitArray(3, false);

            LastTimeUsed = DateTime.Now; // устанавливаем текущее время

            P = 0;
            this.Id = count;

        }

        public int R
        {
            get
            {
                if (RML_Map[0] == false)
                {
                    return 0;
                }
                else
                    return 1;
            }
            set
            {
                RML_Map[0] = Convert.ToBoolean(value);
            }
        }
        public int M
        {
            get
            {
                if (RML_Map[1] == false)
                {
                    return 0;
                }
                else
                    return 1;
            }
            set
            {
                RML_Map[1] = Convert.ToBoolean(value);
            }
        }
        public int P
        {
            get
            {
                if (RML_Map[2] == false)
                {
                    return 0;
                }
                else
                    return 1;
            }
            set
            {
                RML_Map[2] = Convert.ToBoolean(value);
            }
        }

        public override string ToString()
        {
            long variant
            return string.Format("Nomer Id {4} R: {0} , M: {1}, time{2} , msec {3}",
                this.R,this.M, this.LastTimeUsed.ToString(),
                this.LastTimeUsed.Millisecond.ToString(),this.Id);
             
            return string.Format(" Id {2} R: {0} , M: {1}",
                this.R, this.M, this.Id);

        }
    }

    public class DrawingRec
    {
        private Point Position;
        private Graphics DrawPlace;
        private Reco RecoForHandle;

        const int Lsize = 40;

        private Pen obolocka = new Pen(Brushes.Blue);
        private Brush zalivko = Brushes.Blue;
        private Brush textcolor = Brushes.Red;
        private Rectangle Sq = new Rectangle(0, 0, 2 * Lsize, Lsize);


        public DrawingRec(int xPos, int yPos, Reco toHandle, Graphics WhereDraw)
        {
            Position.X = xPos;
            Position.Y = yPos;
            RecoForHandle = toHandle;
            DrawPlace = WhereDraw;
        }

        public void Draw(int x, int y)
        {
            Sq = new Rectangle(x, y, 2 * Lsize, Lsize);
            DrawPlace.DrawRectangle(obolocka, Sq);
            DrawPlace.FillRectangle(zalivko, Sq);

            DrawPlace.DrawString(RecoForHandle.ToString(), new Font("tahoma", 8, FontStyle.Bold, GraphicsUnit.Point), textcolor, x - 2, y);
        }
        public void Draw()
        {
            Sq = new Rectangle(Position.X, Position.Y, 2 * Lsize + 10, Lsize);

            DrawPlace.DrawRectangle(obolocka, Sq);
            DrawPlace.FillRectangle(zalivko, Sq);

            DrawPlace.DrawString(RecoForHandle.ToString(), new Font("tahoma", 8, FontStyle.Bold, GraphicsUnit.Point), textcolor, Position);
        }
        public void Draw(bool IsMoving)
        {
            Sq = new Rectangle(Position.X, Position.Y, 2 * Lsize + 10, Lsize);
            if (IsMoving == false)
            {
                DrawPlace.DrawRectangle(obolocka, Sq);
                DrawPlace.FillRectangle(textcolor, Sq);
                DrawPlace.DrawString(RecoForHandle.ToString(), new Font("tahoma", 8, FontStyle.Bold, GraphicsUnit.Point), zalivko, Position);
            }
            else
            {
                DrawPlace.DrawRectangle(obolocka, Sq);
                DrawPlace.FillRectangle(zalivko, Sq);
                DrawPlace.DrawString(RecoForHandle.ToString(), new Font("tahoma", 8, FontStyle.Bold, GraphicsUnit.Point), textcolor, Position);
            }

        }
    }
}
*/