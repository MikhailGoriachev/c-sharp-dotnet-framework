using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableDemo
{
    // коллекция с реализацией интерфейса IEnumerable
    // вообще-то это не обязательно должна быть коллекция
    // реализация интерфейса IEnumerable может быть для любого класса
    class Group: IEnumerable
    {
        // коллекция данных
        private User[] _users;

        public Group() {
            // Начальное заполнение массива - контейнера данных
            _users = new [] {
                new User { Name = "Васильева Н.Р.",   Age = 22, Salary = 15_800},
                new User { Name = "Малиновская Т.Р.", Age = 21, Salary = 16_800},
                new User { Name = "Швайко О.Н.",      Age = 19, Salary = 17_800},
                new User { Name = "Юрчихин К.Н.",     Age = 22, Salary = 16_800},
                new User { Name = "Политыкин Р.О.",   Age = 27, Salary = 98_800},
                new User { Name = "Парамонова А.П.",  Age = 23, Salary = 15_800}
            };
        } // Group

        // индексатор
        public User this[int index] {
            get => _users[ValidateIndex(index)];
            set => _users[ValidateIndex(index)] = value;
        } // indexer

        public int Length => _users.Length;

        // Проверка индекса на допустимость, всегда возвращаем
        // корректный индекс: 0 если index < 0 и users.Length-1
        // если index >= users.Length 
        // Не меняем значения index, если index в допустимом диапазоне
        private int ValidateIndex(int index) =>
            (index < 0)?0: (index >= _users.Length)? _users.Length - 1:index;

        public override string ToString() {
            StringBuilder sb = new StringBuilder("");

            foreach (var user in _users) {  // !!! Внимание !!! для массива
                sb.Append($"{user}\n");     // !!! работает цикл foreach
            } // foreach

            return sb.ToString();
        } // ToString

        
        // Итератор - в C# это реализация интерфейса IEnumerable

        // Первый вариант итератора - "нечестный", читерский вариант 
        // Т.к. массив реализует интерфейс IEnumrable и нам надо
        // перебирать элементы массива (т.е. нужен итератор по массиву),
        // то вернем в качестве итератора коллекции итератор массива
        // Этот IEnumerator - итератор и будет обеспечивать работу foreach  
        // public IEnumerator GetEnumerator() => _users.GetEnumerator();

        
        // Состав интерфейса IEnumerator
        // void Reset()    -- перемещение в начало контейнера
        // bool MoveNext() -- перемещение на одну позицию вперед
        // object Current { get; }  -- текущий элемент в контейнере
        
        // Второй вариант получения итератора - "честная" реализация итератора
        public IEnumerator GetEnumerator() {
            // Оператор yield return выражение;
            // При работе foreach() запоминает позицию в массиве (коллекции) и
            // возвращает значение из этой позиции
            // При повторном обращении к коллекции через foreach - возвращает
            // следующий элемент и запоминает новую позицию в коллекции...
            for (int i = 0; i < _users.Length; i++) {
                // прерывание работы итератора
                if (i == 2) yield break;
                
                // визуально то же поведение, но потенциально - проблема 
                // if (i == 2) break;
            
                // реализация итератора 
                yield return _users[i];
            } // for i

            // Если цикл не реализуется, возможно линейное размещение yield return
            // yield return _users[4];
            // yield return _users[0];
            // yield return _users[2];
            // yield return _users[1];
            // yield return _users[3];
            // yield return _users[4];
        } // GetEnumerator
        
        
        // Именованный итератор - любой метод, возвращающий объект интерфейса IEnumerable
        // пример - именованный итератор, перебирающий заданное количество объектов
        // с начала коллекции
        public IEnumerable First(int number) {
            for (int i = 0; i < number; i++) {
                if (i >= _users.Length) {
                    Console.WriteLine(
                        $"Все элементы выведены. В коллекции элементов: {_users.Length}," +
                        $" запрошено записей: {number}");
                    yield break;  // прекращение работы итератора
                } // if
                
                yield return _users[i];
            } // for
        } // GetUser
        
        
        // Еще один именованный итератор, возвращает только тех пользователей,
        // возраст которых больше заданного
        public IEnumerable GetAgeGrather(int boundAge) {
            foreach (var user in _users) {
                if (user.Age > boundAge) yield return user;
            } // foreach
        } // GetAgeGrather

        // Еще один именованный итератор, возвращает только тех пользователей,
        // оклад которых в заданном диапазоне
        public IEnumerable SalaryBetween(int lo, int hi) {
            foreach (var user in _users) {
                if (lo <= user.Salary && user.Salary <= hi) yield return user;
            } // foreach
        } // SalaryBetween
    } // class Group
}
