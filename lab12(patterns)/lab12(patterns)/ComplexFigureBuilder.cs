using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace lab12_patterns_
{

    public class ComplexFigureBuilder:IComplexFigureBuilder
    {
        static Random random = new Random();
        int _x = random.Next(-300, 300);
        int _y = random.Next(-300, 300);
        public Ellipse Ellipse(Grid grid)
        {
            Ellipse ellipse = new Ellipse
            {
                Margin = new Thickness(_x, _y, 0, 0),
                Height = 50,
                Width = 50,
                Fill = Brushes.MintCream
            };
            grid.Children.Add(ellipse);
            return ellipse;
        }

        public Rectangle Rectangle(Grid grid)
        {
            Random random = new Random();
            Rectangle rectangle = new Rectangle
            {
                Margin = new Thickness(_x+50, _y+50, 0, 0),
                Width = 50,
                Height = 50,
                Fill = Brushes.Moccasin
            };
            
            grid.Children.Add(rectangle);
            return rectangle;
        }

        public Ellipse SecondEllips(Grid grid)
        {
            Ellipse ellipse = new Ellipse
            {
                Margin = new Thickness(_x+100, _x+100, 0, 0),
                Height = 50,
                Width = 50,
                Fill = Brushes.LightSkyBlue
            };
            grid.Children.Add(ellipse);
            return ellipse;
        }


        public void GetResult()
        {
            SecondEllips(MainWindow.grid);
            Rectangle(MainWindow.grid);
            Ellipse(MainWindow.grid);
        }
    }
}
