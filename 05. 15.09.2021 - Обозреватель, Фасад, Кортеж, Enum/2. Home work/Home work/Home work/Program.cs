﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_work
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            // заголовок приложения 
            Console.Title = "Домашнее задание на 16.09.2021";

            // объект App
            App app = new App();

            // запуск меню
            app.Menu();
        }
    }
}
