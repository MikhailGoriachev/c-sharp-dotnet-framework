using System;
using System.Linq;

namespace PartialTypes
{
    public partial class Person
    {
        public int Age { get; set; }

        public void Logout() {
            Console.WriteLine($"Пользователь {Name} выходит из системы");
        } // Logout

        // пароль пользователя
        private string _password;
        public string Password {
            private get { return _password; }
            set { _password = value; }
        } // Password

        // определение частичного метода - частичный метод всегда private
        partial void CipherPassword() {
            Console.WriteLine($"Шифрую пароль пользователя {_password}");

            // алгоритм "шифрования": http://www.nookery.ru/how-to-encrypt-and-decrypt-data/
            var ch = _password.ToArray(); //преобразуем строку в символы
            short secretKey = 10101;
            _password = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var c in ch)  //выбираем каждый элемент из массива символов нашей строки
                //производим шифрование каждого отдельного элемента и сохраняем его в строку
                _password += (char)(c ^ secretKey);  
            
            Console.WriteLine($"Зашифрованный пароль: {_password}");
        } // CipherPassword
    } // class Person
}