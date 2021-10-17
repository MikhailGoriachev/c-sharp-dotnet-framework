using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    // Класс-наблюдатель, демонстрирует, что регистрировать, как обработчик события,
    // можно обычные методы 
    class Observer1
    {
        // Имя наблюдателя
        public string Name { get; set; }

        public Observer1() : this("Mr. X") { }
        public Observer1(string name) {
            Name = name;
        } // Observer1

        // Обработчик события Oops - т.е. мы будем регистрировать
        // этот метод в классе Subject
        // Этот метод будет вызоваться при возникновении события Oops
        // сигнатура обработчика соответствует делегату Handler
        public void One(object obj) {
            // без элвис-оператора
            // Console.WriteLine($"Observer1({Name}): Вижу, что ой-ой-ой, получил {((Subject) obj).Value}");

            // с элвис-оператором
            Console.WriteLine($"Observer1({Name}): Вижу, что ой-ой-ой, получил {(obj as Subject)?.Value}");
        } // One
    } // class Observer1
}
