using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClasses
{
    // Класс для демонстрации статического поля readonly
    class StaticDemo
    {
        // Существует в одном экземпляре, общем для 
        // любого количества объектов
        public static readonly int A;
        public static int B;
          
        public int MyProperty { get; set; }

        public StaticDemo() { 
            Console.WriteLine("dynamic-конструктор StaticDemo"); 
            MyProperty = 1;
            
            // плохой код - иниицализация static-поля
            // B = 1;

            // ошибка синтаксиса - нельзя записывать в static readonly в нестатическом конструкторе
            // A = 1;
        }

        // статический конструктор класса - только в нем можно 
        // инициировать статические поля класса
        // статический конструктор - без спецификаторов доступа,
        // явно не вызывается, вызывается автоматически, однократно
        // при создании первого объекта класса или при первом
        // обращении к статическому свойству/полю
        static StaticDemo() {
            Console.WriteLine("static-конструктор StaticDemo\n");
            // Какие-то действия
            A = 23; // значение, полученное из каких-то действий
            B = A + 9;

            // MyProperty = 1;
        } // StaticDemo

        // строковое представление объекта
        public override string ToString() => $"static readonly a = {A};  static b = {B}";
    } // class StaticDemo
}
