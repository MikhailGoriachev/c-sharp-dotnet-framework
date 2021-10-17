using System;

// Структуры. 

// Пример плохого дизайна. Свойства без конструкторов

namespace Structure
{
    struct ZipCode
    {
        // Поля и свойства
        int _fiveDigitCode;
        public int FiveDigitCode
        {
            get => _fiveDigitCode;
            set => _fiveDigitCode = value;
        }

        int _plusFourExtension;
        public int PlusFourExtension
        {
            get => _plusFourExtension;
            set => _plusFourExtension = value;
        }
    } // struct ZipCode

    class Program
    {
        static void Main() {
            Console.Title = "Занятие 15.11.2020 - структуры";
            ZipCode zipCode = new ZipCode();

            zipCode.FiveDigitCode = 12345;
            zipCode.PlusFourExtension = 1234;

            Console.WriteLine(zipCode.FiveDigitCode);
            Console.WriteLine(zipCode.PlusFourExtension);

            //современное исправление
            ZipCode code1 = new ZipCode {FiveDigitCode = 12345, PlusFourExtension = 3456};
            Console.WriteLine($"{code1.FiveDigitCode}-{code1.PlusFourExtension}");
        } // Main
    } // class Program
}
