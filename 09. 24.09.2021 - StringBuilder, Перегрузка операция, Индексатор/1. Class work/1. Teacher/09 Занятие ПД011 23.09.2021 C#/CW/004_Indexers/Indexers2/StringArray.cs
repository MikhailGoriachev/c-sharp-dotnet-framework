using System;

namespace Indexers
{
    // Индексатор с защитой от выхода за пределы массива
    class StringArray
    {
        private string[] _array = new string[5];

        // Индексатор. 
        public string this[int index] {
            get {    // Аксессор.
                if (index >= 0 && index < _array.Length)
                    return _array[index];
                else
                    return "Попытка обращения за пределы массива.";
            }

            set  {    // Мутатор.
                if (index >= 0 && index < _array.Length)
                    _array[index] = value;
                else
                    Console.WriteLine("Попытка записи за пределами массива.");
            } // set
        } // indexer
    } // class MyClass
}
