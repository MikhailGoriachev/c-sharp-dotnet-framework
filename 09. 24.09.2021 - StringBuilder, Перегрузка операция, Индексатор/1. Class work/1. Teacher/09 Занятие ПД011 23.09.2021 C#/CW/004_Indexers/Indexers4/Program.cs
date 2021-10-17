using System;

// Индексаторы для многомерных массивов

namespace Indexers
{
    class Program
    {
        static void Main() {
            Console.Title = "Занятие 23.09.2021 - индексаторы";

            MyMatrix my = new MyMatrix();

            my[1, 1] = 2;
            my[2, 1] = -5;

            Console.WriteLine(my[1, 1]);
            Console.WriteLine(my[0, 0]);
            Console.WriteLine(my[2, 1]);

            Show(my);
        } // Main

        // применение индексатора
        private static void Show(MyMatrix my) {
            for (int i = 0; i < my.Rows; i++) {
                for (int j = 0; j < my.Cols; j++) {
                    Console.Write($"{my[i, j], 8}");
                } // for j
                Console.WriteLine();
            } // for i
        } // Show


    } // class Program
}
