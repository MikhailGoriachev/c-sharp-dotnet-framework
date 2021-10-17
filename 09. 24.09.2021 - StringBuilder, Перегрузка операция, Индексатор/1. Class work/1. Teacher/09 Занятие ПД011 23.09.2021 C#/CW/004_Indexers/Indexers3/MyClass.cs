using System;

namespace Indexers
{
    // индексатор для массива строк
    class MyClass
    {
        // инкапсулированный массив
        private string[] _array = new string[5];

        // Индексатор. 
        public string this[int index] {
            get {   // Аксессор.
                if (index >= 0 && index < _array.Length)
                    return _array[index];
                
                return "Попытка обращения за пределы массива.";
            }
            
            set  {   // Мутатор.
                if (index >= 0 && index < _array.Length)
                    _array[index] = value;
                else
                    Console.WriteLine("Попытка записи за пределами массива.");
            }
        }

        // размер инкапсулированного массива
        public int Length => _array.Length; 
    } // class MyClass
}
