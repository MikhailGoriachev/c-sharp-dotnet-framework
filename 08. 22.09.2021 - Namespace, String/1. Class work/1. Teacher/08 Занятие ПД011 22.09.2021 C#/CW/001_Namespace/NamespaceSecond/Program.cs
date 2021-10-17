using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// задание псевдонимов для типов
// using ИмяПсевдонима = ПолноеИмяТипа
using Person = NamespaceSecond.User;
using Printer = System.Console;

namespace NamespaceSecond
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 22.09.2021 - пространства имен";

            // применение псевдонимов типов
            Person person = new Person("Алекс");
            Printer.WriteLine($"Пользователь {person}");

            person.Name = "Федя";
            Printer.WriteLine($"Новое имя пользователя: {person.Name}");

            Printer.WriteLine("\n\n");
        } // Main
    } // class Program

    // пример класса
    class User
    {
        public string Name { get; set; }

        public User():this("user") { } // User

        public User(string name) => Name = name;

        public override string ToString() => $"{nameof(Name)}: {Name}";
    } // class User
}
