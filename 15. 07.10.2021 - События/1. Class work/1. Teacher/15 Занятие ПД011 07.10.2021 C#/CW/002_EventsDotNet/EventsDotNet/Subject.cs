using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDotNet
{
    // оформление событий по стандартам / по правилам .NET Framework

    // Делегат для работы события - EventHandler, стандартный тип делегата
    // для событий - собственный тип делегата уже не нужен
     
    // Класс-источник событий, будем наблюдать за объектами
    // этого класса
    class Subject
    {
        public int Value { get; set; }

        // Поле события Oops - хранит список ссылок на методы, соответствующие 
        // делегату EventHandler - void XXXX(object sender, EventArgs e).
        public event EventHandler Oops;

        // Метод, зажигающий событие - OnИмяСобытия
        public void OnOops() {
            // Имитируем изменение состояния объекта
            Value = Utils.Random(-10, 10);

            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Oops: Ой-ой-ой! Что-то произошло!!! Новое значение {Value}");
            Console.ForegroundColor = old;

            // Если есть методы в списке зарегистрированных методов, то вызываем их
            if (Oops != null) {
                // EventArgs - базовый класс для создания объекта - параметра событий
                // EventArgs: можно унаследовать от этого класса и передавать нужные
                // параметры в классе-наследнике
                // EventArgs.Empty - единственное статическое поле класса, ссылка на пустой параметр
                EventArgs e = new EventArgs(); // Параметры событий
                Oops(this, e);
                // Oops(this, EventArgs.Empty);  // в д.с. можно использовать пустой параметр
            } // if
        } // OnOops
    } // class Subject
}
