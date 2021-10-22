using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReadWrite
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 14.10.2021 - запись в текстовый файл, запись в текстовый файл";

            // Полное имя текстового файла
            string fileName = @"d:\Data\text.txt";

            // Пример записи в текстовый файл
            WriteText(fileName);

            // Пример чтения из текстового файла
            Console.WriteLine($"Чтение из файла {fileName}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            ReadText(fileName);
        } // Main


        // Использование класса StreamWriter для записи текстовых файлов
        private static void WriteText(string fileName) {
            string str;
            StringBuilder sb = new StringBuilder();

            // using(ресурс) { операторы }  IDisposable --> Close()  Dispose()
            // второй параметр - добавление строк в конец файла
            // StreamWriter sw = new StreamWriter(fileName, true, Encoding.Default); 
            using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                while (true) {
                    Console.Write("вводите строку (exit - выход)> ");
                    str = Console.ReadLine();
                    if (str == "exit") break;

                    // запись строки в файл
                    sw.WriteLine(str);
                    sb.Append(str).Append("\n");
                    // sw.Flush();
                } // while
            } // using
            // sw.Close();

            File.WriteAllText(fileName + "_", sb.ToString(), Encoding.UTF8);
        } // StreamWriterDemo


        // Пример чтения из текстового файла
        private static void ReadText(string fileName) {
            // Класс StreamReader - чтение из текстовых файлов
            // File.OpenRead(fileName) - возвращает поток для чтения
            // Encoding.Default - кодировка текста в файле - Windows CP1251 (для 
            // русской локали Windows)
            // StreamReader sr = new StreamReader(File.OpenRead(fileName), Encoding.Default);

            using (StreamReader sr = new StreamReader(File.OpenRead(fileName), Encoding.UTF8)) {
                // string str = sr.ReadToEnd();
                // Console.WriteLine(str);

                string str;
                while (!sr.EndOfStream) {
                    // пока не достигнут конец файла
                    str = sr.ReadLine(); // читать строку
                    Console.WriteLine(str);
                } // while
                
            } // using
            // sr.Close(); // закрыть поток/файл ввода

            /*
            string[] text = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (var line in text) {
                Console.WriteLine(line);
            }
            */

            /*
            string text1 = File.ReadAllText(fileName, Encoding.UTF8);
            Console.WriteLine(text1);
            */
        } // ReadText

        void func(ref int a, params int[] ps)
        {
            a = 12;
        }

    }
}
