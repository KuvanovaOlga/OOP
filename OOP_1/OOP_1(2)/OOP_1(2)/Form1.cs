using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_1_2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> list = new List<int>();

        private void button1_Click_1(object sender, EventArgs e)
        {
            Random rnd = new Random();
            textBox2.Text = null;
            list.Clear();
            int value;
            int size = Convert.ToInt32(textBox1.Text);
            for (int i = 1; i <= size; i++)
            {
                value = rnd.Next(0, 100);
                list.Add(value);
            }
            foreach (var key in list)
            {
                textBox2.Text += key + Environment.NewLine + " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            var sort = from i in list orderby i ascending select i;
            foreach (var key in sort)
            {
                textBox2.Text += key + Environment.NewLine + " ";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            var sort = from i in list orderby i descending select i;
            foreach (var key in sort)
            {
                textBox2.Text += key + Environment.NewLine + " ";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            var max = (from i in list select i).Max();

            textBox2.Text += "Max = " + max + Environment.NewLine;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            var min = (from i in list select i).Min();
            textBox2.Text += "Min = " + min + Environment.NewLine + " ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = " ";
        }
    }
}
