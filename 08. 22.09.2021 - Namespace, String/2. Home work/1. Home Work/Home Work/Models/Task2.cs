using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *       Задача 2. Дана строка S (класс string). В строке слова разделяются одним или несколькими 
 *       пробелами, в результирующей строке слова должны разделяться одним пробелом:
 *         •	В строке поменять местами каждые два соседних слова.
 *         •	Из строки удалить все слова, начинающиеся и заканчивающиеся гласными буквами
 *         •	Поменять местами первое слово максимальной длины и первое слово минимальной длины в строке
 *         •	В каждом слове строки установить верхний регистр первой буквы
*/


namespace Home_Work.Models
{
    // Задание 2. Манипуляции со строкой 
    internal class Task2
    {
        // строка для обработки
        private string _line;

        #region Свойства 

        // свойство для доступа к полю _line
        public string Line { get => _line; set => _line = value; }

        #endregion

        #region Методы 

        // поменять местами каждые два соседних слова
        public string SwapEveryTwoWords()
        {
            // разделение строки
            string[] str = _line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // поменять местами каждые два слова
            for (int i = 0; i < str.Length - 1; i += 2)
                (str[i], str[i + 1]) = (str[i + 1], str[i]);

            // соединение строк
            return _line = string.Join(" ", str);
        }

        // удаление из строки всех слов начинающихся и заканчивающихся гласной буквой
        public string RemoveWordsStartEndVowel()
        {
            // разделение строки
            string[] str = _line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // гласные буквы
            char[] vowels = "eyuoaуеыаоэяиюё".ToCharArray();

            // предиктор
            bool pred(string s) {
                // перевод строки в нижний регистр
                string temp = s.ToLower();

                return temp.IndexOfAny(vowels) == 0 && temp.LastIndexOfAny(vowels) == temp.Length - 1;
            };

            // удаление строк 
            for (int i = 0; i < str.Length; i++)
                if (pred(str[i]))   str[i] = "";

            return _line = string.Join(" ", string.Join(" ", str)
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
        }

        // поменять местами первое слово масимальной длины и первой слово
        // минимальной длины
        public string SwapLongShortWords()
        {
            // разделение строки 
            string[] str = _line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // кортеж значение - индекс 
            (int val, int index) min = (str[0].Length, 0);
            (int val, int index) max = (str[0].Length, 0);

            // поиск индекса минимальной и максимальной строки
            for (int i = 0; i < str.Length; i++)
                {
                // текущая длина строки 
                (int val, int index) cur = (str[i].Length, i);

                // если текущая длина строки больше максимального значения 
                if (max.val < cur.val) max = cur;

                // если текущая длина строки меньше минимального значения 
                else if (min.val > cur.val) min = cur;
            }

            // поменять местами строки по индексу
            (str[min.index], str[max.index]) = (str[max.index], str[min.index]);

            // объединение строк
            return _line = string.Join(" ", str);
        }

        // в каждом слове строки установить верхний регистр первой буквы
        public string ToUpperFirstLetterWords()
        {
            // перевод строки в нижний регистр
            _line = _line.ToLower();

            // разделение строки 
            string[] str = _line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // перевод первой буквы каждого слова в верхний регистр
            for (int i = 0; i < str.Length; i++)
                str[i] = str[i].Substring(0, 1).ToUpper() + str[i].Substring(1);

            // объединение строки
            return _line = string.Join(" ", str);
        }

        #endregion

    }
}
