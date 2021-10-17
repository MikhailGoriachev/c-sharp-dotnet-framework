using System;
using System.Collections;                // необобщенные коллекции - т.е. коллекции для типа object
// using System.Collections.Generic;     // обобщенные коллекции - для обобщенных типов
// using System.Collections.Concurrent;  // коллекции - для параллельной, многопоточной обработки
using System.Linq;
using System.Text;
using System.Threading;

/* 
    Коллекция   - класс, реализующий интерфейсы ICollection, IEnumerable.
    IEnumerable - этот базовый интерфейс коллекций предоставляет другой
        интерфейс, IEnumerator, для реализации перебора коллекции, т.е.
        для создания итераторов, работы цикла foreach()
    
    Обычные операции для коллекции - добавление и удаление элементов
    
    Виды коллекций C#
    ► необобщенные коллекции - для типа object - ArrayList, SortedList, BitArray, Hashtable, 
      Queue, Stack
      любой тип м.б. помещен в коллекцию, но требуется упаковка в тип object при записи в коллекцию (inboxing),
      требуется распаковка из object в исходный тип при чтении из коллекции (outboxing)   
      потери времени на inboxing/outboxing => обычно используются обобщенные коллекции
    ► за счет обобщенных типов создаются специализированные для данного типа коллекции, т.к. нет 
      inboxing/outboxing => скорость более высокая
*/

namespace Collections
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 11.10.2021 - необобщенные коллекции .Net Framework";

            // ArrayListDemo();

            // QueueDemo();

            StackDemo();

        } // Main

        // Это односвязный список: IList, ICollection
        private static void ArrayListDemo() {
            // один из конструкторов коллекции при создании объекта
            // ArrayList arrayList = new ArrayList();
            // ArrayList arrayList = new ArrayList(10);
            ArrayList arrayList = new ArrayList(new[] {1, 4, 5});

            // Операторы добавления в список
            arrayList.Add(25);
            arrayList.Add(Math.PI);
            arrayList.Add("строка, добавленная в список");
            arrayList.Add(new Toy { Name = "мяч", Price = 85, AgeGroup = 12 });
            Show("Первый вариант коллекции:\n", arrayList);
            
            // программист должен знать, что и где хранится
            (arrayList[arrayList.Count - 1] as Toy).Name = "машина";
            Console.WriteLine($"Измененный элемент массива (объект): {arrayList[arrayList.Count - 1]}");
            
            // создание коллекции из массива
            arrayList = new ArrayList(new [] {-1, -2});

            // Добавление нескольких значений одним оператором
            arrayList.AddRange(new [] { -1, -2, -3 });

            // Безграничные возможности C# )))
            // добавление в список анонимного объекта анонимного типа
            arrayList.Add(new { Id = 5, Name = "Василина", IsSchoolship = true });

            Show("\nЕще одна вариация ArrayList:\n", arrayList);
            
            Console.WriteLine("\nДемонстрация индексирования для ArrayList:");
            // Операция индексирования тоже работает - точнее индексатор
            for (int i = 0; i < arrayList.Count; i++) {
                Console.Write($@"\{arrayList[i]}\  ");
            } // for
            Console.WriteLine();
            
            Console.WriteLine("\nИзучаем свойство Capacity:");
            // Capacity - текущая емкость, Capacity >= Count
            // при увеличении размера списка - Capacity тоже увеличивается
            // при удалении элементов Capacity не уменьшается
            // Прямое задание Capacity возможно, но при Capacity < Count - выьрасывается
            // исключение
            Console.WriteLine($"\nCapacity = {arrayList.Capacity};  Count = {arrayList.Count}");
            arrayList.AddRange(new [] { -1, -2, -3, 6, 7 });
            Console.WriteLine($"Capacity = {arrayList.Capacity};  Count = {arrayList.Count}");
            arrayList.AddRange(new [] { -1, -2, -3, 6, 7, -2, -3, 6, 7, -2, -3, 6, 7 });
            Console.WriteLine($"Capacity = {arrayList.Capacity};  Count = {arrayList.Count}");

            arrayList.Capacity = 30;
            Console.WriteLine($"\n\nCapacity = {arrayList.Capacity};  Count = {arrayList.Count}");
            Show("\nЕще одна вариация ArrayList:\n", arrayList);

            // Емкость списка == размеру списка, экономия памяти
            arrayList.TrimToSize();
            Console.WriteLine($"\nПосле TrimToSize(): Capacity = {arrayList.Capacity};  Count = {arrayList.Count}");

            // Свойство Capacity присуще и другим коллекциям, ведет себя примерно также
            
            Console.WriteLine("\nВставка в нужную позицию списка");
            arrayList.Insert(2, "^_^");
            arrayList.Insert(7, "^_^");
            arrayList.Insert(11, "^_^");
            Show("После вставки в позицию 2:\n", arrayList);
            
            arrayList.Insert(8, new Toy { Name = "LEGO EV3", Price = 29000, AgeGroup = 8 });
            Show("После вставки в позицию 8:\n", arrayList);
            
            // Удаление элементов спска
            arrayList.Remove("^_^");   // удаляет только первое вхождение
            Show("\nПосле удаления \"^_^\":\n", arrayList);
            
            // Удаление 10 элементов, начиная с индекса 1 
            arrayList.RemoveRange(1, 10);
            Show("\nПосле удаления элементов от индекса 1 до индекса 10:\n", arrayList);

            arrayList.RemoveAt(3);
            Show("\nПосле удаления элемента с индексом 3:\n", arrayList);
            
            // Поисковые методы
            // IndexOf(), LastIndexOf() - индекс или -1, если не найдено
            // Contains() - true если элемент в списке
            Console.WriteLine("\nЧисло   IndexOf()   LastIndex()   Contains()");
            int x = 7;
            Console.WriteLine($"{x, 5}   {arrayList.IndexOf(x), 9}   {arrayList.LastIndexOf(x), 11}   " + 
                $"{arrayList.Contains(x), 10}");
            x = 3;
            Console.WriteLine($"{x,5}   {arrayList.IndexOf(x),9}   {arrayList.LastIndexOf(x), 11}   " +
              $"{arrayList.Contains(x), 10}");
            string s = "^_^";
            Console.WriteLine($"{s, 5}   {arrayList.IndexOf(s),9}   {arrayList.LastIndexOf(s),11}   " +
                              $"{arrayList.Contains(s),10}");
            
        } // ArrayListDemo

        // вывод коллекции ArrayList (как параметра, реализующего интерфейс IEnumerable)
        static void Show(string title, IEnumerable arrayList) {
            // собрать строку и вывести в консоль
            StringBuilder sb = new StringBuilder(title);
            int lenCounter = 0;

            // Спасибо IEnumerable - за этот чудный foreach
            foreach (var item in arrayList) {
                string s = $@"\{item}\  ";
                sb.Append(s);
                // принудительный переход на новую строку при длине строки > 70 символов
                lenCounter += s.Length;
                if (lenCounter > 70) {
                    sb.Append("\n");
                    lenCounter = 0;
                } // if
            } // foreach

            Console.WriteLine(sb);
        } // Show

        // ---------------------------- Очередь - FIFO - FCFS ------------------------------------

        // организация элементов в коллекции - FIFO (First In First Out) == FCFS (First Come First Served)
        // добавление элемента только в конец очереди  -- Enque()
        // удаление элемента только из начала очереди  -- Deque() 
        private static void QueueDemo() {
            Queue queue = new Queue();
            string str = "ёжик";

            // добавить в очередь символы из строки str
            foreach (var ch in str) {
                queue.Enqueue(ch); // для string тоже поддерживается индексирование

                foreach (var item in queue) Console.Write($"{item, 3}");
                Console.Write("\r");
                Thread.Sleep(1000);
            }
            Console.WriteLine();

            Show("\n\nОчередь: ", queue);
            Console.WriteLine();
            
            // получить элемент в начале очереди без его удаления
            char c = (char)queue.Peek();
            Console.WriteLine($"\nВ начале очереди элемент со значением {c}\n");

            // демонстрация удаления элементов из очереди - из головы очереди 
            while (queue.Count > 0) {
                c = (char)queue.Dequeue();    // убрать из очереди
                Console.Write($"Вышел элемент: {c, 3}\nОстались     : ");

                foreach (var item in queue) Console.Write($"{item, 3}");
                Console.WriteLine();
                Thread.Sleep(1000);
            } // for i
            
            Console.WriteLine();
        } // QueueDemo

        // ---------------------------- Стек - LIFO - FCLS ------------------------------------

        // организация элементов в коллекции - LIFO (Last In First Out) == FCLS (First Come Last Served)
        // начало стека == вершина стека
        // добавление элемента только в начало стека  -- Push() 
        // удаление элемента только из начала стека   -- Pop()
        private static void StackDemo() {
            Stack stack = new Stack();
            string str = "ёжик";

            Console.WriteLine("  V");

            // добавить в стек символы из строки str
            foreach (var ch in str) {
                stack.Push(ch);
                foreach (var item in stack) Console.Write($"{item,3}");
                Console.Write("\r");
                Thread.Sleep(1_000);
            }
            Console.WriteLine();
            
            // получить элемент в начале стека (на вершине) без его удаления
            char c = (char)stack.Peek();
            Console.WriteLine($"В начале стека (на вершине) элемент со значением {c}");

            // демонстрация вывода элементов из стека 
            while (stack.Count > 0) {
                c = (char)stack.Pop();    // убрать из стека
                Console.Write($"Вышел элемент: {c,3}\nОстались     : ");
                foreach (var item in stack) Console.Write($"{item,3}");
                Console.WriteLine();
                Thread.Sleep(1_000);
            } // while
            Console.WriteLine();
        } // StackDemo

        
    } //  class Program
}
