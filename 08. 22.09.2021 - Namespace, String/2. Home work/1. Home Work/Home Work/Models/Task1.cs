using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Задача 1. Решение задачи разместите в классе, класс расположите во 
 *  вложенном пространстве имен Models Вашего проекта. Выполнить 
 *  обработку строк – используйте класс string:
 *      •	Даны строки S и S0. Удалить из строки S все подстроки, 
 *          совпадающие с S0. Если совпадающих подстрок нет, то вывести 
 *          строку S без изменений.
 *      •	Даны строки S, S1 и S2. Заменить в строке S все вхождения 
 *          строки S1 на строку S2
 *      •	Дана строка, состоящая из слов, разделенных пробелами (одним 
 *          или несколькими). Вывести строку, содержащую эти же слова, 
 *          разделенные одним символом «.» (точка). В конце строки точку не
 *          ставить.
 *      •	Дана строка, состоящая из слов, разделенных пробелами (одним или 
 *          несколькими). Вывести строку, содержащую эти же слова, разделенные
 *          одним пробелом и расположенные в обратном порядке.
 *      •	Дана строка, состоящая из слов, набранных заглавными буквами и 
 *          разделенных пробелами (одним или несколькими). Вывести строку, 
 *          содержащую эти же слова, разделенные одним пробелом и расположенные 
 *          в алфавитном порядке строчным буквами.
 */

namespace Home_Work.Models
{
    // Задание 1. Манипуляции со строкой 
    internal class Task1
    {
        // строка для обработки
        private string _line;

        #region Свойства 

        // свойство для доступа к полю _line
        public string Line { get => _line; set => _line = value; }

        #endregion

        #region Методы 

        // удаление подстроки
        public string RemoveSubstring(string substring) =>_line = string.Join(" ", _line
                    .Replace(substring, "")
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));

        // замена подстрок
        public string ReplaceSubstring(string substring, string repString) =>
            _line = string.Join(" ", _line
                    .Replace(substring, repString)
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));

        // замена разделителя слов ' ' на '.'
        public string ReplaceSeparator() =>
            _line = string.Join(".", _line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));

        // изменение порядка слов на обратный и с разделителем ' '
        public string ReversReplaceSeparator()
        {
            // разделение строки
            string [] str = _line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // изменение порядка строк 
            Array.Reverse(str);

            // соединение строк
            return _line = string.Join(" ", str);
        }

        // сортировка в алфавитном порядке, перевод строки в нижний регистр,
        // установка разделителя - один пробел
        public string SortAndToLower()
        {
            // перевод строки в нижний регистр
            _line = _line.ToLower();

            // разделение строки
            string[] str = _line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // сортировка строк 
            Array.Sort(str);

            // соединение строк
            return _line = string.Join(" ", str);
        }

        #endregion
    }
}
