using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDotNet
{
    // оформление событий по стандартам / по правилам .NET Framework

    // Т.к. тип параметра нестандартный - требуется собственный делегат
    delegate void OopsEvent(object sender, OopsEventArgs e);
    delegate void ChangeValueEvent(object sender, OopsEventArgs e);
      
    // Класс-источник событий, будем наблюдать за объектами
    // этого класса
    class Subject
    {
        public event ChangeValueEvent ChangeValue;

        // параметр события OopsEvent
        private int _value;
        public int Value {
            get => _value;
            set {
                _value = value;
            }
        } // Value




        public Subject():this(-1) {}
        public Subject(int value) {
            _value = value;
        }

        // Поле события Oops - хранит список ссылок на методы, соответствующие 
        // делегату OopsEvent - void XXXX(object sender, OopsEventArgs e).
        public event OopsEvent Oops;

        // Метод, зажигающий событие - OnИмяСобытия
        public void OnOops() {
            // Имитируем изменение состояния объекта
            // _value = Utils.Random(-10, 10);

            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Oops: Ой-ой-ой! Что-то произошло!!! Новое значение {_value}");
            Console.ForegroundColor = old;

            // Если есть методы в списке зарегистрированных методов, то вызываем их
            if (Oops != null) {
                // OopsEventArgs - параметры событий, унаследован от EventArgs
                OopsEventArgs e = new OopsEventArgs {Value = _value}; // Параметры событий
                Oops(this, e);
            } // if
        } // OnOops

        // свойство, чье состояние будем отслеживать
        private int _interest;
        public int Interest {
            get { return _interest; }
            set {

                // просто зажигаем событие в нужном месте
                if (_interest != value) ChangeValue?.Invoke(this, new OopsEventArgs { Value = value });

                _interest = value;
            }
        }
    } // class Subject
}
