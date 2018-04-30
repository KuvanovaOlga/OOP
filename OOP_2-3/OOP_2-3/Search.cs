using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace OOP_2_3
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        public List<Global> Searchlist = new List<Global>();

        private void SearchWin_Load(object sender, EventArgs e) { }

        private void toolStripButton1_Click(object sender, EventArgs e) { }

        private void toolTip1_Popup(object sender, PopupEventArgs e)  { }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OOP 2-3\n", "О программе", 0);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Now;
            toolStripStatusLabel1.Text = "DateTime: " + thisDay.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Searchlist.Clear();
            listBox1.Items.Clear();
            List<Global> list = ((Form1)Owner).list;
            if (radioButton1.Checked)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    if (list[i].value.Klass == comboBox3.Text)
                    {
                        Searchlist.Add(list[i]);
                        listBox1.Items.Add(list[i].ToString());
                    }
                }
            }
            else if (radioButton2.Checked)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    DateTime d1 = DateTime.Parse(list[i].value.Data),
                        d2 = dateTimePicker1.Value.Date;
                    if (d1.Day == d2.Day &&
                        d1.Month == d2.Month &&
                        d1.Year == d2.Year)
                    {
                        Searchlist.Add(list[i]);
                        listBox1.Items.Add(list[i].ToString());
                    }
                }
            }
            else
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    if (list[i].value.orialObitania.Kontinent == comboBox4.Text)
                    {
                        Searchlist.Add(list[i]);
                        listBox1.Items.Add(list[i].ToString());
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Searchlist.Clear();
            listBox1.Items.Clear();
            if (radioButton2.Checked)
            {
                var sorted = ((Form1)Owner).list.OrderBy(n => DateTime.Parse(n.value.Data).Ticks);
                foreach (Global g in sorted)
                {
                    Searchlist.Add(g);
                    listBox1.Items.Add(g.ToString());
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText("SearchList.txt", JsonConvert.SerializeObject(Searchlist));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if (i >= 0)
            {
                ((Form1)this.Owner).textBox1.Text = Searchlist[i].value.Nazvanie;
                ((Form1)this.Owner).comboBox1.Text = Searchlist[i].value.Tip;
                ((Form1)this.Owner).richTextBox2.Text = Searchlist[i].value.Opisanie;
                ((Form1)this.Owner).comboBox2.Text = Searchlist[i].value.Otrad;
                ((Form1)this.Owner).trackBar1.Value = Searchlist[i].value.Vozrast;
                ((Form1)this.Owner).comboBox3.Text = Searchlist[i].value.Klass;
                ((Form1)this.Owner).checkBox1.Checked = Searchlist[i].value.IsRedBook;
                ((Form1)this.Owner).comboBox4.Text = Searchlist[i].value.orialObitania.Kontinent;
                ((Form1)this.Owner).textBox2.Text = Convert.ToString(Searchlist[i].value.orialObitania.Shirota);
                ((Form1)this.Owner).textBox3.Text = Convert.ToString(Searchlist[i].value.orialObitania.Dolgota);
                ((Form1)this.Owner).textBox4.Text = Searchlist[i].value.orialObitania.Raen;
                ((Form1)this.Owner).textBox5.Text = Convert.ToString(Searchlist[i].value.orialObitania.Ploshad);
                ((Form1)this.Owner).textBox6.Text = Searchlist[i].value.kutator.Familia;
                ((Form1)this.Owner).textBox9.Text = Searchlist[i].value.kutator.Ima;
                ((Form1)this.Owner).textBox8.Text = Searchlist[i].value.kutator.Otchestvo;
                ((Form1)this.Owner).textBox7.Text = Searchlist[i].value.kutator.Strana;
                ((Form1)this.Owner).dateTimePicker1.Value = DateTime.Parse(Searchlist[i].value.Data);
                ((Form1)this.Owner).richTextBox1.Text = Searchlist[i].GetJSON();
            }
        }

    }
}
