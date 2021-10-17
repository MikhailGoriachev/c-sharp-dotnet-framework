using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDotNet
{
    class Observer1
    {
        // Имя наблюдателя
        public string Name { get; set; }

        public Observer1() : this("X") { }
        public Observer1(string name) {
            Name = name;
        } // Observer1

        // Обработчик события Oops - имя формируется по правилу ИмяСобытияEventHandler
        // должен соответствовать делегату EventHandler из .Net Framework
        public void OopsEventHandler(object sender, EventArgs e) {
            Console.WriteLine($"Observer1({Name}): Вижу, что ой-ой-ой, получил {(sender as Subject)?.Value}");
        } // OopsEventHandler
    } // class Observer1
}
