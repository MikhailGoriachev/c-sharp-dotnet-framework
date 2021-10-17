using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    // Делегат - еще один вид объекта, способного хранить одну или 
    // несколько ссылок на методы.
    // Методы должны иметь одинаковую сигнатуру

    // Объявление делегата, хранящего ссылку на метод
    // с типом возвращаемого значения void, метод без 
    // параметров
    public delegate void DelegateName();   // например ссылки на методы: void foo() {}   void bar() {}
    // синтаксис
    // доступ delegate ТипВозврЗначения ИмяДелегата(списокПараметров);

    // делегаты наследуются от System.MulticastDelegat <-- System.Delegat

    // Объявление делегата, хранящего ссылку на метод
    // с типом возвращаемого значения int, метод
    // ожидает два параметра int
    public delegate int OperationDelegate(int a, int b); // int Add(int x, int z)   int Mpy(int u, int v)

    class Program {
        static void Main(string[] args) {
            Console.Title = "Занятие 04.10.2021 - введение в делегаты";

            // IntroDelegates();
            ArrayProc();
        } // Main

        // первый набор примеров использования делегатов
        private static void IntroDelegates() {
            Console.WriteLine("Старый синтаксис создания делегата:");

            // ТипДелегата имя = new ТипДелегата(имяМетода)
            // получение ссылки на метод Foo()
            DelegateName dlg1 = new DelegateName(Foo);  // устаревший синтаксис
            dlg1();  // вызов метода через делегат

            // еще один пример устаревшего синтаксиса создания делегата,
            // делегат метода Bar
            dlg1 = new DelegateName(Bar);
            dlg1();  // Bar()
            dlg1.Invoke();  // синхронный вызов метода, на который ссылается делегат

            
            // Современный синтаксис - страшное название "групповое преобразование методов"
            // но очень простой синтаксис
            Console.WriteLine("\nНовый синтаксис создания делегата:");
            DelegateName dlg2 = Foo;  // создание делегата без ключевого слова new!!!
            dlg2();

            dlg2 = Bar;
            dlg2();
            dlg2.Invoke();

            
            // Групповой вызов методов при помощи делегатов
            Console.WriteLine("\nГрупповой вызов методов:");
            DelegateName dlg3 = Bar;
            dlg3 += Foo; // перегрузка операции + для делегатов 
            dlg3 += Bar;
            dlg3 += Foo;
            dlg3();      // отработает такая цепочка делегатов: Bar(); Foo(); Bar(); Foo()
            Console.WriteLine();
            dlg3.Invoke();

            
            // удаление делегатов из цепочки - перегруженная операция -
            Console.WriteLine("\nУдаление методов (последнее вхождение Foo удалено):");
            dlg3 -= Foo;  // удаление - с конца цепочки методов!!!
            dlg3();       // Bar(); Foo(); Bar();

            
            Console.WriteLine("\nВызов метода объекта");
            DemoOperation obj = new DemoOperation();    // создать объект класса DemoOperation

            // Создание делегата для методов класса DemoOperation
            OperationDelegate oper1 = obj.Add;
            int t = oper1(3, 5);
            Console.WriteLine($"Add: {t}");

            // локальная функция тоже совмстима с делегатом
            int Xyz(int tt, int uu) => tt + uu + 1000;

            oper1 += obj.Sub;  // Add -> Sub
            oper1 += obj.Mpy;  // Add -> Sub -> Mpy
            oper1 += Xyz;      // Add -> Sub -> Mpy -> Xyz
            t = oper1(-3, -5);
            Console.WriteLine($"Add -> Sub -> Mpy -> Xyz: {t}");
            
            // уберем Xyz из цепочки вызовов
            oper1 -= Xyz;

            // пример вызова метода делегата при помощи Invoke()
            t = oper1.Invoke(4, 6);  // исполнение цепочки методов
            Console.WriteLine($"Add -> Sub -> Mpy: {t}");
            
        } // IntroDelegates


        // Метод, сигнатура которого соответствует делегату DelegateName
        static void Foo() { Console.WriteLine("Foo: работает"); } // Foo

        // Метод, сигнатура которого соответствует делегату DelegateName
        static void Bar() => Console.WriteLine("Bar: работает");  // Bar

        // демо передачи ссылки на метод как параметр метода
        private static void ArrayProc() {
            int[] ar1 = { 2, 5, 6, 2, 3, 1 };
            int[] ar2 = { 6, 1, 4, 1, 7, 8 };

            // класс, содержащицй методы Add. Sub, Mpy, Div
            DemoOperation oper = new DemoOperation();

            Show(ar1, "ar1: ");
            Show(ar2, "ar2: ");
            Proc(ar1, ar2, oper.Add);   // передача метода в другой метод ar1 = ar1 + ar2
            Show(ar1, "add: ");
            Console.WriteLine();

            Show(ar1, "ar1: ");
            Show(ar2, "ar2: ");
            Proc(ar1, ar2, oper.Sub);   // передача метода в другой метод
            Show(ar1, "sub: ");
            Console.WriteLine();

            Show(ar1, "ar1: ");
            Show(ar2, "ar2: ");
            Proc(ar1, ar2, oper.Mpy);  // передача метода в другой метод
            Show(ar1, "mpy: ");

            Console.WriteLine();
            Show(ar1, "ar1: ");
            Show(ar2, "ar2: ");
            Proc(ar1, ar2, oper.Div);  // передача метода в другой метод
            Show(ar1, "div: ");
        } // ArrayProc


        // Вывод массива
        private static void Show(int[] ar1, string title) {
            Console.Write(title);
            foreach (var item in ar1) Console.Write($"{item,5}");
            Console.WriteLine();
        } // Show


        // Метод для поэлементной обработки массивов
        // Операция передается через делегат - ссылка на метод
        //                                             int oper(int, int)
        private static void Proc(int[] ar1, int[] ar2, OperationDelegate oper) {
            for (int i = 0; i < ar1.Length; i++) {
                // механика - вызов метода, ссылку на который хранит делегат
                // ar1[i] = oper.Invoke(ar1[i], ar2[i]);
                ar1[i] = oper(ar1[i], ar2[i]);
            } // for i
        } // Proc

        // просто пример делегата
        // public delegate string MyMethod(double d, float f);
        // 
        // просто пример использования делегата в параметрах метода
        // void Zoo(int a, double r, MyMethod myMethod, float x) { }
    } // class Program
}
