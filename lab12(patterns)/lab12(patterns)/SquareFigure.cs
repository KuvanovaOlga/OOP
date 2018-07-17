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
    public class SquareFigure : ISquare,IClone
    {
        public SquareFigure()
        {
            Rectangle(MainWindow.grid);
        }

        public Rectangle Rectangle(Grid grid)
        {
            Random random = new Random();
            Rectangle rectangle = new Rectangle
            {
                Margin = new Thickness(random.Next(-380, 380), random.Next(-380, 380), 0, 0),
                Width = 50,
                Height = 50,
                Fill = Brushes.BlueViolet
            };
            rectangle.MouseDown += ClickOnFigure;
            grid.Children.Add(rectangle);
            return rectangle;
        }

        private void ClickOnFigure(object sender, MouseButtonEventArgs e)
        {
            Clone();
        }

        public IClone Clone()
        {
            return new SquareFigure();
        }
    }
}
