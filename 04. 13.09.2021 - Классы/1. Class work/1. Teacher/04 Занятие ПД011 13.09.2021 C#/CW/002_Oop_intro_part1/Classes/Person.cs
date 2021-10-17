using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    // класс, построенный на свойствах
    class Person
    {
        // private string name = "Вася";

        // автосвойство - prop
        // obj.Name = "значение" -- работает set
        // obj.Name -- работает get
        public string Name { get; set; } = "Василий";  // инициализация автосвойства

        // полное свойство - propfull, использование "классического" синтаксиса
        private int _age;
        public int Age {
            get { return _age; }
            set { // _age = value >=0 ? value:_age;
                if (value >= 0)
                    _age = value;
            } // value  - контекстное ключевое слово
        }


        // вычисляемое свойство, классический синтаксис
        public bool IsComplete {
            get { return _age > 21; }
        }

        // вычисляемое свойство, новый синтаксис
        public bool IsRetard => _age > 65;

        // Полное свойство для оклада, использование нового синтаксиса
        private int _salary;
        public int Salary {
            get => _salary;
            set => _salary = value > 0?value:0; 
        } // Salary


        // строковое представление объекта класса
        public override string ToString() =>
            $"Name: {Name}, Age: {Age}, Salary: {Salary}, IsComplete: {(IsComplete?"можно": "нельзя") + " продавать алкоголь"}";

        // Конструктор не обязателен
        public Person(string name, int age) {
            // this - ссылка на текущий экземпляр объекта
            //        это не указетель
            Name = name;
            _age = age;
            _salary = 23000;
        } // Person

        // вызов конструктора без параметров, в списке инициализации
        // вызываем конструкор с параметрами
        public Person(): this("", 1) {}

        public static int CompareByName(Person x, Person y) =>
            x.Name.CompareTo(y.Name);
    } // class Person
}
