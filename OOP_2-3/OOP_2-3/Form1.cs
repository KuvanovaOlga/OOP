using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;

namespace OOP_2_3
{
    public partial class Form1 : Form
    {
        public Regex regex = new Regex(@"^[A-ZА-Я][a-zа-я]{1,20}$");
        public Global global;
        public List<Global> list = new List<Global>();
        public Search search;

        public Form1()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            search = new Search();
            search.Owner = this;
            search.Show();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            int x;
            try
            {
                if (!regex.IsMatch(textBox1.Text)) throw new Exception("Проверьте название");
                if (!(comboBox1.SelectedIndex >= 0)) throw new Exception("Проверьте тип");
                if (!(comboBox2.SelectedIndex >= 0)) throw new Exception("Проверьте отряд");
                if (!(comboBox3.SelectedIndex >= 0)) throw new Exception("Проверьте класс");
                if (!(comboBox4.SelectedIndex >= 0)) throw new Exception("Проверьте континент");
                if (!(Int32.TryParse(textBox2.Text, out x))) throw new Exception("Проверьте широту");
                if (!(Int32.TryParse(textBox3.Text, out x))) throw new Exception("Проверьте долготу");
                if (!(Int32.TryParse(textBox5.Text, out x))) throw new Exception("Проверьте площадь");
                if (!regex.IsMatch(textBox6.Text)) throw new Exception("Проверьте фамилию");
                if (!regex.IsMatch(textBox9.Text)) throw new Exception("Проверьте имя");
                if (!regex.IsMatch(textBox8.Text)) throw new Exception("Проверьте отчество");
                global = new Global();
                global.SetClassAnimal(textBox1.Text,
                    comboBox1.Text, richTextBox2.Text,
                    comboBox2.Text, trackBar1.Value,
                    comboBox3.Text, checkBox1.Checked,
                    global.GetOrialObitania(comboBox4.Text,
                   Convert.ToInt32(textBox2.Text),
                   Convert.ToInt32(textBox3.Text),
                   textBox4.Text,
                   Convert.ToInt32(textBox5.Text)),
                    global.GetKutator(textBox6.Text,
                    textBox9.Text,
                   textBox8.Text,
                   textBox7.Text), dateTimePicker1.Value.ToString());
                richTextBox1.Text = global.GetJSON();
                list.Add(global);
                listBox1.Items.Add(global.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if (i >= 0)
            {
                textBox1.Text = list[i].value.Nazvanie;
                comboBox1.Text = list[i].value.Tip;
                richTextBox2.Text = list[i].value.Opisanie;
                comboBox2.Text = list[i].value.Otrad;
                trackBar1.Value = list[i].value.Vozrast;
                comboBox3.Text = list[i].value.Klass;
                checkBox1.Checked = list[i].value.IsRedBook;
                comboBox4.Text = list[i].value.orialObitania.Kontinent;
                textBox2.Text = Convert.ToString(list[i].value.orialObitania.Shirota);
                textBox3.Text = Convert.ToString(list[i].value.orialObitania.Dolgota);
                textBox4.Text = list[i].value.orialObitania.Raen;
                textBox5.Text = Convert.ToString(list[i].value.orialObitania.Ploshad);
                textBox6.Text = list[i].value.kutator.Familia;
                textBox9.Text = list[i].value.kutator.Ima;
                textBox8.Text = list[i].value.kutator.Otchestvo;
                textBox7.Text = list[i].value.kutator.Strana;
                dateTimePicker1.Value = DateTime.Parse(list[i].value.Data);
                richTextBox1.Text = list[i].GetJSON();
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if (i >= 0)
            {
                list.RemoveAt(i);
                listBox1.Items.RemoveAt(i);
            }

            richTextBox1.Clear();
            richTextBox2.Clear();
            listBox1.ClearSelected();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void Update_Click(object sender, EventArgs e)
        {

            int i = listBox1.SelectedIndex;
            if (i >= 0)
            {
                int x;
                try
                {
                    if (!regex.IsMatch(textBox1.Text)) throw new Exception("Проверьте название");
                    if (!(comboBox1.SelectedIndex >= 0)) throw new Exception("Проверьте тип");
                    if (!(comboBox2.SelectedIndex >= 0)) throw new Exception("Проверьте отряд");
                    if (!(comboBox3.SelectedIndex >= 0)) throw new Exception("Проверьте класс");
                    if (!(comboBox4.SelectedIndex >= 0)) throw new Exception("Проверьте континент");
                    if (!(Int32.TryParse(textBox2.Text, out x))) throw new Exception("Проверьте широту");
                    if (!(Int32.TryParse(textBox3.Text, out x))) throw new Exception("Проверьте долготу");
                    if (!(Int32.TryParse(textBox5.Text, out x))) throw new Exception("Проверьте площадь");
                    if (!regex.IsMatch(textBox6.Text)) throw new Exception("Проверьте фамилию");
                    if (!regex.IsMatch(textBox9.Text)) throw new Exception("Проверьте имя");
                    if (!regex.IsMatch(textBox8.Text)) throw new Exception("Проверьте отчество");

                    list[i].value.Nazvanie = textBox1.Text;
                    list[i].value.Tip = comboBox1.Text;
                    list[i].value.Opisanie = richTextBox2.Text;
                    list[i].value.Otrad = comboBox2.Text;
                    list[i].value.Vozrast = trackBar1.Value;
                    list[i].value.Klass = comboBox3.Text;
                    list[i].value.IsRedBook = checkBox1.Checked;
                    list[i].value.orialObitania = list[i].GetOrialObitania(comboBox4.Text,
                       Convert.ToInt32(textBox2.Text),
                       Convert.ToInt32(textBox3.Text),
                       textBox4.Text,
                       Convert.ToInt32(textBox5.Text));
                    list[i].value.kutator = list[i].GetKutator(textBox6.Text,
                        textBox9.Text,
                       textBox8.Text,
                       textBox7.Text);
                    list[i].value.Data = dateTimePicker1.Value.ToString();
                    richTextBox1.Text = list[i].GetJSON();
                    listBox1.Items[listBox1.SelectedIndex] = list[i].ToString();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("base.txt", JsonConvert.SerializeObject(list));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream file = new FileStream("base.txt", FileMode.Open);
            StreamReader r = new StreamReader(file);
            list = JsonConvert.DeserializeObject<List<Global>>(r.ReadToEnd());
            for (int i = 0; i < list.Count; i++)
            {
                listBox1.Items.Add(list[i].ToString());
            }
            r.Close();
            file.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = "Возраст: " + Convert.ToString(trackBar1.Value);
        }
    }
}
