using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace lab12_patterns_
{
    public interface ICircle
    {
        Ellipse Ellipse(Grid grid);
    }
}
