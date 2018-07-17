using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;

namespace Lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary
    public partial class MainWindow : Window
    {
        DB db = new DB(Properties.Settings.Default.Kuv_UNIVERConnectionString);

        public List<T> RunQuery<T>(string Query)
        {
            List<T> result = new List<T>();
            foreach (T c in db.ExecuteQuery<T>(Query))
                result.Add(c);
            return result;
        }
        public MainWindow()
        {
            InitializeComponent();
            if (db.DatabaseExists()) outgrid.ItemsSource = db.STUDENTs;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.SubmitChanges();
        }
      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            byte[] image = File.ReadAllBytes("C:\\Users\\olgak\\source\\screen.bmp");
            Binary Binarydta = new Binary(image);
            MyImage img = new MyImage();
            img.Id =1;
            img.Img = Binarydta;
            db.MyImages.InsertOnSubmit(img);
            db.SubmitChanges();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            outgrid.ItemsSource =
                RunQuery<STUDENT>(@"SELECT * FROM dbo.STUDENT where IDGROUPS = 5");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string res = "Methods: ";
            foreach (string r in
                RunQuery<string>(@"SELECT name FROM SYS.all_objects where TYx`PE = 'IF' and OBJECT_ID>0"))
                res+="\r\n"+r;
            MessageBox.Show(res);
        }
    }
}
