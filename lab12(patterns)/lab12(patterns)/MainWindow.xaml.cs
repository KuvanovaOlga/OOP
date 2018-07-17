using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace lab12_patterns_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Grid grid;
        public MainWindow()
        {
            InitializeComponent();
            grid = scope;
        }

        private void Create_Figure(object sender, RoutedEventArgs e)
        {
            ToolsWindow toolsWindow = new ToolsWindow();
            toolsWindow.Show();
        }

        private void MainFigure(object sender, RoutedEventArgs e)
        {
            Singleton singleton = Singleton.getInstance(scope);
        }

        private void ComplexFigure(object sender, RoutedEventArgs e)
        {
            var complexFigure = new ComplexFigureBuilder();
            complexFigure.Ellipse(MainWindow.grid);
            complexFigure.SecondEllips(MainWindow.grid);
            complexFigure.Rectangle(MainWindow.grid);
            complexFigure.GetResult();
        }
    }
}


