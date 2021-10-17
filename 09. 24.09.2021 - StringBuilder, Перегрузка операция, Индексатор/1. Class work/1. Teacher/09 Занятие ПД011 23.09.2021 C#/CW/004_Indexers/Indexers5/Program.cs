using System;

// Индексаторы. 
// Может быть более одного индексатора в классе

namespace Indexers
{
    class Program
    {
        static void Main() {
            Console.Title = "Занятие 23.09.2021 - индексаторы";

            // такой вот самодельный словарь на индексаторе :)
            Dictionary dictionary = new Dictionary();

            Console.WriteLine("\n\nПервый индексатор:\n");
            Console.WriteLine(dictionary["книга"]);
            Console.WriteLine(dictionary["дом"]);
            Console.WriteLine(dictionary["ручка"]);
            Console.WriteLine(dictionary["стол"]);
            Console.WriteLine(dictionary["карандаш"]);
            Console.WriteLine(dictionary["яблоко"]);
            Console.WriteLine(dictionary["солнце"]);

            Console.WriteLine(new string('—', 20));
            Console.WriteLine("\n\nВторой индексатор:\n");
            for (int i = 0; i < dictionary.Length; i++) {
                Console.WriteLine(dictionary[i]);
            } // for i
        } // Main
    } // class Program
}
