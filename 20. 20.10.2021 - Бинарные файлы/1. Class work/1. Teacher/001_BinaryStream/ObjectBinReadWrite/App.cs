using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectBinReadWrite.Models;

namespace ObjectBinReadWrite
{
	// класс для работы с коллекцией велосипедных маршрутов
    class App
    {
		// название фирмы, организующей велосипедные экскурсии
        private string _name;
        public string Name {
            get => _name;
            set => _name = value;
        } // Name

        private string _fileName;
        public string FileName {
            get => _fileName;
            set => _fileName = value;
        } // FileName


        private List<Route> _listRoute;

        public App():this("Велопробегайте с нами", @"..\..\Files\routes.bin", new List<Route>()) { } // App
        public App(string name, string fileName, List<Route> listRoute) {
            _name = name;
            _fileName = fileName;
            _listRoute = listRoute;
        } // App

        // создание коллекции записей
        public void Initialize() {
            _listRoute.Clear();
            _listRoute.AddRange(new [] {
                new Route {Start = "Донецк",      End = "Павлополь",   Length = 25, Principal = "Юрченков Б.П."}, 
                new Route {Start = "Старобешево", End = "Павлополь",   Length =  8, Principal = "Мамишов М.Л."}, 
                new Route {Start = "Донецк",      End = "Иловайск",    Length = 34, Principal = "Иванова Т.Е."}, 
                new Route {Start = "Макеевка",    End = "Горловка",    Length = 47, Principal = "Юрченков Б.П."}, 
                new Route {Start = "Широкий",     End = "Павлополь",   Length = 18, Principal = "Мамишов М.Л."}, 
                new Route {Start = "Донецк",      End = "Минеральное", Length = 12, Principal = "Юрченков Б.П."}, 
                new Route {Start = "Иловайск",    End = "Старобешево", Length = 31, Principal = "Иванова Т.Е."}, 
                new Route {Start = "Еленовка",    End = "Амвросиевка", Length = 51, Principal = "мамишов М.Л."}, 
                new Route {Start = "Зугрэс",      End = "Донецк",      Length = 29, Principal = "Юрченков Б.П."}, 
                new Route {Start = "Донецк",      End = "Новый Свет",  Length = 37, Principal = "Иванова Т.Е."}, 
            });
        } // Initialize
        
        // запись коллекции в бинарный файл
        public void WriteToBin() {
            using (var bwr = new BinaryWriter(File.Create(_fileName))) {
                foreach (var route in _listRoute) {
                    route.Write(bwr);
                } // foreach
            } // using
        } // WriteToBin
        
        // вывод бинарного файла в консоль
        public void Show(string title = null) {
            if (title == null)
                title = $"\n\tВелосипедные маршруты \"{Name}\"\n\n";

            Console.Write($"{title}{Route.Head}\n");

            using (var brd = new BinaryReader(File.OpenRead(FileName))) {

                // количество записей в файле
                FileInfo fi = new FileInfo(_fileName);
                int n = (int) fi.Length / Route.LenRecord;

                // чтение из файла и вывод записи в консоль
                Route route = new Route();
                for (int i = 0; i < n; i++) {
                    route.Read(brd);
                    Console.WriteLine($"\t{route.ToTableRow()}");
                } // for i
            } // using

            Console.WriteLine($"{Route.Bottom}\n\n\n");
        } // Show
        
        // сортировка бинарного файла по названиям начального пункта 
        // маршрута методом быстрой сортировки
        public void SortByStartPoint() {
            using (FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.ReadWrite)) {
                FileInfo fi = new FileInfo(_fileName);
                BinaryReader br = new BinaryReader(fs); // типизированное чтение
                BinaryWriter bw = new BinaryWriter(fs); // типизированная запись

                int begin = 0;
                int end = (int)fi.Length / Route.LenRecord - 1;

                Sort(fs, br, bw, begin, end);
            } // using
        } // SortByStartPoint

        // быстрая сортировка по пунктам начала маршрута
        private void Sort(FileStream fs, BinaryReader br, BinaryWriter bw, int begin, int end) {
            if (begin >= end) return;

            int i = begin, j = end;    // для работы алгоритма
            int cur = begin + (end - begin) / 2; // расчет начального индекса середины массива

            // внутренний метод
            Route ReadAt(int pos) {
                fs.Seek(pos * Route.LenRecord, SeekOrigin.Begin);
                Route route = new Route();
                route.Read(br);
                return route;
            } // readAt

            Route value;
            while (i < j) {
                // середина - значение элемента в середине интервала
                value = ReadAt(cur); 
        
                // движение от начала к середине, пока не найдем элемент => середины
                while (i < cur && value.Start.CompareTo(ReadAt(i).Start) >= 0) i++;
        
                // движение от конца к середине, пока не найдем элемент <= середины
                while (j > cur && ReadAt(j).Start.CompareTo(value.Start) >= 0) j--;

                if (i < j) {  // если исследуемый интервал еще не пройден
                    // меняем местами элементы в половинках файла
                    // сначала чтение данных
                    Route routeJ = ReadAt(j);
                    Route routeI = ReadAt(i);

                    // затем запись
                    fs.Seek(i * Route.LenRecord, SeekOrigin.Begin);
                    routeJ.Write(bw);
                    
                    fs.Seek(j * Route.LenRecord, SeekOrigin.Begin);
                    routeI.Write(bw);

                    // гарантированная запись данных
                    bw.Flush();

                    // если слева дошли до середины - нет элементов для обмена
                    // отодвигаем середину вправо, конечно, это уже не середина, но надо продолжать...
                    if (i == cur) cur = j;
                    // если справа дошли до середины - нет элементов для обмена
                    // отодвигаем середину влево
                    else if (j == cur) cur = i;
                } // if
            } // while

            // рекурсивный вызов в новых границах поиска
            Sort(fs, br, bw, begin, cur);       // от начала массива до cur
            Sort(fs, br, bw, cur + 1, end);   // от cur+1 до конца массива
        } // SortDesc
        
        // загрузка файла в коллекцию List<> 
        public void ReadFromBin() {
            using (var brd = new BinaryReader(File.OpenRead(FileName))) {
                _listRoute.Clear();

                // количество записей в файле
                FileInfo fi = new FileInfo(_fileName);
                int n = (int) fi.Length / Route.LenRecord;

                // чтение коллекции из файла
                for (int i = 0; i < n; i++) {
                    Route route = new Route();
                    route.Read(brd);
                    _listRoute.Add(route);
                } // for i
            } // using
        } // ReadFromBin

        // вывод коллекции в консоль
        public void ShowList(string title) {
            Console.Write($"{title}\n{Route.Head}\n");

            foreach (var route in _listRoute) {
                Console.WriteLine($"\t{route.ToTableRow()}");
            } // foreach

            Console.WriteLine($"{Route.Bottom}\n\n\n");
        } // ShowList
    } // class App
}
