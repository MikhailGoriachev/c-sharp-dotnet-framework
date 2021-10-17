using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    // предоставляет методы для делегирования
    class DemoOperation
    {
        public int Add(int x, int y) => x + y; 
        public int Sub(int x, int y) => x - y; 
        public int Mpy(int x, int y) => x * y; 
        public int Div(int x, int y) => y == 0?int.MaxValue:x / y;
    } // class DemoOperation
}
