using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StringToBinFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Utils.Init("20.10.2021 - запись строк в бинарный файл, чтение строк из бинарного файла");

            // длина буфера записи/чтения строки в байтах
            const int lenBufBytes = 160;

            Console.WriteLine("\nЗапись строк в бинарный файл в кодировке CP-1251:");
            using (BinaryWriter bw = new BinaryWriter(File.Create(@"..\..\strings.bin"), Encoding.Default)) {
                string[] strings = {
                    "Строка 1. Ну так, чтобы заметно было",
                    "Строка 2. Чуть подлиннее... это строка такая для записи. Которая еще длиннее. ",
                    "Строка 3. Тут рыбы нет, она на старый кордон ушла"
                };

                // Запись строки - идея в том, что строки произвольной длины
                // перекодируются в массив байтов фиксированной длины, этот
                // массив фиксированной длины и записывается в бинарный файл
                int i = 1;
                foreach (var str in strings) {
                    Console.WriteLine($"Запись строки {i++}: \"{str}\"");
                    byte[] buf = ToArray(str, lenBufBytes);
                    bw.Write(buf);
                } // foreach
            } // using

            // чтение строки - читаем строку из массива байт, создаем строку
            // из этого массива байт, заменяем символ "\0" на пустую строку  
            string fileName = @"..\..\strings.bin";
            Console.WriteLine($"\nЧтение строк из бинарного файла \"{fileName}\":");
            using (BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open), Encoding.Default))
            {
                // чтение из массива байт, формирование
                // строки в заданной кодировке,
                // удаление из строки символов-заполнителей "\0"
                string str = Encoding.Default
                    .GetString(br.ReadBytes(lenBufBytes))
                    .Replace("\0", "")
                    .TrimEnd();
                Console.WriteLine(str);

                str = Encoding.Default
                    .GetString(br.ReadBytes(lenBufBytes))
                    .Replace("\0", "")
                    .TrimEnd();
                Console.WriteLine(str);

                str = Encoding.Default
                    .GetString(br.ReadBytes(lenBufBytes))
                    .Replace("\0", "")
                    .TrimEnd();
                Console.WriteLine(str);
            } // using

            Console.WriteLine("\n\n\n");
        } // Main


        // Подготовка строки к записи в файл - копировать символы
        // строки str в буферный массив байт для вывода
        private static byte[] ToArray(string str, int length) {
            byte[] buf = new byte[length];
            
            Encoding.Default
                .GetBytes(str)
                .CopyTo(buf, 0);

            return buf;
        } // ToArray


    } // class Program
}
