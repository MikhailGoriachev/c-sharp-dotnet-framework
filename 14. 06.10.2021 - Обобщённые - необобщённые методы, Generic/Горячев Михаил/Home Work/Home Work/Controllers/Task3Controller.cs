using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Home_work.Application.App.Utils;               // для использования утилит

using Home_Work.Models;        // подключение моделей

namespace Home_Work.Controllers
{
    // Класс Обработка по заданию
    internal class Task3Controller
    {
        // массив 
        public StorageArray<Person> Data { get; set; } = new StorageArray<Person>();

        #region Конструкторы 

        // конструктор по умолчанию
        public Task3Controller()
        {
            // установка значений
            Initialization();
        }

        #endregion

        #region Методы 

        #region Инициализация массива

        // инициализация массива 
        public void Initialization() => Data.Initialization(() => FactoryMethodPerson());

        // фабричный метод для создания персоны
        private Person FactoryMethodPerson()
        {
            // фамилии и ициниалы
            string[] names = new string[]
            {
                "Леонов Д. М.",
                "Владимирова Ф. Б.",
                "Галкин А. М.",
                "Николаев В. М.",
                "Иванов К. Т.",
                "Федотова П. С.",
                "Елисеев З. К.",
                "Новикова Е. А.",
                "Лавров В. Д.",
                "Березин М. В."
            };

            return new Person { Name = names[rand.Next(0, names.Length)], Age = rand.Next(10, 40), Salary = rand.Next(10, 80) * 100 };
        }

        #endregion

        #region Вывод массива

        // вывод масссива 
        public void Show(string name = "Массив", string info = "Исходные данные") => Data.Show(Person.ShowHead, Person.ShowElements);

        // вывод масссива 
        public void ShowColorElements(Predicate<Person> predicate, string name = "Массив", string info = "Исходные данные") => Data.ShowColorElem(Person.ShowHead, Person.ShowColorElements, predicate);

        #endregion

        #region Количество минимальных элементов 

        // количество минимальных элементов
        public int CountMaxElements() => Data.CountMaxElem();

        // вывод массива с подсветкой максимальных элементов 
        public void ShowColorMaxElem(Person max, string name = "Массив", string info = "Исходные данные") => Data.ShowColorElem(Person.ShowHead, Person.ShowColorElements, item => item.Salary.Equals(max.Salary));

        #endregion

        #region Сортировка 

        // сортировка 
        public void Sort() => Data.Sort((item1, item2) => item1.Compare(item2, item1));

        #endregion

        #endregion

    }
}
