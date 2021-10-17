using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Home_Work.Application.App.Utils;   // для использования утилит

namespace Home_Work.Models.Task2
{
    // Структура Студент
    internal struct Student
    {
        // ФИО студента
        private string _name;

        // название группы 
        private string _group; 

        // коллекция из оценок
        Mark[] _marks;

        #region Свойства 

        // доступ к полю _name
        public string Name { get => _name; set => _name = !String.IsNullOrWhiteSpace(value) ? value : 
                throw new Exception("Student: Поле Name нельзя инициализировать пустой строкой!"); }

        // доступ к полю _group
        public string Group { get => _group; set => _group = !String.IsNullOrWhiteSpace(value) ? value :
                throw new Exception("Student: Поле Group нельзя инициализировать пустой строкой!");
        }

        // доступ к полю _marks
        public Mark[] Marks {  get => _marks; set => _marks = value.Length == 5 ? value : throw new Exception($"Student: Коллекция оценок должна быть размером 5 оценок! Текущий размер: {value.Length}"); }

        // размер коллекции оценок 
        public int Lenght {  get => _marks.Length; }

        // средний балл
        public double Average {  get {
                double sum = 0d;
                foreach (var item in _marks) sum += item.MarkValue;
                return sum / Marks.Length;
        } }

        #endregion

        #region Индексатор 

        // индексатор 
        public Mark this[int index] {
            get => index < _marks.Length || index >= 0 ? _marks[index] : throw new Exception($"Student: Выход за границы массива! Значение: {index,5}");

            set { if (index < _marks.Length || index >= 0) _marks[index] = value; 
                else throw new Exception($"Student: Выход за границы массива! Значение: {index,5}"); } 
        }

        #endregion 

        #region Методы 

        // вывод студента в таблицу
        public void ShowElem(int num)
        {
            WriteColorXY("     ║    ║                 ║                 ║                 ║                 ║                 ║                 ║                 ║                 ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{num, 2}", 7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_group, -15}", 12, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{_name, -15}", 30, textColor: ConsoleColor.Cyan);
            WriteColorXY($"       {_marks[0].MarkValue}       ", 48, textColor: ConsoleColor.Green);
            WriteColorXY($"       {_marks[1].MarkValue}       ", 66, textColor: ConsoleColor.Green);
            WriteColorXY($"       {_marks[2].MarkValue}       ", 84, textColor: ConsoleColor.Green);
            WriteColorXY($"       {_marks[3].MarkValue}       ", 102, textColor: ConsoleColor.Green);
            WriteColorXY($"       {_marks[4].MarkValue}       ", 120, textColor: ConsoleColor.Green);
            WriteColorXY($"      {Average, 3:n1}      ", 138, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColorXY("     ╠════╬═════════════════╬═════════════════╬═════════════════╬═════════════════╬═════════════════╬═════════════════╬═════════════════╬═════════════════╣\n", textColor: ConsoleColor.Magenta);
        }

        #endregion

        // Структура Оценка
        internal struct Mark 
        {
            // название предмета 
            private string _name;

            // оценка 
            private int _markValue;

            #region Свойства 

            // доступ к полю _name
            public string Name { get => _name; set => _name = value; }

            // доступ к полю _markValue
            public int MarkValue { get => _markValue; set => _markValue = value >= 1 && value <= 5 ? value : 
                    throw new Exception($"Mark: Недопустимое значение оценки. Значение: {value,5}"); }

            #endregion
        }

    }
}
