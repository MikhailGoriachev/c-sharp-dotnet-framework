using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Interface
{
    // Интерфейс Решение уравнения
    internal interface ISolver
    {
        // решение уравнения
        void Solve();

        // определение наличия решения
        bool HasSolver();

        // вывод уравнения
        void Show(int num);

        // получение типа уравнения 
        string GetName();
    }
}
