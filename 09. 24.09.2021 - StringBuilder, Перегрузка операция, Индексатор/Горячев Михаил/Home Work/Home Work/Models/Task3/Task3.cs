using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Models.Task3
{
    // Класс Обработка по заданию
    internal class Task3
    {
        // объект Shop
        private Shop _shopObj = new Shop("Fox");

        #region Свойства 

        // доступ к полю _shopObj
        public Shop ShopObj { get => _shopObj; set => _shopObj = value; }

        #endregion

        #region Методы 

        // поиск товаров с минимальной стоимостью
        public Product[] FindMinElemPrice(out int minValue)
        {
            // минимальная стоимость
            minValue = _shopObj[0].Price;

            // размер массива элементов с минимальной стоимостью
            int n = 1;

            // поиск минимальной стоимости
            for (int i = 1; i < _shopObj.Length; i++)
            {
                // если текущий элемент меньше текущего минимального значения
                if (minValue > _shopObj[i].Price)
                {
                    // размер массива для элементов с минимальным значением
                    n = 0;

                    // установка текущего минимального значения
                    minValue = _shopObj[i].Price;
                }

                // если элемент является минимальным
                if (_shopObj[i].Price == minValue) n++;
            }

            // массив для минимальных элементов 
            Product[] minProducts = new Product[n];

            // заполнение массива минимальными элементами
            for (int i = 0, k = 0; i < _shopObj.Length; i++)
                if (_shopObj[i].Price == minValue) 
                    minProducts[k++] = _shopObj[i];

            return minProducts;
        }

        // поиск товаров с максимальной стоимостью
        public Product[] FindMaxElemPrice(out int maxValue)
        {
            // минимальная стоимость
            maxValue = 0;

            // размер массива элементов с максимальной стоимостью
            int n = 0;

            // поиск минимальной стоимости
            for (int i = 0; i < _shopObj.Length; i++)
            {
                // если текущий элемент меньше текущего максимального значения
                if (maxValue < _shopObj[i].Price)
                {
                    // размер массива для элементов с максимальным значением
                    n = 0;

                    // установка текущего максимального значения
                    maxValue = _shopObj[i].Price;
                }

                // если элемент является максимальным
                if (_shopObj[i].Price == maxValue) n++;
            }

            // массив для максимальных элементов 
            Product[] maxProducts = new Product[n];

            // заполнение массива максимальными элементами
            for (int i = 0, k = 0; i < _shopObj.Length; i++)
                if (_shopObj[i].Price == maxValue) maxProducts[k++] = _shopObj[i];

            return maxProducts;
        }

        // вывод товаров в консоль в виде таблицы
        public void ShowTableMinMaxPrice(int minPrice, int maxPrice, string info = "Список товаров")
        {
            // вывод шапки таблицы
            Shop.ShowHead(_shopObj.Length, _shopObj.Name, info);

            // вывод элементов 
            ShowElemMinMaxPrice();

            // компаратор
            int Compare(Product prod) => prod.Price == minPrice ? -1 : prod.Price == maxPrice ? 1 : 0;

            // вывод элементов 
            void ShowElemMinMaxPrice()
            {
                // если в массиве нет данных
                if ((_shopObj?.Length ?? 0) == 0)
                    Shop.ShowEmpty();

                else
                {
                    // вывод элементов
                    for (int i = 0; i < _shopObj.Length; i++)
                    {
                        // текущий продукт
                        Product cur = _shopObj[i];

                        // значение компаратора
                        int comp = Compare(cur);
                        
                        // вывод элемента
                        cur.ShowElem(i + 1, flagActive: comp == -1 ? true : comp == 1, activeColor: comp == -1 ? ConsoleColor.Blue : ConsoleColor.DarkRed); 
                    }

                    // вывод подвала таблицы
                    Shop.ShowLine();
                }
            }
        }

        // Сортировка по убыванию количества 
        // (быстрая сортировка)
        public void SortByCount()
        {
            // быстрая сортировка
            QuickSort(_shopObj, 0, _shopObj.Length - 1);

            // метод возвращающий индекс опорного элемента
            int Partition(Shop array, int minIndex, int maxIndex)
            {
                var pivot = minIndex - 1;
                for (var i = minIndex; i < maxIndex; i++)
                {
                    if (array[i].Count < array[maxIndex].Count)
                    {
                        pivot++;
                        (array[pivot], array[i]) = (array[i], array[pivot]);
                    }
                }

                pivot++;
                (array[pivot], array[maxIndex]) = (array[maxIndex], array[pivot]);

                return pivot;
            }

            // быстрая сортировка
            Shop QuickSort(Shop array, int minIndex, int maxIndex)
            {
                if (minIndex >= maxIndex)
                {
                    return array;
                }

                var pivotIndex = Partition(array, minIndex, maxIndex);
                QuickSort(array, minIndex, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, maxIndex);

                return array;
            }                
        }

        // вывод товаров с общей суммой стоимостей
        public void ShowAllSumProduct(int sum, string info = "Исходные данные")
        {
            // вывод товаров
            _shopObj.ShowTable();

            // вывод общей суммы стоимостей товара
            ShowSum(sum);
        }

        // вывод общей суммы стоимостей товара
        private void ShowSum(int sum)
        {
            App.WriteColorXY("          ╔════════════════════════════════════════╦════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);

            App.WriteColorXY("          ║                                        ║            ║            ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"  Сумма   ", 53, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{sum, 10}", 66, textColor: ConsoleColor.Blue);
            Console.WriteLine();
            App.WriteColorXY("          ╚════════════════════════════════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        #endregion
    }
}
