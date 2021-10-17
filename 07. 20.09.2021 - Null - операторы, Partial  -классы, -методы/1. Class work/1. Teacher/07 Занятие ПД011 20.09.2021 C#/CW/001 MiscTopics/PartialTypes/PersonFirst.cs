using System;

namespace PartialTypes
{
    // одна из частей определения частичного класса
    // partial class ИмяКласса {}
    public partial class Person
    {
        public string Name { get; set; }

        public void Login() {
            Console.WriteLine($"Пользователь {Name} входит в систему");
        } // Login

        public override string ToString() => $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";

        // Частичные классы могут содержать частичные методы. Таким методы также
        // определяются с ключевым словом partial. Причем определение частичного
        // метода без тела метода находится в одном частичном классе, а реализация
        // этого же метода - в другом частичном классе.
        // Частичный метод всегда private
        partial void CipherPassword();

        // использование частичного метода в открытом методе класса
        // конечн, частичный метод можно использовать и в закрытом
        // методе класса и в свойствах (и открытых и закрытых)
        public void SetPassword(string password) {
            Password = password;
            CipherPassword();
        } // SetPassword
    } // class Person
}