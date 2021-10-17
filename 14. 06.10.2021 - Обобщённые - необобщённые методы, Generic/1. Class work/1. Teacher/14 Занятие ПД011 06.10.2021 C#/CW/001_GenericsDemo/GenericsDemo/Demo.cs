using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    class Demo
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"{Name}: ({Width} x {Height})";
    } // class Demo
}
