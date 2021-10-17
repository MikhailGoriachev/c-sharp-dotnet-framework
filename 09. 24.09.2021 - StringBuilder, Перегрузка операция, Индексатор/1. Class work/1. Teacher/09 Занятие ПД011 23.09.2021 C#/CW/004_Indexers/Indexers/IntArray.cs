using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indexers
{
    class IntArray
    {
        // контейнер данных
        private int[] _array = new int[5];

        // Индексатор. 
        public int this[int index] {
            get => _array[index];           // Аксессор
            set => _array[index] = value;   // Мутатор
        }
    }   
}
