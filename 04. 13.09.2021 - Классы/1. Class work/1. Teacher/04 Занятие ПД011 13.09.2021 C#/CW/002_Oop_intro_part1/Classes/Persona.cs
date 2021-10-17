using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    // класс с использованием полей данных, геттеры и сеттеры
    // обеспечивают доступ к полям данных
    // _name, _age, _salary
    /* public */
    class Persona
    {
        // поля
        private string _name;
        private int    _age;
        private int    _salary;

        // конструктор по умолчанию, создается по макросу ctor
        public Persona():this("Блощицкий В.П.", 67, 34000)
        { } // Persona


        // частичный конструктор - одно или несколько значений задаем по умолчанию
        public Persona(string name, int age):this(name, age, 10000) {
        } // Persona

        // полный конструктор, создается по макросу ctorf
        public Persona(string name, int age, int salary) {
            _name = name;
            _age = age;
            _salary = salary;
        } // Persona

        // геттеры   и сеттеры 
        // аксессоры и мутаторы 

        public string GetName()
        {
            return _name; 
        } // GetName

        public void SetName(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                _name = value;
        } // SetName


        // краткая форма записи метода геттера
        public int GetAge() => _age;

        public void SetAge(int value) {
            if (value > 0) _age = value;
        } // SetAge

        // краткая форма записи метода геттера
        public int GetSalary() => _salary;

        public void SetSalary(int value) {
            if (value > 0) _salary = value;
        } // SetSalary

        // для сортировки по возрасту (!! static !!)
        public static int ComparatorAge(Persona x, Persona y) => x._age - y._age;

        // переопределение метода преобразования полей класса в строку 
        // base - обращение к базовому классу

        public override string ToString() {
            // return  $"{base.ToString()} -> name: {_name}; age: {_age}; salary: {_salary}";
            return  $"name: {_name}; age: {_age}; salary: {_salary}";
        } // ToString
    } // class Persona
}
