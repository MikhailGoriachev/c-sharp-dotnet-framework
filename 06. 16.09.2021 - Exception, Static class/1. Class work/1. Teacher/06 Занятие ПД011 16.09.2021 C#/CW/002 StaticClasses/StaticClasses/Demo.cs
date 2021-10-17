using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClasses
{
	// демонстрация readonly-свойства 
    class Demo
    {
        public int a;
        public const int One = 1;
        
        // принимает значение при инициализации или в конструкторе
        public readonly int x;  

        public Demo() : this(-1, -5) { }
        public Demo(int a, int x)
        {
            this.a = a;

            // значение поля readonly определяется при создании объекта,
            // в зависимости от значений других полей
            this.x = a < 0? x - 100 : x + 100;
        } // Demo

        // строковое представление объекта
        public override string ToString() => $"a: {a}   x: {x}";

    } // class Demo
}
