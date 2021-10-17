using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDotNet
{
    // параметр события - класс, расширяющий стандартный EventArgs
    class OopsEventArgs: EventArgs
    {
        // свойство или атрибут для передачи параметров
        public int Value { get; set; }

        // можно добавить и другие свойства
    } // class OopsEventArgs
}
