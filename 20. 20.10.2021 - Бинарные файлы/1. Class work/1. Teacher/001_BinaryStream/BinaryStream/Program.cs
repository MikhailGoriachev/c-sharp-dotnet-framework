using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace BinaryStream
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 20.10.2021 - бинарные файловые потоки";
            const int length = 20;

            Console.WriteLine("\n\n\tБинарные файлы, доступ из C# кода\n");
            
            // файл для обработки, при каждом запуске
            // создаем новый файл
            string fileName = @"..\..\integers.bin";  // !!! VS only - переход в папку исходного текста !!!
            Console.WriteLine($"\tФормирование файла данных {fileName}");
            File.Delete(fileName);
            CreateAndFill(fileName, length);

            // Демонстрация двух подходов к чтению данных из 
            // бинарного потока
            // исключение по концу потока
            View(fileName, "\n\tЧтение файла, использование исключения EndOfStream");      
            
            // чтение вычисленного количества записей
            Show(fileName, "\n\tЧтение файла по рассчитанному количеству записей");      
            
            // Сортировка в файле
            Sort(fileName);
            Show(fileName, "\n\tСортировка в бинарном файле:");

            Console.Write("\tНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
            
            // Задача File14 из сборника Абрамяна М.Э.
            // Дан файл вещественных чисел. Найти среднее арифметическое его
            // элементов.
            Console.WriteLine("\n\n\t————————————————————————————————————————————————————————\n");
            string fileName14 = "file14.bin";
            File14(fileName14);
            
            Console.Write("\n\n\t");
        } // Main

        
        // Только для демонстрации - "божественный" цикл записи в файл и вывода в консоль
        private static void CreateAndFill(string fileName, int length) {
            // using (BinaryWriter bw = new BinaryWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write))) {
            // using (BinaryWriter bw = new BinaryWriter(new FileStream(fileName, FileMode.Create))) {
            using (BinaryWriter bw = new BinaryWriter(File.Create(fileName))) {

                for (int i = 0; i < length; i++) {
                    int t = Utils.GetRand(-10, 10);
                    Console.ForegroundColor = t < 0? ConsoleColor.Cyan : ConsoleColor.Green;
                    bw.Write(t);               // запись в файл
                    Console.Write($"{t,8}");   // вывод в консоль
                    if ((i + 1) % 10 == 0) Console.WriteLine();
                } // for i
                Console.WriteLine();
                Console.ResetColor();
            } // using
        } // CreateAndFill


        // Чтение данных из двоичного файла - признак конца файла - исключение
        // EndOfStreamException
        private static void View(string fileName, string title) {
            Console.WriteLine(title);
            
            using (BinaryReader br = new BinaryReader(File.OpenRead(fileName))) {
                int i = 0;
                try {
                    while (true) {
                        int t = br.ReadInt32();

                        Console.ForegroundColor = t < 0? ConsoleColor.Cyan : ConsoleColor.Green;
                        Console.Write($"{t,8}");
                        if ((i + 1) % 10 == 0) Console.WriteLine();
                        i++;
                    } // while
                } catch (EndOfStreamException) { }
                Console.WriteLine();
            } // using
            
            Console.ResetColor();
        } // View


        // Чтение данных из двоичного файла - по вычисленному количеству записей
        // (для записей равной длины - ок, для записей разной длины не годится)
        private static void Show(string fileName, string title) {
            Console.WriteLine(title);

            // using (BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read))) {
            // using (BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open))) {
            using (BinaryReader br = new BinaryReader(File.OpenRead(fileName))) {
                // определить длину файла в записях
                FileInfo fi = new FileInfo(fileName);
                int n = (int)fi.Length / sizeof(int);
                
                // работаем с файлом - чтение записей из файла, вывод записей в консоль
                for (int i = 0; i < n; i++) {
                    int t = br.ReadInt32();
                    Console.ForegroundColor = t < 0? ConsoleColor.Cyan : ConsoleColor.Green;
                    Console.Write($"{t, 8}");
                    if ((i + 1) % 10 == 0) Console.WriteLine();
                } // while
                Console.WriteLine();
            } // using

            Console.ResetColor();
        } // Show


        // Сортировка файла целых чисел - для демонстрации
        // позиционирования в файле, доступа к файлу по чтению, по записи
        private static void Sort(string fileName) {
            // Доступ по чтению/записи - через тип FileStream
            // это низкоуровневый класс, который получает доступ к файлу и разрешает
            // высокоуровневым классам доступ к этому файлу, но через свои управлюящие
            // структуры
            // Открыт файл один, а пользователей у него - много
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite)) {
                BinaryReader br = new BinaryReader(fs);  // типизированное чтение
                BinaryWriter bw = new BinaryWriter(fs);  // типизированная запись

                FileInfo fi = new FileInfo(fileName);
                int n = (int)fi.Length / sizeof(int);

                // Банальная пузырьковая сортировка для файла
                // И чтение и запись пользуются одним и тем же указателем
                // файловой позиции от потока fs
                for (int i = 0; i < n; i++) {
                    for (int j = 0; j < n - i - 1; j++) {
                        fs.Seek(j * sizeof(int), SeekOrigin.Begin);
                        int t1 = br.ReadInt32(); // читаем
                        int t2 = br.ReadInt32();

                        if (t2 < t1) {
                            // обмен местами
                            fs.Seek(j * sizeof(int), SeekOrigin.Begin);
                            bw.Write(t2);  // запись в буфер, запись в файл отложена
                            bw.Write(t1);
                            bw.Flush();  // немедленная запись в файл 
                        } // if
                    } // for j
                } // for i

            } // using
        } // Sort

        #region File14
        // Дан файл вещественных чисел. Найти среднее арифметическое его элементов.
        private static void File14(string fileName) {
            Console.WriteLine($"\tFile14. Файл для обработки {fileName}:\n");
            Create14(fileName);
            Show14(fileName);
            double avg = Process14(fileName);

            Console.WriteLine($"\n\tFile14. Среднее арифметическое файла {avg:N3}\n\n\n");
        } // File14

        // обработка файла по заданию
        private static double Process14(string fileName) {
            double avg = 0;
            int n;

            using (BinaryReader br = new BinaryReader(File.OpenRead(fileName))) {
                FileInfo fi = new FileInfo(fileName);
                n = (int)fi.Length / sizeof(double);
                
                for (int i = 0; i < n; i++) {
                    avg += br.ReadDouble();
                } // while
            } // using

            return avg / n;
        } // Process14

        // вывод бинарного файла в консоль, специфично для задачи File14
        private static void Show14(string fileName) {
            using (BinaryReader br = new BinaryReader(File.OpenRead(fileName))) {
                FileInfo fi = new FileInfo(fileName);
                int n = (int)fi.Length / sizeof(double);
                
                for (int i = 0; i < n; i++) {
                    double t = br.ReadDouble();

                    Console.ForegroundColor = t < 0? ConsoleColor.Cyan : ConsoleColor.Green;
                    Console.Write($"{t, 10:N3}");
                    if ((i + 1) % 10 == 0) Console.WriteLine();
                } // while
                Console.WriteLine();
            } // using

            Console.ResetColor();
        } // Show14

        // создание файла для решения задачи File14
        private static void Create14(string fileName) {
            int length = Utils.GetRand(10, 20);

            using (BinaryWriter bw = new BinaryWriter(File.Create(fileName))) {

                for (int i = 0; i < length; i++) {
                    double t = Utils.GetRand(-10d, 10d);
                    bw.Write(t);               // запись в файл
                } // for i
            } // using
        } // Create14
        #endregion
    } // class Program
}
