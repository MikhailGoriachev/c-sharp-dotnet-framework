using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        

        static void Main(string[] args) {
            Console.Title = "Занятие 09.09.2021 - массивы в C#";
            /*
            // Массив в C# - объект класса System.Array
            // тип[] имяМассива;
            int n = 5;
            double[] xarr;         // создание ссылки 
            xarr = new double [n]; // выделение памяти, создание массива
            Console.WriteLine($"{xarr}"); // вывод только типа элементов массива
            // этот конкретный экземпляр использовать не будем
            
            
            // пересоздание массива с инициализацией
            // xarr = new double[11] {2d, 6d, 7d, 2d, 6d, 7d, 2d, 6d, 7d, 10, 11}; 
            xarr = new [] { 2d, 6d, 7d, 2d, 6d, 7d, 2d, 6d, 7d, 10, 11 }; 

            // Неявно типизированный массив
            // var - тип определяется компилятором
            // тип элементов double - по самому широкому типу в списке инициализации
            var arr = new [] { 3.3d, 2, 1f, Bar(), Foo(), -1 };  
            Show("\nМассив заполнен при инициализации:\n", arr);
            
            // Пример статических методов класса System.Array
            // Увеличить размер массива до 8
            // Пример передачи по ссылке - ref - параметр является и входным и выходным
            // т.е. он может изменяться в методе
            Array.Resize(ref arr, 8);

            // заполнение массива случайными числами
            Fill(arr, -50d, 50d);

            // выведем этот массив
            Show("\nМассив заполнен случайными числами:\n", arr);
            
            Array.Resize(ref arr, 5);
            Show($"\nМассив сокращен до {arr.Length} элем.\n", arr);

            Console.WriteLine("\n----------------------------------------------------------\n");
            
            #region Сортировка массивов, локальные методы, краткая форма записи методов
            // Пример статических методов класса System.Array
            Array.Sort(arr);
            Show("\nМассив отсортирован по возрастанию:\n", arr);
            
            // сортировка с использованием метода-компаратора
            // правило компаратора:
            // item2 <  item1 - возвращает < 0
            // item2 == item1 - возвращает   0 
            // item2 >  item1 - возвращает > 0 
            Array.Sort(arr, CompareTo);
            Show("\nМассив отсортирован по убыванию:\n", arr);
            
            // сортировка при помощи локального метода
            // int Ascend(double x, double y) { return x.CompareTo(y); }
            int Ascend(double x, double y) => x.CompareTo(y); 

            Array.Sort(arr, Ascend);
            Show("\nМассив отсортирован по возрастанию:\n", arr);

            // краткая форма записи метода
            int Descend(double x, double y) => y.CompareTo(x);

            Array.Sort(arr, Descend);
            Show("\nМассив отсортирован по убыванию:\n", arr);
            
            // сортировка отрицательные впереди
            int SpecialComparator(double x, double y) =>
                x < 0 && y >= 0 ? -1 : x >= 0 && y < 0 ? 1 : 0;
            Array.Sort(arr, SpecialComparator);
            Show("\nМассив отсортирован по правилу \"Отрицательные впереди\":\n", arr);
            
            // сортировка с использованием компаратора в виде лямбда-выражения
            // Array.Sort(arr, (item1, item2) => (item1 > item2?-1:item1 < item2?1:0));
            // Show("\nМассив отсортирован по убыванию:\n", arr);
            // Array.Sort(arr, (item1, item2) => -item1.CompareTo(item2));

            Console.WriteLine("\n----------------------------------------------------------\n");
            
            // var y = new[] { true, true, false };
            // Массив объектов - так можно, но сложно 
            Console.WriteLine("\nМассив объектов:");
            // object[] r = new object[] { 1, "два", true, -3.6};
            object[] r = { 1, "два", true, -3.6};
            foreach(var obj in r) {
                Console.WriteLine($"{obj.GetType()} {obj}");
            } // foreach
            
            #endregion
            */

            

            #region Прямоугольные массивы
            Console.WriteLine("\n\nПрямоугольные массивы");
            // Прямоугольные массивы (2D)
            // тип [,] имяМассива = new тип [строки, столбцы];
            Console.WriteLine();
            int[,] matr = new int[3, 5];  // 3 строки, 5 столбцов
            
            // многомерные массивы
            //int[,,] cube = new int[3, 5, 7];  // 3 строки, 5 столбцов, 7 плоскостей
            //Console.WriteLine(cube);
            
            Fill(matr, -10, 10);
            Show("\nПрямоугольный массив:\n", matr);
            #endregion

            #region Зубчатые массивы
            // Зубчатый массив
            Console.WriteLine("\nЗубчатый массив");
            int[][] u = new int[3][];

            // создание кодом
            for(int i = 0; i < u.Length; ++i)
                u[i] = new int[5 + i];

            // u.Length - количество подмассивов (строк)
            Fill(u, 200, 300);

            // Вывод массива
            Show("\nЗубчатый массив 1\n", u);


            // создание инициализацией 
            u = new [] {new int[5], new int[2], new int[6]};
            Fill(u, 500, 800);
            Show("\nЗубчатый массив 2\n", u);
            #endregion
       
        } // Main

        // пример реализации для сортировки по убыванию
        // правило компаратора для сортировки по убыванию
        // x >  y : -1
        // x == y :  0
        // x <  y :  1
        private static int CompareTo(double x, double y) {
            return x > y?-1:x < y?1:0;
            // return y.CompareTo(x);
        } // CompareTo


        // Метод вернет значение 100d
        static double Foo() /* => 100d; */
        {
            return 100d;
        } // Foo

        // Метод вернет значение 100f
        static float Bar() => 100f;  
        // {
        //     return 100f;
        // } // Bar

        // передача массива в метод

        #region Одномерный массив
        // заполнение массив случайными числами
        private static void Fill(double[] arr, double lo, double hi) {
            for (int i = 0; i < arr.Length; i++) {
                arr[i] = lo + (hi - lo) * rand.NextDouble();
            } // for i
        } // Fill

        // вывод массива в консоль
        private static void Show(string title, double[] arr) {
            Console.Write(title);
            // цикл обеспечивает доступ только по чтению   
            // foreach (var item in arr) {
            //     // Console.Write("{0, 10:N2}", item);   
            //     Console.Write($"{item, 10:n2}");   
            // } // foreach

            // Вывод массива при помощи метода ForEach() и лямбда-выражения
            // Array.ForEach(arr, item => Console.Write($"{item, 10:n2}"));
            // Array.ForEach(arr, item => Console.Write($"{item, 10:F2}"));

            // Array.ForEach(arr, ShowItem);

            // так тоже можно, но не красиво...
            // Array.ForEach(arr, Console.Write);

            // для использования в методе Show - локальная функция
            // void LocalShowItem(double item) {
            //     Console.Write($"{item,10:F2}");
            // } // LocalShowItem
            // Array.ForEach(arr, LocalShowItem);

            // для использования в методе Show - локальная функция
            // в краткой, лаконичной форме записи, C# 8
            // !! только для функций/методов/конструкторв состоящих из 
            // !! единственного оператора
            void LocalShowItem1(double item) =>
                Console.Write($"{item, 10:f2}");
            Array.ForEach(arr, LocalShowItem1);

            Console.WriteLine();
        } // Show

        // для использования в методе Show
        private static void ShowItem(double item) =>
            Console.Write($"{item, 10:f2}");
         // ShowItem
        #endregion

        #region  Прямоугольный массив
        // заполнение прямоугольного массива
        private static void Fill(int[,] matr, int lo, int hi)
        {
            // matr.GetLength(0) - количество строк
            // matr.GetLength(1) - количество столбцов
            int rows = matr.GetLength(0); // строки
            int cols = matr.GetLength(1); // столбцы
           
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matr[i, j] = rand.Next(lo, hi+1);
        } // Fill


        // вывод прямоугольного массива
        private static void Show(string title, int[,] matr) {
            // Вывод заголовка
            Console.Write(title);

            // получение количества строк и столбцов прямоугольной матрицы
            int rows = matr.GetLength(0);
            int cols = matr.GetLength(1);

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++)
                    Console.Write("{0, 10}", matr[i, j]);
                Console.WriteLine();
            } // for i
        } // Show
        
        #endregion

        #region  Зубчатый массив
        private static void Fill(int[][] matr, int lo, int hi) {
            for (int i = 0; i < matr.Length; i++) 
                for (int j = 0; j < matr[i].Length; j++) 
                    matr[i][j] = rand.Next(lo, hi+1);
        } // Fill

        // вывод зубчатого массива
        private static void Show(string title, int[][] matr) {
            // Вывод заголовка
            Console.Write(title);

            for (int i = 0; i < matr.Length; i++) {
                for (int j = 0; j < matr[i].Length; j++)
                    Console.Write($"{matr[i][j], 10}");
                Console.WriteLine();
            } // for i
        } // Show

        #endregion

        private static Random rand = new Random();
    } // class Program
} // namespace Arrays
