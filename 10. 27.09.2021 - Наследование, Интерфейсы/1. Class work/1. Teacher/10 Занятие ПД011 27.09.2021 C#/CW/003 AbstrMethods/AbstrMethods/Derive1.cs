using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrMethods
{
    class Derive1 : Base
    {
        public override void Method1() {
            Console.WriteLine($"Метод Method1() класса Derive1, a = {a}");
        }

        public override void Method1(int x) {
            Console.WriteLine($"Метод Method1() класса Derive1, x = {x}");
        }
    }

}
