using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialTypes
{
    // Классы могут быть частичными. То есть мы можем иметь несколько файлов
    // с определением одного и того же класса, и при компиляции все эти
    // определения будут скомпилированы в одно.
    // Например, определим в проекте два файла с кодом. Не столь важно как
    // эти файлы будут называться. Например, PersonBase.cs и PersonAdditional.cs.
    
    class Program
    { 
        static void Main(string[] args) {
            Console.Title = "Занятие 20.09.2021 - частичные типы и методы";

            // использование частичного типа

            // создание объекта частичного типа
            Person user = new Person {Name = "Наталья Романофф", Age = 32};
            Console.WriteLine($"\nПользователь {user}\n");

            // вызов методов частичного типа
            user.Login();
            user.SetPassword("_aBcD_012!_");
            user.Logout();

            Console.WriteLine("\n\n");
        } // Main
    } // class Program
}
