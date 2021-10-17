using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class SmartArray
    {
        private int[] _data;  // контейнер данных

        /* 
        public типЗначения this[типИндекса index] { код get; код set; } 
        public типЗначения this[тип1 индекс1, тип2 индекс2, ..., типN индексN] { код get; код set; } 
             
        */
        // Предотвращение выхода индекса за пределы массива
        // т.е. улучшенный индекс
        public int this[int index] {
            get {
                if (index < 0)
                    index = 0;
                else if (index >= _data.Length)
                    index = _data.Length - 1;
                return _data[index];
            } // get
            set {
                if (index < 0)
                    index = 0;
                else if (index >= _data.Length)
                    index = _data.Length - 1;
                _data[index] = value;
            } // set
        } // int indexer

        public int Length { get { return _data.Length; } }

        public SmartArray() : this(10) { }
        public SmartArray(int size)
        {
            if (size <= 0) size = 10;
            _data = new int[size];
        } // SmartArray

        public void Fill()
        {
            for (int i = 0; i < _data.Length; i++) {
                this[i] = i + 1;
            } // for
        } // Fill

        // вспомогательный массив
        private string[] color = new string[3];

        // индексатор может использоваться не только для
        // доступа к элементам массива, но и для преобразования 
        // данных - перегрузка индексатор
        public string this[string index] {
            get {
                string result;
                // switch() работает со строками
                switch (index) {
                    case "red":
                        result = color[0];
                        break;
                    case "green":
                        result = color[1];
                        break;
                    case "blue":
                        result = "синий";
                        break;
                    default:
                        result = color[2];
                        break;
                } // switch
                return result.ToUpper();
            } // get

            set {
                switch (index) {
                    case "red":
                        color[0] = value;
                        break;
                    case "green":
                        color[1] = value;
                        break;
                    default:
                        color[2] = "какая-то непонятка";
                        break;
                }
            }
        } // string indexer  
    } // class SmartArray
}
