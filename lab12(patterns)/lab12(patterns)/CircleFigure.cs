using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace lab12_patterns_
{
    public class CircleFigure : ICircle,IClone
    {
        public CircleFigure()
        {
            Ellipse(MainWindow.grid);
        }

        public Ellipse Ellipse(Grid grid)
        {
            Random random = new Random();
            Ellipse ellipse = new Ellipse
            {
                Margin = new Thickness(random.Next(-380, 380), random.Next(-380, 380), 0, 0),
                Height = 50,
                Width = 50,
                Fill = Brushes.Magenta
            };
            ellipse.MouseDown += ClickOnFigure;
            grid.Children.Add(ellipse);
            return ellipse;
        }

        private void ClickOnFigure(object sender, MouseButtonEventArgs e)
        {
            Clone();
        }

        public IClone Clone()
        {
            return new CircleFigure();
        }
        
    }
}
