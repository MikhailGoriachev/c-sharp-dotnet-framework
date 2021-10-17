using Home_Work.Application;    // подключение главного класса приложения 
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
            Console.Title = "Домашнее задание на 11.10.2021";

            // установка размера окна
            Console.SetWindowSize(120, 44);

            // объект App
            App app = new App();

            // запуск меню приложения 
            app.Menu();

            // возвращение исходного цвета 
            Console.ResetColor();
        }
    }
}
