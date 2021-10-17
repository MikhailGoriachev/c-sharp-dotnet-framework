using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Models.Task1
{
    // Класс Аргументы события PowerChange
    internal class PowerChangeEventArgs : EventArgs
    {
        // старое значение мощности 
        public int OldPower { get; set; }

        // новое значение мощности 
        public int NewPower { get; set; }
    }
}
