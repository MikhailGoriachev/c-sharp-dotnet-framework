using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 	Proc3. Описать метод Mean(x, y), вычисляющую среднее арифметическое a_mean=(x+y)/2 и
 * 	среднее геометрическое g_mean=√(x∙y), двух положительных вещественных чисел x и y. 
 * 	Возвращать a_mean, g_mean из метода в кортеже. С помощью этого метода найти среднее 
 * 	арифметическое и среднее геометрическое для трех пар случайных чисел из диапазона 
 * 	значений [0, 10].
 * 	
 *	Proc5. Описать метод RectPS(x1, y1, x2, y2), вычисляющую периметр и площадь прямоугольника
 *	со сторонами, параллельными осям координат, по координатам (x1, y1), (x2, y2) его 
 *	противоположных вершин (стороны вычисляются как a = Math.Abs(x2 - x1), b = Math.Abs(y2 – y1)).
 *	Метод возвращает кортеж с периметром и площадью. С помощью этого метода найти периметры и 
 *	площади трех прямоугольников с данными противоположными вершинами.
 */

// Класс Решение математических задач
namespace Home_work.Task_1
{
    public static class TuplesDemo
    {
        // Proc3 Формулы: a_mean=(x+y)/2 и g_mean=√(x∙y)
        public static (double a_mean, double g_mean) Mean(double x, double y) => ((x + y) / 2, Math.Sqrt(x * y));

        // Proc5 Формулы: (стороны вычисляются как a = Math.Abs(x2 - x1), b = Math.Abs(y2 – y1))
        public static (double perimeter, double area) RectPS(double x1, double y1, double x2, double y2)
        {
            // кортеж со сторонами прямоугольника
            (double a, double b) = (Math.Abs(x2 - x1), Math.Abs(y2 - y1));

            // вычисление результата
            return (2 * (a + b), a * b);
        }
    }
}
