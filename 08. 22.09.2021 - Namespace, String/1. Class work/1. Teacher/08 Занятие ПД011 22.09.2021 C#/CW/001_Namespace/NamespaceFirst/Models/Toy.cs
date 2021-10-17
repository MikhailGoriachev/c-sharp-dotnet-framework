using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// вложенное пространство имен
namespace NamespaceFirst.Models
{
    class Toy
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public override string ToString() => $"название {Name}, цена {Price}";
    }
}
