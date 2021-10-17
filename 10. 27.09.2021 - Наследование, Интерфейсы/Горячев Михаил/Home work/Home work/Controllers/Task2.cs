using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_work.Models.Task2;       // подключение классов для задания 2
using Home_work.Interface;          // подключение интерфейсов для задания 2

using static Home_work.Application.App.Utils;       // для использования утилит

namespace Home_work.Controllers
{
    // Класс Обработка по заданию 2
    internal class Task2
    {
        // коллекция фигур
        private Figure[] _figures = GenFigures();

        #region Свойства 

        // доступ к полю _figures
        public Figure[] Figures { get => _figures; set => _figures = value; }

        #endregion

        #region Методы 

        #region Формирование коллекции фигур

        // формирование коллекции фигур
        public void FillFigures() => _figures = GenFigures();

        // перечисление фигур
        enum CodeFigure
        {
            // прямоугольник
            RectangleCode,

            // треугольник
            TriangleCode,

            // конус
            ConoidCode,

            // цилиндр
            CylinderCode
        }

        // заполнение массива фигурами по заданию (фабричный метод)
        static private Figure[] GenFigures()
        {
            // массив фигур
            Figure[] figures = new Figure[8];

            // прямоугольники 
            figures[0] = FactoryFigure(CodeFigure.RectangleCode);
            figures[1] = FactoryFigure(CodeFigure.RectangleCode);

            // треугольники
            figures[2] = FactoryFigure(CodeFigure.TriangleCode);
            figures[3] = FactoryFigure(CodeFigure.TriangleCode);

            // конус
            figures[4] = FactoryFigure(CodeFigure.ConoidCode);
            figures[5] = FactoryFigure(CodeFigure.ConoidCode);

            // цилиндр
            figures[6] = FactoryFigure(CodeFigure.CylinderCode);
            figures[7] = FactoryFigure(CodeFigure.CylinderCode);

            return figures;
        }

        // генерация фигур (фабричный метод)
        static private Figure FactoryFigure(CodeFigure code)
        {
            switch (code)
            {
                // прямоугольник            
                case CodeFigure.RectangleCode:
                    return new Rectangle { A = GetDouble(5, 10), B = GetDouble(5, 10) };

                // треугольник
                case CodeFigure.TriangleCode:
                    return CreateTriangle();

                // конус
                case CodeFigure.ConoidCode:
                    return new Conoid { Height = GetDouble(5, 10), Radius = GetDouble(2, 4) };

                // цилиндр
                case CodeFigure.CylinderCode:
                    return new Cylinder { Height = GetDouble(5, 10), Radius = GetDouble(2, 4) };

                default:
                    goto case CodeFigure.RectangleCode;
            }
        }

        // формирование треугольника
        static private Figure CreateTriangle()
        {
            // кортеж данных треугольниика
            (double a, double b, double c) sides = (0d, 0d, 0d);

            // генерация данных
            while (!Triangle.IsTriangle(sides))
                sides = (GetDouble(1,3), GetDouble(1, 3), GetDouble(1, 3));

            return new Triangle { Sides = sides };
        }

        #endregion

        #region Выбор фигур с максимальной площадью

        // выбор фигур с максимальной площадью
        public Figure[] SelectMaxArea()
        {
            // максимальная площадь
            double max = MaxArea(_figures);

            // предикатор 
            bool pred(Figure f) => f.GetArea == max;

            // поиск фигур с максимальной площадью
            Figure[] select = Array.FindAll(_figures, pred);

            return select;
        }

        // максимальная площадь 
        private double MaxArea(Figure[] figures)
        {
            // максимальная площадь
            double max = 0;

            // поиск максимальной площади
            foreach (var item in figures)
                if (max < item.GetArea) max = item.GetArea;

            return max;
        }

        #endregion

        #region Выбор фигур с минимальной площадью

        // выбор фигур с минимальной площадью
        public Figure[] SelectMinArea()
        {
            // минимальная площадь
            double min = MinArea(_figures);

            // предикатор 
            bool pred(Figure f) => f.GetArea == min;

            // поиск фигур с минимальной площадью
            Figure[] select = Array.FindAll(_figures, pred);

            return select;
        }

        // минимальная площадь
        private double MinArea(Figure[] figures)
        {
            // минимальная площадь
            double min = figures[0].GetArea;

            // поиск минимальной площади
            foreach (var item in figures)
                if (min > item.GetArea) min = item.GetArea;

            return min;
        }

        #endregion

        #region Сортировка по убыванию площади

        // сортировка по убыванию площади
        public void SortByArea()
        {
            // компаратор
            int Compare(Figure f1, Figure f2) => f2.GetArea.CompareTo(f1.GetArea);

            // сортровка 
            Array.Sort(_figures, Compare);
        }

        #endregion

        #region Вывод фигур в таблицу

        // вывод фигур в таблицу
        public void ShowTable(string name = "Фигуры", string info = "Исходные данные") => Figure.ShowTable(_figures, name, info);

        #endregion 

        #endregion

    }
}
