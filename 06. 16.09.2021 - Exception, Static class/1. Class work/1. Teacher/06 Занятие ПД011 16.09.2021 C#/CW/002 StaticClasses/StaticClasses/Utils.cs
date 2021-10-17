using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClasses
{
    static class Utils
    {
        // атрибут для работы с классом
        public static int A;

        // статический конструктор - без спецификаторов доступа,
        // явно не вызывается
        static Utils() {
            A = 1001;
        } // Utils

        // статический метод для вывода значения статического свойства
        public static void ShowA() {
            Console.WriteLine($"A = {A}");
        } // ShowA

        // статический объект для работы с классом
        public static Random RandObj = new Random();
    } // class Utils
}
