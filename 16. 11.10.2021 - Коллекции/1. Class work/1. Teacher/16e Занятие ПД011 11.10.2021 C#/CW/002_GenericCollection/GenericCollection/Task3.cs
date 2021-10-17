using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GenericCollection
{
    /* 
    Задача 3. 
    Даны две непустые очереди целых случайных чисел. Перемещать элементы из 
    начала первой очереди в конец второй, пока значение начального элемента 
    первой очереди не станет четным (если первая очередь не содержит четных 
    элементов, то переместить из первой очереди во вторую все элементы). 
    */
    class Task3
    {
        public Queue<int> Queue1 { get; set; }
        public Queue<int> Queue2 { get; set; }

        // исходные размеры очередей
        private int _size1;
        private int _size2;

        public Task3(): this (7, 10) { }
        public Task3(int size1, int size2) {
            _size1 = size1;
            _size2 = size2;

            Regenerate();
        } // Task3


        /// <summary>
        /// Создание очередей для обработки с тем же размером, но новым содержимым
        /// </summary>
        public void Regenerate() {
            Queue1 = Utils.CreateQueue(_size1, -10, 10);
            Queue2 = Utils.CreateQueue(_size2, -10, 10);
        } // Regenerate


        // Перемещать элементы из начала первой очереди в конец второй, 
        // пока значение начального элемента первой очереди не станет 
        // четным (если первая очередь не содержит четных элементов, 
        // то переместить из первой очереди во вторую все элементы)
        public int Solve() {
            int counter = 0;
            // пока первая очередь не пустая и в начале очереди
            // находится нечетный элемент - удалить из первой очереди
            // и поставить в конец второй очереди
            while(Queue1.Count > 0 && (Queue1.Peek() & 1) != 0) {
                int temp = Queue1.Dequeue();
                Queue2.Enqueue(temp);
                counter++;
            } // while

            return counter;
        } // Solve
    } // class Task3
}
