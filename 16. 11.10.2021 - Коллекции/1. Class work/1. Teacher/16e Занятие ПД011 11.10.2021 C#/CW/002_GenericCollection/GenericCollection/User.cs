using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    // класс для демонстрации работы с ObservableCollection
    class User
    {
        public string Name { get; set; }
        public int    Age  { get; set; }

        public override string ToString()
        {
            return $"[Name: {Name}; Age: {Age}]";
        } // ToString
    } // User
}
