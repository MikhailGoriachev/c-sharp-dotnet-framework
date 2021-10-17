using System;
using System.Collections;

namespace Indexers
{
    // Пример класса, реализующего более одного индексатора
    // Реализуем своеобразный "словарь" :)
    class Dictionary
    {
        // массив кортежей - для имитации пар "ключ - значение"
        private (string Key, string Value)[] _pairs = new (string Key, string Value)[5];   

        public Dictionary() {
            _pairs = new[] {
                ("книга", "book"),
                ("ручка", "pen"),
                ("солнце", "sun"),
                ("яблоко", "apple"),
                ("стол",   "table") };
        } // Dictionary

        // перегруженный строковый индексатор для переводов
        public string this[string index] {
            get {
                bool Predicat((string Key, string Value) item) => item.Key == index;

                int i = Array.FindIndex(_pairs, Predicat);
                return i >= 0?_pairs[i].Key + " - " + _pairs[i].Value: $"{index} - нет перевода для этого слова.";
            } // get
        } // indexer

        // перегруженный числовой индексатор 
        public string this[int index] {
            get {
                if (index >= 0 && index < _pairs.Length)
                    return _pairs[index].Key + " - " + _pairs[index].Value;
                return "Попытка обращения за пределы массива.";
            } // get
        } // indexer     


        public int Length => _pairs.Length;

    } // class Dictionary
}
