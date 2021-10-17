using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // примитивные типы, значимые типы
            byte   b1 = 1, b2 = 10, b3 = 111;
            Console.WriteLine($"byte: b1 = {b1}, b2 = {b2}, b3 = {b3}");
            Console.WriteLine($"байтовая переменная {b1}");

            Console.WriteLine("byte: b1 = {0}, b2 = {1}, b3 = {2}", b1, b2, b3);
            sbyte  sb1, sb2 = -2, sb3 = 11;

            
            short  sh1, sh2 = -1223, sh3 = 1223;
            ushort ush1, ush2 = 12111, ush3 = ushort.MaxValue;
            
            int    in1, in2, in3;
            uint   uin1, uin2, uin3;


            long   long1, long2, long3;
            ulong  ulong1, ulong2, ulong3;

            float  float1, float2, float3;
            double double1, double2, double3;

            decimal money1 = 23000.5M, money2 = 234.6M, money3 = -100000M;
            Console.WriteLine($"decimal: money1 = {money1}; money2 = {money2}; money3 = {money3}; размер в байтах: {sizeof(decimal)}");

            // UTF-8
            char ch1, ch2, ch3;

            bool bool1 = false, bool2 = true, bool3 = false;
            Console.WriteLine($"bool: bool1 = {bool1}, bool2 = {bool2}, bool3 = {bool3}, размер в байтах: {sizeof(bool)}");
            
            // объектные типы
            string s1, s2 = "Это текст", s3 = "и это текст";
            Console.WriteLine($"Вывод строк:\n{s2}\n{s3}");

            // а еще могут быть структуры struct, перечисление enum
            // классы class, интерфейсы interface
            // делегаты delegate, события event
            // а также: кортежи, динамические типы
        } // Main
    } // class Program
}
