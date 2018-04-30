using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public static int xor(int a, int b) => a ^ b;
       

        private void button1_Click(object sender, EventArgs e) //XOR ^
        {
            textBox3.Text = Convert.ToString(xor(Convert.ToInt32(textBox1.Text, 2), Convert.ToInt32(textBox2.Text, 2)), 2);
            textBox4.Text = Convert.ToString(xor(Convert.ToInt32(textBox1.Text, 2), Convert.ToInt32(textBox2.Text, 2)), 8);
            textBox5.Text = Convert.ToString(xor(Convert.ToInt32(textBox1.Text, 2), Convert.ToInt32(textBox2.Text, 2)), 10);
            textBox6.Text = Convert.ToString(xor(Convert.ToInt32(textBox1.Text, 2), Convert.ToInt32(textBox2.Text, 2)), 16);
        }

        public static int and(int a, int b) => a & b;
       
        private void button2_Click(object sender, EventArgs e)//AND 
        {
            textBox3.Text = Convert.ToString(and(Convert.ToInt32(textBox1.Text, 2), Convert.ToInt32(textBox2.Text, 2)), 2);
            textBox4.Text = Convert.ToString(and(Convert.ToInt32(textBox1.Text, 2), Convert.ToInt32(textBox2.Text, 2)), 8);
            textBox5.Text = Convert.ToString(and(Convert.ToInt32(textBox1.Text, 2), Convert.ToInt32(textBox2.Text, 2)), 10);
            textBox6.Text = Convert.ToString(and(Convert.ToInt32(textBox1.Text, 2), Convert.ToInt32(textBox2.Text, 2)), 16);
        }

        public static int or(int a, int b) => a | b;


        private void button3_Click(object sender, EventArgs e) //OR
        {
            textBox3.Text = Convert.ToString(or(Convert.ToInt32(textBox1.Text, 2), Convert.ToInt32(textBox2.Text, 2)), 2);
            textBox4.Text = Convert.ToString(or(Convert.ToInt32(textBox1.Text, 2), Convert.ToInt32(textBox2.Text, 2)), 8);
            textBox5.Text = Convert.ToString(or(Convert.ToInt32(textBox1.Text, 2), Convert.ToInt32(textBox2.Text, 2)), 10);
            textBox6.Text = Convert.ToString(or(Convert.ToInt32(textBox1.Text, 2), Convert.ToInt32(textBox2.Text, 2)), 16);
        }

        public static int not(int a) => ~a;


        private void button4_Click(object sender, EventArgs e) //NOT
        {
            textBox3.Text = Convert.ToString(not(Convert.ToInt32(textBox1.Text, 2)), 2);
            textBox4.Text = Convert.ToString(not(Convert.ToInt32(textBox1.Text, 2)), 8);
            textBox5.Text = Convert.ToString(not(Convert.ToInt32(textBox1.Text, 2)), 10);
            textBox6.Text = Convert.ToString(not(Convert.ToInt32(textBox1.Text, 2)), 16);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        } 

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) //claer
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
