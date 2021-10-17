using System;

// Индексаторы.

namespace Indexers
{
    // Пример простейшего индексатора
    // Индексатор - операции доступа к свойствам объекта

    class Program
    {
        static void Main() {
            Console.Title = "Занятие 23.09.2021 - индексаторы";

            // Объект, использующий индексатор
            IntArray my = new IntArray();

            // запись в контейнер класса значений
            // при помощи индексатора
            my[0] = 1;
            my[1] = 2;
            my[2] = 3;
            my[3] = 4;
            my[4] = 5;

            Console.WriteLine(my[0]);
            Console.WriteLine(my[1]);
            Console.WriteLine(my[2]);
            Console.WriteLine(my[3]);
            Console.WriteLine(my[4]);

            // простая обработка - проблема в том, что размер массива
            // не доступен (
            int imax = 0;
            for (int i = 1; i < 5; i++) {
                if (my[i] > my[imax]) imax = i;
            } // for i

            Console.WriteLine($"Максимальный элемент равен {my[imax]}");
            
            // создание и инициализация в современном стиле
            IntArray array1 = new IntArray {
                [0] = -1, 
                [1] = 2, 
                [2] = -11,
                [3] = 42,
                [4] = -2
            };


            for (int i = 0; i < 5; i++) {
                Console.WriteLine($"{array1[i]}");
            }
        } // Main
    } // class Program
}
