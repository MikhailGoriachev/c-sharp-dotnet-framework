using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // установка заголовка окна 
            Console.Title = "Домашнее задание на 27.09.2021";

            // объект App
            App app = new App();

            // запуск меню приложения 
            app.Menu();

            // возвращение исходного цвета 
            Console.ResetColor();
        }
    }
}
