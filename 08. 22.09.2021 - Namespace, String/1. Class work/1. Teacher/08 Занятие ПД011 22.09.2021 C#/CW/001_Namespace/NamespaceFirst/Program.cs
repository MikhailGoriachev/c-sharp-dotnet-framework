// импорт внешних пространств имен
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// импорт вложенных пространств имен - не имеет значения, размещено 
// пространство имен в этом жек файле или нет
using NamespaceFirst.AccountSpace;
using NamespaceFirst.PhoneSpace;
using NamespaceFirst.Models;         // это друая папка - это никак не определяется визуально

namespace NamespaceFirst
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 22.09.2021 - введение в пространства имен";

            // использование вложенных пространств имен
            // полное квалификационное имя
            // AccountSpace.Account account  = new AccountSpace.Account(120);
            // PhoneSpace.Phone phone = new PhoneSpace.Phone("Xiaomi");            
            
            // неполное имя - можно использовать после применения оператора using
            Account account  = new Account(120);
            Phone phone = new Phone("Xiaomi");

            // NamespaceFirst.Models.Toy toy = new NamespaceFirst.Models.Toy {Name = "мячик", Price = 20};
            Toy toy = new Toy {Name = "мячик", Price = 20};

            Console.WriteLine($"Учетная запись пользователя с ид: {account}");
            Console.WriteLine($"Производитель телефона: {phone}");
            Console.WriteLine($"Игрушка: {toy}");
        } // Main
    } // class Program

    // пример вложенного пространства имен
    namespace AccountSpace
    {
        class Account
        {
            public int Id { get; private set;}
            public Account(int id) {
                Id = id;
            } // Account

            public override string ToString() => $"{Id}";
        } // class Account

        class Admin { }
    } // namespace AccountSpace

    // еще один пример вложенного пространства имен
    namespace PhoneSpace
    {
        class Phone
        {
            public string Name { get; set; }

            public Phone(): this("Nokia") { }

            public Phone(string name) =>Name = name;

            public override string ToString() => $"{nameof(Name)} \"{Name}\"";
        } // class Phone

    } // namespace PhoneSpace
}
