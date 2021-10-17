using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Models.Task2
{
    // Класс Аргументы события Relocate
    internal class RelocateEventArgs
    {
        // новое место проживания 
        public string NewSity { get; set; }

        // старое место проживания
        public string OldSity { get; set; }
    }
}
