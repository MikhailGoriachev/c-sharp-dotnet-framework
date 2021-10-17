using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;   // для MessageBox() 
using Microsoft.VisualBasic;  // для Interaction

namespace InputOutputGuiDemo
{
    // подключение внешних ссылок, внешних библиотек
    // использование некоторых средств графического интерфейса пользователя
    // использование библиотек других языков
    class Program
    {
        
        static void Main(string[] args) {

            // Вывод средствами WindowsForms, C#
            MessageBox.Show(
                "Текст выводимого сообщения может\nзанимать несколько строк", 
                "MessageBox из WindowsForms",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            // вывод средствами Visual Basic
            Interaction.MsgBox(
                "Использование библиотеки Visual Basic в приложении C#",
                MsgBoxStyle.Information,
                "Interaction.MsgBox() из Visual Basic");

            // вводим целое число
            // использование специального, объектного, типа - string
            string response = Interaction.InputBox(
                "Количество объектов для обработки:",
                "Ввод данных");
            
            // парсинг целого числа из строки
            int a;
            int.TryParse(response, out a);

            Interaction.MsgBox(
                $"Вы попросили создать объектов: {a}\nОбъекты созданы",
                MsgBoxStyle.Information, "Результат");

            // вводим вещественное число
            response = Interaction.InputBox(
                "Вещественное число, длина отрезка в см (разделитель ','):",
                "Ввод данных");

            // парсинг вещественного числа из строки
            // double b;
            // double.TryParse(response, out b);
            double.TryParse(response, out double b);  // новый синтаксис  

            Interaction.MsgBox(
                $"Длина отрезка для обработки: {b:n2} см\nОбработка выполнена",
                MsgBoxStyle.Information, "Результат");
        } // Main
    } // class Program
}
