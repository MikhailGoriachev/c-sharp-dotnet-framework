using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Занятие 20.09.2021 - операторы ?? и .?";
            /*
            // Одно из отличий ссылочных типов от типов значений состоит в том,
            // что переменные ссылочных типов могут принимать значение null. Например:
            // object o = null;
            // string s = null;
            // Если переменным ссылочного типа не присваивается значение, то им дается
            // значение по умолчанию - null.
            // Фактически оно говорит об отстутсвии значения как такового.
            // Типы значений (например, int, decimal, double и т.д.) не могут принимать
            // значение null.
            // Типы имя? тоже могут принимать значение null: int?, double?, bool? и т.д.

            // string s = null;
            // Console.WriteLine($"{s.Length}"); 
            
            // Оператор ??
            // Оператор ?? называется оператором null-объединения.
            // Он применяется для установки значений по умолчанию для типов,
            // которые допускают значение null.
            // тип имя = значение1 ?? значение2;

            // Оператор ?? возвращает значение1 (левыйОперанд), если оно (значение) не равно null.
            // Иначе возвращается значение2 (правый операнд).
            // При этом левый операнд должен быть типа, способного принимать значение null

            object x = null;
            object y = x ?? 100;  // равно 100, так как x равен null
                    // x == null?100:x;
            Console.WriteLine($"\nОператор ??, пример1: x = {x}, y = {y}\n");

            object z = 200;
            object t = z ?? 44; // равно 200, так как z не равен null
            Console.WriteLine($"\nОператор ??, пример2: z = {z}, t = {t}\n\n");

            // Но мы не можем написать следующим образом:
            // int v = 44;
            // int u = v ?? 100;
            // Здесь переменная v представляет значимый тип int и не может принимать
            // значение null, поэтому в качестве левого операнда в операции ?? она
            // использоваться не может.
            
            // для модификации типа int, принимающего значение null можно: 
            // int? v = 44;
            // int u = v ?? 100;
            */

            // string s = null;
            // Console.WriteLine($"{s?.Length??-1}"); 
            
            
            // Оператор условного null  ?.  Элвис-оператор
            // Иногда при работе с объектами, которые принимают значение null, мы можем
            // столкнуться с ошибкой: мы пытаемся обратиться к объекту, а этот объект равен null
            string companyName = "не определено";
            User user = new User();

            // такой код вызывает исключение
            // Console.WriteLine($"Телефон произвела компания \"{user.Phone.Company.Name}\"");

            // такой код не вызывает исключения, но он очень громоздкий
            // и нет сообщения о пустых полях
            /*
            if(user != null) {
                if(user.Phone != null) {
                    if (user.Phone.Company != null) {
                        companyName = user.Phone.Company.Name;
                        Console.WriteLine($"Производитель телефона: \"{companyName}\"\n");
                    } // if
                } // if
            } // if
            Console.WriteLine($"Производитель телефона: \"{companyName}\"\n");
            */
            
            /*
            // упростим себе жизнь, но не очень-то
            if(user != null && user.Phone != null && user.Phone.Company != null) {
                companyName = user.Phone.Company.Name;
            } else {
                companyName = "название не известно";
            } // if 
            Console.WriteLine($"Производитель телефона: \"{companyName}\"\n");
            */

            
            // решение - использование условного null-оператора, Элвис-оператора
            // Выражение ?. и представляет оператор условного null. Здесь последовательно
            // проверяется равен ли объект user и вложенные объекты значению null. Если же
            // на каком-то этапе один из объектов окажется равным null, то companyName
            // будет иметь значение по умолчанию, то есть null.
            companyName = user?.Phone?.Company?.Name;
            Console.WriteLine($"Производитель телефона: \"{companyName}\"\n");
            
            // совместное использование ?. и ??
            companyName = user.Phone?.Company?.Name??"Скучная компания";
            Console.WriteLine($"Производитель телефона: \"{companyName}\"\n");
            
           
            // как можно инициировать этот объект
            // первый вариант, в стиле C++
            User user1 = new User();
            user1.Phone = new Phone();
            user1.Phone.Company = new Company();
            user1.Phone.Company.Name = "ТелефонныйАппарат";
            companyName = user1.Phone.Company.Name;
            Console.WriteLine($"Производитель телефона: \"{companyName}\"\n");
            
            // второй вариант, который более соотвтетсвтует "духу" C# 
            user.Phone = new Phone { 
                Company = new Company {Name = "Company B"}
            };
            companyName = user.Phone.Company.Name;
            Console.WriteLine($"Производитель телефона: \"{companyName}\"\n");
            
        } // Main

        #region Вспомогательные классы
        class User
        {
            public Phone Phone { get; set; }
        }
 
        class Phone
        {
            public Company Company { get; set; }
        }
 
        class Company
        {
            public string Name { get; set; }
        }
        #endregion
    } // class Program
}
