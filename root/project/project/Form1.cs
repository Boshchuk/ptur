using System;
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
            var testForm = new TestForm();

            testForm.ShowDialog();  //  не знаю стоит ли к мамке форме привязывать
        }
    }
}
