using System;

// Индексаторы.

namespace Indexers
{
    // Пример индексатора с защитой от выхода за пределы массива
    class Program
    {
        static void Main() {
            Console.Title = "Занятие 23.09.2021 - индексаторы";

            // объект с индексатором
            StringArray my = new StringArray {
                [0] = "string 1",
                [1] = "string 2",
                [2] = "string 3",
                [3] = "string 4",
                [4] = "string 5",
                [5] = "string 6"   // этот оператор приведет к сообщению об ошибке
            };

            

            Console.WriteLine();
            Console.WriteLine(my[0]);
            Console.WriteLine(my[1]);
            Console.WriteLine(my[2]);
            Console.WriteLine(my[3]);
            Console.WriteLine(my[4]);
            Console.WriteLine(my[5]);  // это чтение вернет сообщение об ошибке
        }
    }
}
