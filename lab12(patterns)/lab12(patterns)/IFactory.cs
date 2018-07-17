using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lab12_patterns_
{
    public interface IFactory
    {
        ICircle Circle();
        ISquare Square();
    }
}
