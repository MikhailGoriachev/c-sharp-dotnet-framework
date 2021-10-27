using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableDemo
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 14.10.2021 - интерфейс IEnumerble в C#, итераторы";

            Group group = new Group();

            // Перебор элементов коллекции Group при помощи цикла for()
            // что не всегда удобно. 
            Console.WriteLine("\nВывод коллекции внешними средствами:\nЦикл for:");
            for (int i = 0; i < group.Length; i++) {
                Console.WriteLine($"{group[i]}");
            } // for i

            // Вывод коллекции в консоль за счет foreach, который в ToString(),
            // работаем с реализацией IEnumerable в массиве - контейнере
            Console.WriteLine($"\nКоллекция пользователей - при помощи foreach в ToString():\n{group}");
 
            
            // Для использования с коллекцией цикла foreach в классе коллекции
            // д.б. реализован интерфейс IEnumerable
            Console.WriteLine("\nЦикл foreach:");
            foreach (var user in group) {
                Console.WriteLine($"{user}");
            } // foreach


            // Именованный итератор - например, перебор заданного количества элементов 
            // с начала коллекции
            int n = 3;
            Console.WriteLine($"\nИспользование именованного итератора, выводим первые {n}:");
            foreach (var user in group.First(n)) {
                Console.WriteLine($"{user}");
            } // foreach

                    
            n = 2 * group.Length;
            Console.WriteLine("\nПопытка вывести записей больше, чем есть в массиве");
            foreach (var user in group.First(n)) {
                Console.WriteLine($"{user}");
            } // foreach

            // Еще один именованный итератор - выполняет фильтрацию данных
            int bound = 21;
            Console.WriteLine($"\nПри проходе по коллекции возвращаем только пользователей с возрастом > {bound}");
            foreach (var user in group.GetAgeGrather(bound)) {
                Console.WriteLine($"{user}");
            } // foreach

            // Еще один именованный итератор - выполняет фильтрацию данных
            int lo = 12_000, hi = 17_000;
            Console.WriteLine($"\nПри проходе по коллекции возвращаем только пользователей с" +
                              $" окладом от {lo} до {hi}");
            foreach (var user in group.SalaryBetween(lo, hi)) {
                Console.WriteLine($"{user}");
            } // foreach

            
            // Еще  один пример - доступ к свойствам через итератор
            Person person = new Person {Name = "Laravel Symfony", Age = 34, Weight = 98.6};
            Console.WriteLine($"\nПерсона {person}, теперь выводим по свойствам: ");
            foreach (var prop in person) {
                Console.WriteLine(prop);
            } // foreach

            
            Console.WriteLine("\nНабор свойств переменной типа User");
            User user1 = new User {Age = 22, Name = "CodeIgniter Angular", Salary = 23900};
            foreach (var prop in user1) {
                Console.WriteLine(prop);
            } // foreach
            
        } // Main
    } // class Program
}
