using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    // Делегат для обработки события
    public delegate void Handler(object obj);
     
    // Класс-источник событий, будем наблюдать за объектами
    // этого класса
    class Subject
    {
        public int Value { get; set; }

        // Поле события Oops - хранит коллекцию ссылок на методы, соответствующие 
        // делегату Handler -- void(object obj)
        // Эти ссылки должны добавляться объектами при подписке на событие класса Subject 
        public event Handler Oops;

        // Метод, зажигающий событие - его сигнатура никаким образом не
        // связана с делегатом !!!!
        public void FireOops() {
            // Имитируем изменение состояния объекта
            Value = Utils.Random(-10, 10);

            // Только для индикации
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Oops: Ой-ой-ой! Что-то произошло!!! Новое значение {Value}");
            Console.ForegroundColor = old;

            // Если есть методы в списке зарегистрированных методов, то вызываем их
            // if (Oops != null) Oops(this);

            // вызов цепочки методов при помощи Элвис-оператора
            // делегат?.Invoke(параметры)  -- если делегат != null (есть методы
            // для вызова) вызываются его методы
            Oops?.Invoke(this);
        } // FireOops
    } // class Subject
}
