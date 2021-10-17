using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Toy
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int AgeGroup { get; set; }

        public override string ToString() {
            return $"{{Name: {Name}; Price: {Price:C2}; AgeGroup: {AgeGroup}}}";
        }
    }
}
