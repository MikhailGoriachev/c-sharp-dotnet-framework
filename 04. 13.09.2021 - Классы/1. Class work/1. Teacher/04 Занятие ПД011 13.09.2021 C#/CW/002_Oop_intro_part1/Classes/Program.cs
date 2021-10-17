using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 13.09.2021 - введение в ООП C# - классы";
            /*
            Console.WriteLine("\nОбычная работа с геттерами и сеттерами:\n");

            // работаем с объектом класса Persona с использованием
            // сеттеров и геттеров (т.е. аксессоров)
            Persona persona1 = new Persona();
            Console.WriteLine(
                $"Объект класса Person: persona1 = {persona1}\nполя класса, получены геттерами " +
                $"Name: {persona1.GetName()} Age:{persona1.GetAge()} Salary:{persona1.GetSalary()}\n"
            );

            persona1.SetName("Васильева П.О.");
            persona1.SetAge(26);
            persona1.SetSalary(21000);

            Console.WriteLine(
                $"Объект класса Person: persona1 = {persona1}\nполя класса, получены геттерами " +
                $"Name: {persona1.GetName()} Age:{persona1.GetAge()} Salary:{persona1.GetSalary()}\n"
            );

            Persona persona2 = new Persona("Иванов Б.Е.", 43, 29670);
            Console.WriteLine(
                $"Объект класса Person: persona2 = {persona2}\nполя класса, получены геттерами " +
                $"Name: {persona2.GetName()} Age:{persona2.GetAge()} Salary:{persona2.GetSalary()}\n"
            );
            
            // Массив объектов класса Persona
            Persona[] personas = new[] {
                new Persona("Романова А.Г.", 47, 31000), 
                new Persona("Воликов Б.Е.", 41, 27000), 
                new Persona("Абалкин Л.Ю.", 78, 29300), 
            };

            Console.WriteLine("\nСписок сотрудников:");
            Array.ForEach(personas, Console.WriteLine);
            
            // компаратор для сортировки по фамилии и инициалам
            int ComparatorPersona(Persona x, Persona y) =>
                x.GetName().CompareTo(y.GetName());

            // сортировка массива объектов при помощи компаратора
            Array.Sort(personas, ComparatorPersona);

            Console.WriteLine("\nСписок сотрудников, упорядоченный по алфавиту:");
            Array.ForEach(personas, Console.WriteLine);

            // сортировка при помощи одного из компараторов класса
            Array.Sort(personas, Persona.ComparatorAge);

            Console.WriteLine("\nСписок сотрудников, упорядоченный по возрасту:");
            Array.ForEach(personas, Console.WriteLine);

            Console.WriteLine("\n\n");
            */
            // новый подход - работа со свойствами
            
            // создание объекта с использованием конструктора
            Person person1 = new Person("Полуэкт", 22);
            Console.WriteLine($"Объект класса Person -> {person1}," +
                              $"\nвычисляемое свойство {person1.IsComplete}\n");

            // создание объекта с использованием списка инициализации
            // такой список возможен только для свойств
            Person person2 = new Person {Age = 19, Name = "Варвара", Salary = 23_000};
            Console.WriteLine($"Объект класса Person -> {person2}," +
                              $"\nвычисляемое свойство {person2.IsComplete}\n");

            // Работа со свойствами
            person1.Name = "Дунаев Д.Н.";
            person1.Age = 33;
            person1.Salary = -1133;

            int value = 28;
            person2.Name = "Харламова Ю.Т.";
            person2.Age = value;
            person2.Salary = 23_000;

            Console.WriteLine("\n\n" +
                 "    ┌───────────────────┬──────────┬─────────────────┐\n" +
                 "    │ Фамилия И.О.      |  Возраст | Совершеннолетие |\n" +
                 "    ├───────────────────┼──────────┼─────────────────┤\n" +
                $"    │ {person1.Name, -17} │ {person1.Age, 8} │ {person1.IsComplete, 15} │\n" +
                $"    │ {person2.Name, -17} │ {person2.Age, 8} │ {person2.IsComplete, 15} │\n" +
                 "    └───────────────────┴──────────┴─────────────────┘\n\n"
            );

            Person[] persons = {
                new Person {Name = "Олегова Б.Д.",   Age = 34, Salary = 14800}, 
                new Person {Name = "Янковский Н.К.", Age = 18, Salary = 21500}, 
                new Person {Name = "Абалкин Л.П.",   Age = 19, Salary = 17900}, 
            };

            Console.WriteLine("\n\nМассив объектов класса Person:");
            Array.ForEach(persons, Console.WriteLine);

            Array.Sort(persons, Person.CompareByName);
            
            Console.WriteLine("\n\nУпорядоченный массив объектов класса Person:");
            Array.ForEach(persons, Console.WriteLine);
        } // Main

    } // class Program
}
