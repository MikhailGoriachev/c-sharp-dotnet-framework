using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Home_work.Application;    // подключение главного класса приложения 

namespace Home_work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // устновка размера окна консоли
            Console.SetWindowSize(140, 35);

            // установка заголовка окна 
            Console.Title = "Домашнее задание на 30.09.2021";

            // объект App
            App app = new App();

            // запуск меню приложения 
            app.Menu();

            // возвращение исходного цвета 
            Console.ResetColor();
        }
    }
}
