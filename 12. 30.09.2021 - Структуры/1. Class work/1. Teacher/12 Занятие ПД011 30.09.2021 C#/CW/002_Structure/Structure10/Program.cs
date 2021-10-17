using System;

// Структуры. 

// Пример хорошего дизайна. Конструкторы для задания значений полей
// устревший пример, лучше использовать новый объектный синтаксис вместо конструкторв

namespace Structure
{
    struct ZipCode
    {
        // Поля
        int _fiveDigitCode;
        int _plusFourExtension;

        // Конструкторы.
        public ZipCode(int fiveDigitCode, int plusFourExtension)
        {
            this._fiveDigitCode = fiveDigitCode;
            this._plusFourExtension = plusFourExtension;
        }

        public ZipCode(int fiveDigitCode)
            : this(fiveDigitCode, 0)
        {
        }

        // Свойства "только для чтения"
        public int FiveDigitCode => _fiveDigitCode;

        public int PlusFourExtension => _plusFourExtension;
    }

    class Program
    {
        static void Main()
        {
            Console.Title = "Занятие 30.09.2021 - структуры";
            ZipCode zipCode = new ZipCode(12345, 1234);

            Console.WriteLine(zipCode.FiveDigitCode);
            Console.WriteLine(zipCode.PlusFourExtension);
        }
    }
}
