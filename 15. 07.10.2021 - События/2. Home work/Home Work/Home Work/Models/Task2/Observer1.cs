using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Home_Work.Models.Task2
{
    // Класс Наблюдатель 1
    internal class Observer1
    {
        // обработчик 1 события Childhood
        static public void ChildhoodEventHandler(Object sender, ChildhoodEventArgs e)
        {
            /*
            * 2.	Во втором обработчике выводить строку 
            * "обнаружен несовершеннолетний" в заголовок окна. 
            */

            // вывод строки "обнаружен несовершеннолетний" в заголовок окна
            Console.Title = "Обнаружен несовершеннолетний";
        }
    }
}
