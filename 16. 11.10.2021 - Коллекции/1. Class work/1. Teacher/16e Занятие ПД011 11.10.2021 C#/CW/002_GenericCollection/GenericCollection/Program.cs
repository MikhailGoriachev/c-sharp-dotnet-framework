using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollection
{
    class Program
    {
        /* 
        Коллекции, которые построены на обобщенных типах. Они быстрее необобщенных т.к.
        не нужен inboxing/outboxing
        Станадртные необобщенные - в  System.Collections.Generic

        Интерфейсы, реализуемые обобщенныии коллекциями:
        ☼ IEnumerable<T>  - метод GetEnumerator(), который возвращает конкретную реализацию IEnumerator<T> 
        ☼ IEnumerator<T>  - возможность последовательного перебора элементов
        ☼ ICollection<T>  - общие методы для коллекций (Add(), Remove(), ...)
        ☼ IList<T>        - функционал для последовательных списков
        ☼ IComparer<T>    - метод Compare() сравнения двух однотипных объектов
        ☼ IDictionary<TKey, TValue> - словарь, хранящий элементы в парах ключ (TKey) - значение (TValue)
             
        Обобщенные коллекции:
        List<T>         - односвязный список
        LinkedList<T>   - двусвязный список

        Queue<T>        - очередь
        Stack<T>        - стек
        SortedSet<T>    - отсортированная коллекция

        Dictionary<TKey, TValue> - пары ключ - значение
        SortedDictionary<TKey, TValue> - пары ключ-значение, отсортировнные по ключу
        SortedList<TKey, TValue> - пары ключ-значение, отсортировнные по ключу. Отличается от 
                                   SortedDictionary использованием памяти, скоростью вставки и
                                   удаления элементов

        ObservableCollection<T> - определен в System.Collection.ObjectModel, по функционалу - похож
                         на список, может извещать внешние объекты о том, что коллекция была изменена 
        */
        static void Main(string[] args) {
            Console.Title = "Занятие 11.10.2021 - обобщенные коллекции .Net Framework";

            // SolveTask3();
            // Console.WriteLine();
            // SolveTask4();

        } // Main


        // Решение задачи 3
        private static void SolveTask3() {
            Task3 task3 = new Task3();

            Console.WriteLine("Задача 3.\n\nОчереди до обработки:");
            Console.WriteLine("Очередь1: " + Utils.ToString(task3.Queue1));
            Console.WriteLine("Очередь2: " + Utils.ToString(task3.Queue2));

            task3.Solve();

            Console.WriteLine("\nОчереди после обработки:");
            Console.WriteLine("Очередь1: " + Utils.ToString(task3.Queue1));
            Console.WriteLine("Очередь2: " + Utils.ToString(task3.Queue2));
        } // SolveTask3


        // Решение задачи 4
        private static void SolveTask4() {
            Task4 task4 = new Task4();

            Console.WriteLine("Задача 4.\n\nОчереди до обработки:");
            Console.WriteLine("Очередь1: " + Utils.ToString(task4.Queue1));
            Console.WriteLine("Очередь2: " + Utils.ToString(task4.Queue2));
            Console.WriteLine("Очередь3: " + Utils.ToString(task4.Queue3));

            task4.Solve();

            Console.WriteLine("\nОчереди после обработки:");
            Console.WriteLine("Очередь1: " + Utils.ToString(task4.Queue1));
            Console.WriteLine("Очередь2: " + Utils.ToString(task4.Queue2));
            Console.WriteLine("Очередь3: " + Utils.ToString(task4.Queue3));
        } // SolveTask4



        // вывод коллекции 
        static void Show(string title, ICollection<User> userList) {
            // собрать строку и вывести в консоль
            StringBuilder sb = new StringBuilder(title);

            // Спасибо IEnumerable - за этот чудный foreach
            foreach (var item in userList) {
                sb.Append($"{item}\n");
            } // foreach

            Console.WriteLine(sb);
        } // Show
    } // class Program
}
