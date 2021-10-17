using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_work.Models.Task1;       // подключение классов для задания 1

using static Home_work.Application.App.Utils;       // для использования утилит

namespace Home_work.Controllers
{
    // Класс Обработка по заданию 1
    internal class Task1
    {
        // транспортные средства
        Vehicle[] _vehicles = GenData();

        #region Свойства 

        // доступ к полю _vehicles
        public Vehicle[] Vehicles { get => _vehicles; set => _vehicles = value; }

        #endregion

        #region Конструкторы

        // статический конструктор 
        static Task1()
        {
            // шаблонные данные самолётов 
            _planes = new Vehicle[]
            {
                new Plane{ Name = "Boeing 777", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)), Height = rand.Next(2_000,10_000), Passengers = rand.Next(40, 150), Price = rand.Next(1_000_000, 10_000_000), Speed = rand.Next(400, 800), Year = rand.Next(2005, 2020) },
                new Plane{ Name = "Boeing 737", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)), Height = rand.Next(2_000,10_000), Passengers = rand.Next(40, 150), Price = rand.Next(1_000_000, 10_000_000), Speed = rand.Next(400, 800), Year = rand.Next(2005, 2020) },
                new Plane{ Name = "Airbus A350", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)), Height = rand.Next(2_000,10_000), Passengers = rand.Next(40, 150), Price = rand.Next(1_000_000, 10_000_000), Speed = rand.Next(400, 800), Year = rand.Next(2005, 2020) },
                new Plane{ Name = "Airbus А321", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)), Height = rand.Next(2_000,10_000), Passengers = rand.Next(40, 150), Price = rand.Next(1_000_000, 10_000_000), Speed = rand.Next(400, 800), Year = rand.Next(2005, 2020) },
                new Plane{ Name = "SuperJet 100", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)), Height = rand.Next(2_000,10_000), Passengers = rand.Next(40, 150), Price = rand.Next(1_000_000, 10_000_000), Speed = rand.Next(400, 800), Year = rand.Next(2005, 2020) },
            };

            // шаблонные данные кораблей
            _ships = new Vehicle[]
            {
               new Ship{ Name = "MONTMARTRE", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)), Passengers = rand.Next(40, 150), 
                   Price = rand.Next(50_000_000, 80_000_000), Speed = rand.Next(30, 40), Year = rand.Next(2005, 2020), Port = "Порт Шанхая" },

               new Ship{ Name = "JACQUES", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)), Passengers = rand.Next(40, 150), 
                   Price = rand.Next(50_000_000, 80_000_000), Speed = rand.Next(30, 40), Year = rand.Next(2005, 2020), Port = "Порт Сингапура" },

               new Ship{ Name = "SORBONNE", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)), Passengers = rand.Next(40, 150),
                   Price = rand.Next(50_000_000, 80_000_000), Speed = rand.Next(30, 40), Year = rand.Next(2005, 2020), Port = "Порт Тяньцзиня" },

               new Ship{ Name = "ELYSEES", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)), Passengers = rand.Next(40, 150), 
                   Price = rand.Next(50_000_000, 80_000_000), Speed = rand.Next(30, 40), Year = rand.Next(2005, 2020), Port = "Порт Гуанчжоу" }
            };

            // шаблонные данные автомобилей
            _automobiles = new Vehicle[]
            {
                new Car{ Name = "BMW X5", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)), 
                    Price = rand.Next(5_000_000, 10_000_000), Speed = rand.Next(60, 120), Year = rand.Next(2005, 2020) },

                new Car{ Name = "BMW X4", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)),
                    Price = rand.Next(5_000_000, 10_000_000), Speed = rand.Next(60, 120), Year = rand.Next(2005, 2020) },

                new Car{ Name = "Mercedes c63", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)), 
                    Price = rand.Next(5_000_000, 10_000_000), Speed = rand.Next(60, 120), Year = rand.Next(2005, 2020) },

                new Car{ Name = "Mercedes vito", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)), 
                    Price = rand.Next(5_000_000, 10_000_000), Speed = rand.Next(60, 120), Year = rand.Next(2005, 2020) },

                new Car{ Name = "Wolksvagen Golf", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)),
                    Price = rand.Next(5_000_000, 10_000_000), Speed = rand.Next(60, 120), Year = rand.Next(2005, 2020) },

                new Car{ Name = "Wolksvagen Polo", Coord = (GetDouble(-90, 90), GetDouble(-180, 180)), 
                    Price = rand.Next(5_000_000, 10_000_000), Speed = rand.Next(60, 120), Year = rand.Next(2005, 2020) }
            };
        }

        #endregion

        #region Методы

        #region Заполнение массива 

        // заполнение массива
        public void FillData() => _vehicles = GenData();

        // шаблонные данные самолётов 
        static private Vehicle[] _planes;

        // шаблонные данные автомобилей
        static private Vehicle[] _automobiles;

        // шаблонные данные кораблей
        static private Vehicle[] _ships;

        // генерация данных для массива по заданию  (фабричный метод)
        static private Vehicle[] GenData()
        {
            // массив транспортных средств
            Vehicle[] result = new Vehicle[10];

            // самолёты
            result[2] = _planes[rand.Next(0, _planes.Length - 1)];
            result[3] = _planes[rand.Next(0, _planes.Length - 1)];

            // автомобили
            result[4] = _automobiles[rand.Next(0, _planes.Length - 1)];
            result[1] = _automobiles[rand.Next(0, _planes.Length - 1)];
            result[5] = _automobiles[rand.Next(0, _planes.Length - 1)];
            result[6] = _automobiles[rand.Next(0, _planes.Length - 1)];
            result[8] = _automobiles[rand.Next(0, _planes.Length - 1)];

            // корабли
            result[7] = _ships[rand.Next(0, _planes.Length - 1)];
            result[9] = _ships[rand.Next(0, _planes.Length - 1)];
            result[0] = _ships[rand.Next(0, _planes.Length - 1)];

            return result;
        }

        #endregion

        #region Выбор самого медленного транспортного средства

        // выбор самого медленного транспортного средства
        public Vehicle[] SelectSlowest()
        {
            // минимальная скорость
            int min = MinSpeed(_vehicles);

            // предикатор 
            bool pred(Vehicle v) => v.Speed == min;

            // поиск самых медленных транспортных средств в массиве
            Vehicle[] select = Array.FindAll(_vehicles, pred);

            return select;
        }

        // минимальная скорость 
        private int MinSpeed(Vehicle[] vehicles)
        {
            // минимальная скорость
            int min = vehicles[0].Speed;

            // поиск минимальной скорости
            foreach (var item in vehicles)
                if (min > item.Speed) min = item.Speed;

            return min;
        }

        #endregion

        #region Выбор самого быстрого транспортного средства

        // выбор самого быстрого транспортного средства
        public Vehicle[] SelectFastest()
        {
            // максимальная скорость
            int max = MaxSpeed(_vehicles);

            // предикатор 
            bool pred(Vehicle v) => v.Speed == max;

            // поиск самых быстрых транспортных средств в массиве
            Vehicle[] select = Array.FindAll(_vehicles, pred);

            return select;
        }

        // максимальная скорость 
        private int MaxSpeed(Vehicle[] vehicles)
        {
            // максимальная скорость
            int max = 0;

            // поиск максимальной скорости
            foreach (var item in vehicles)
                if (max < item.Speed) max = item.Speed;

            return max;
        }

        #endregion

        #region Выбор самого старого транспортного средства

        // выбор самого старого транспортного средства
        public Vehicle[] SelectOldest()
        {
            // минимальный год выпуска
            int min = MinYear(_vehicles);

            // предикатор 
            bool pred(Vehicle v) => v.Year == min;

            // поиск самых старых транспортных средств в массиве
            Vehicle[] select = Array.FindAll(_vehicles, pred);

            return select;
        }

        // минимальный год выпуска 
        private int MinYear(Vehicle[] vehicles)
        {
            // минимальный год выпуска
            int min = vehicles[0].Year;

            // поиск минимального года выпуска
            foreach (var item in vehicles)
                if (min > item.Year) min = item.Year;

            return min;
        }

        #endregion

        #region Сортировка по убыванию цены

        // сортировка по убыванию цены
        public void SortByPrice()
        {
            // компаратор
            int Compare(Vehicle v1, Vehicle v2) => v2.Price.CompareTo(v1.Price);

            // сортировка 
            Array.Sort(_vehicles, Compare);
        }

        #endregion

        #region Вывод транспортных средств в таблицу

        // вывод транспортных средств в таблицу
        public void ShowTable(string name = "Транспортные средства", string info = "Исходные данные") => Vehicle.ShowTable(_vehicles, name, info);

        #endregion

        #endregion
    }
}
