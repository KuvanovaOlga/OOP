using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab12_patterns_
{
    /// <summary>
    /// Логика взаимодействия для ToolsWindow.xaml
    /// </summary>
    public partial class ToolsWindow : Window
    {
        public string typeFigure;
        public int count;
        public ToolsWindow()
        {
            InitializeComponent();
        }
        public void changeFigureType(object sender, SelectionChangedEventArgs e)
        {
            switch (TypeFigure.SelectedIndex)
            {
                case 0:
                    typeFigure = "Circle";
                    break;
                case 1:
                    typeFigure = "Square";
                    break;
            }
        }

        private void changeCountFigure(object sender, SelectionChangedEventArgs e)
        {
            switch (CountFigure.SelectedIndex)
            {
                case 0:
                    count = 1;
                    break;
                case 1:
                    count = 2;
                    break;
                case 2:
                    count = 3;
                    break;
            }
        }

        private void CreateFigure(object sender, RoutedEventArgs e)
        {
            if (typeFigure == "Square")
            {
                IFactory factory1 = new FigursFactory();
                var square = factory1.Square();
                for (int i = 0; i < count; i++)
                {
                    square.Rectangle(MainWindow.grid);
                    Thread.Sleep(500);
                }
            }
            if (typeFigure == "Circle")
            {
                IFactory factory1 = new FigursFactory();
                var circle = factory1.Circle();
                for (int i = 0; i < count; i++)
                {
                    circle.Ellipse(MainWindow.grid);
                    Thread.Sleep(500);
                }
            }
        }
    }
}
