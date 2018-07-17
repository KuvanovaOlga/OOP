using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace lab12_patterns_
{
    public interface IComplexFigureBuilder
    {
        Ellipse Ellipse(Grid grid);
        Rectangle Rectangle(Grid grid);
        Ellipse SecondEllips(Grid grid);
        void GetResult();
    }
}
