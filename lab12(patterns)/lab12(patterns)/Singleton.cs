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
    public sealed class Singleton
    {
        private static Singleton instance;

        private Singleton(Grid grid)
        {
             Rectangle Rectangle()
             {
                Random random = new Random();
                Rectangle rectangle = new Rectangle
                {
                    Width = 100,
                    Height = 100,
                    Fill = Brushes.PeachPuff
                };
                grid.Children.Add(rectangle);
                return rectangle;
             }
            Rectangle();
        }

        public static Singleton getInstance(Grid grid)
        {
            return instance ?? (instance = new Singleton(grid));
        }
    }
}
