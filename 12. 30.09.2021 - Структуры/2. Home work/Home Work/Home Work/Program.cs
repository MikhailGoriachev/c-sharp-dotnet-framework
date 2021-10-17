using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Home_Work.Application;    // подключение главного класса приложения 

namespace Home_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // установка заголовка окна 
            Console.Title = "Домашнее задание на 04.10.2021";

            // установка размера окна 
            Console.WindowHeight = 35;
            Console.WindowWidth = 160;

            // объект App
            App app = new App();

            // запуск меню приложения 
            app.Menu();

            // возвращение исходного цвета 
            Console.ResetColor();
        }
    }
}
