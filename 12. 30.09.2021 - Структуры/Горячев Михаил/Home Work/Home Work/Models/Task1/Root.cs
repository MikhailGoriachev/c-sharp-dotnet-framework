using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Models.Task1
{
    // Класс Уравнение
    abstract internal class Root
    {
        // число a
        protected int _a;

        // число b
        protected int _b;

        // число x
        protected double? _x;

        #region Свойства

        // доступ к полю _a
        public int A { get => _a; set => _a = value; }

        // доступ к полю _b
        public int B { get => _b; set => _b = value; }

        // доступ к полю _x
        public double? X { get => _x; }

        #endregion
    }
}
