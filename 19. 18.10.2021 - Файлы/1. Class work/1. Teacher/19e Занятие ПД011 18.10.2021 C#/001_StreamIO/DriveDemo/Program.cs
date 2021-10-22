using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;         // доступ к устройствам ввода/вывода

namespace DriveDemo
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "14.10.2021 - класс данных по накопителям компьютера";
            string str;

            // Показываем использование основных свойств класса DriveInfo
            // DriveInfo - класс для получения данных о дисках компьютера
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (var di in drives) {
                str = $"Данные по диску {di.Name}\n";
                if (di.IsReady) {
                    str +=
                        $"Общий объем     : {di.TotalSize / 1024 / 1024:n} МБайт\n" +
                        $"Свободно        : {di.TotalFreeSpace / 1024 / 1024:n} МБайт\n" +
                        $"Файловая система: {di.DriveFormat}\n";
                } // if
                str += $"Тип диска       : {di.DriveType}\n" +
                       $"Готов к работе  : {(di.IsReady ? "Готов" : "Не готов")}\n";
                Console.WriteLine(str);
            } // foreach
            Console.WriteLine();

            // информация по конкретному диску
            DriveInfo drive = new DriveInfo("z:");
            str = $"Данные по диску {drive.Name}\n";
            if (drive.IsReady) {
                str +=
                    $"Общий объем     : {drive.TotalSize / 1024 / 1024,8} МБайт\n" +
                    $"Свободно        : {drive.TotalFreeSpace / 1024 / 1024,8} МБайт\n" +
                    $"Файловая система: {drive.DriveFormat}\n";
            } // if

            str += $"Тип диска       : {drive.DriveType}\n" +
                   $"Готов к работе  : {(drive.IsReady ? "Готов" : "Не готов")}\n";
            Console.WriteLine(str);
        } // Main
    } // class Program

}
