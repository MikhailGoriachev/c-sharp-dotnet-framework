using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClasses
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 16.09.2021 - свойства только для чтения, статические классы, конструкторы";

            // Поле readonly в классе
            Demo demo1 = new Demo();
            Demo demo2 = new Demo(201, 202);
            Demo demo3 = new Demo(503, 505);

            Console.WriteLine($"demo1 = {demo1};\ndemo2 = {demo2};\ndemo3 = {demo3}\n");
            Console.WriteLine();
            
            // Статическое поле readonly в классе
            Console.WriteLine($"{StaticDemo.A}\n");
            
            StaticDemo st1 = new StaticDemo();
            Console.WriteLine($"Объект создан: {st1}\n");
            StaticDemo.B++;
            Console.WriteLine($"Поле B изменено: {st1}\n");
            
            // Еще два объекта со статическим полем readonly
            StaticDemo st2 = new StaticDemo();
            Console.WriteLine($"Объект создан: {st2}\n");
            StaticDemo st3 = new StaticDemo();
            Console.WriteLine($"Объект создан: {st3}\n");
            
            // применение static-класса
            Utils.ShowA();
            Utils.A = Utils.RandObj.Next(-100, 101);
            Utils.ShowA();
            
        } // Main
    } // class Program
}
