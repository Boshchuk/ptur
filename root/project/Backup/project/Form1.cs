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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void buttonCallTestForm_Click(object sender, EventArgs e)
        {
            TestForm VictorTestForm = new TestForm();

            VictorTestForm.ShowDialog();  //  не знаю стоит ли к мамке форме привязывать
        }
    }
}
