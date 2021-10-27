using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBinReadWrite.Models
{
    // Описание велосипедного туристического маршрута,
    // содержащее следующие свойства:
    //     o название начального пункта маршрута;
    //     o название конечного пункта маршрута;
    //     o протяженность маршрута, в км;
    //     o фамилия и инициалы старшего по маршруту;
    class Route
    {
        // строковые поля одинаковой длины
        private const int LenField =  40;

        // название начального пункта маршрута;
        private string _start;
        public string Start {
            get => _start;
            set => _start = value;
        } // Start

        // название конечного пункта маршрута;
        private string _end;
        public string End {
            get => _end;
            set => _end = value;
        } // End

        // протяженность маршрута, в км;
        private int _length;
        public int Length {
            get => _length;
            set => _length = value;
        } // Length

        // фамилия и инициалы старшего по маршруту;
        private string _principal;
        public string Principal {
            get => _principal;
            set => _principal = value;
        } // Principal

        // размер записи файла
        public static int LenRecord => sizeof(int) + 3 * LenField;

        // запись в бинарный файл
        public void Write(BinaryWriter bwr) {
            bwr.Write(Utils.ToArray(_start, LenField));
            bwr.Write(Utils.ToArray(_end, LenField));
            bwr.Write(_length);
            bwr.Write(Utils.ToArray(_principal, LenField));
        } // Write

        // чтение из бинарного файла
        public void Read(BinaryReader brd) {
            _start = Encoding.UTF8
                .GetString(brd.ReadBytes(LenField))
                .Replace("\0", "")
                .TrimEnd();

            _end = Encoding.UTF8
                .GetString(brd.ReadBytes(LenField))
                .Replace("\0", "")
                .TrimEnd();

            _length = brd.ReadInt32();

            _principal = Encoding.UTF8
                .GetString(brd.ReadBytes(LenField))
                .Replace("\0", "")
                .TrimEnd();
        } // Read

        // вывод данных о маршруте в формате строки таблицы
        public string ToTableRow() =>
            $"│ {_start,-16} │ {_end,-16} │ {_length, 17} │ {_principal,-15 } │";

        public static string Head =>
            "\t┌──────────────────┬──────────────────┬───────────────────┬─────────────────┐\n" +
            "\t│ Начало маршрута  │ Конец маршрута   │ Проятженность, км │ Ответственный   │\n" +
            "\t├──────────────────┼──────────────────┼───────────────────┼─────────────────┤";

        public static string Bottom =>
            "\t└──────────────────┴──────────────────┴───────────────────┴─────────────────┘";
    } // class Route
}
