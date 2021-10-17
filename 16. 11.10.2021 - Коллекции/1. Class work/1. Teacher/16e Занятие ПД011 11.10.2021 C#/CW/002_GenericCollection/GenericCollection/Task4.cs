using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    /* 

    Задача 4. 
    Даны две непустые очереди целых случайных чисел. Совет: добавляйте в очереди
    элементы из отсортированных массивов случайных чисел. Элементы каждой из 
    очередей упорядочены по возрастанию (в направлении от начала очереди к концу). 
    Объединить очереди в одну с сохранением упорядоченности элементов.     

    */
    class Task4
    {
        public Queue<int> Queue1 { get; set; }
        public Queue<int> Queue2 { get; set; }
        public Queue<int> Queue3 { get; set; }

        // Начальный размер очередей надол запоминать, т.к.
        // при извлечении элемента, размер очереди уменьшается,
        // а при повторной генерации очереди она должна быть того 
        // же размера
        private int _size1;
        private int _size2;

        public Task4(): this (10, 7) { }
        public Task4(int size1, int size2) {
            _size1 = size1;
            _size2 = size2;

            // Создать две упорядоченные очереди из массивов случайных целых чисел
            // и одну пустую очередь, в которую и будем помещать элементы из
            // первых двух без нарушения упорядоченности итоговой очереди 
            Queue3 = new Queue<int>();  // итоговая очередь
            Regenerate();
        } // Task3


        // Повторная генерация очередей для обработки
        public void Regenerate() {
            Queue1 = Utils.CreateOrderedQueue(_size1, -10, 10);
            Queue2 = Utils.CreateOrderedQueue(_size2, -10, 10);
            Queue3.Clear();
        } // Regenerate


        // Решение поставленной задачи - слияние упорядоченных очередей
        // без потери упорядоченности, параметры нужны только для
        // формального соответствия требованиям обработчикам событий .NET Framework 
        public void Solve() {
            // Рассмотрим, как именно выполняется слияние очередей с сохранением порядка
            //  queue1:  1   3   5
            //  queue2: -2  -1   3   6
            //  queue3:

            //  queue1:  1   3   5
            //  queue2: -1   3   6
            //  queue3: -2

            //  queue1:  1   3   5
            //  queue2:  3   6
            //  queue3: -2  -1

            //  queue1:  3   5
            //  queue2:  3   6
            //  queue3: -2  -1   1

            //  queue1:  3   5
            //  queue2:  6
            //  queue3: -2  -1   3

            //  queue1:  5
            //  queue2:  6
            //  queue3: -2  -1   3    3

            //  queue1:  5
            //  queue2:  6
            //  queue3: -2  -1   3   3

            //  queue1:  
            //  queue2:  6
            //  queue3: -2  -1   3   5  

            //  queue1:  
            //  queue2:  
            //  queue3: -2  -1   3   5   6
            while (Queue1.Count > 0 || Queue2.Count > 0) {
                int temp;
                
                if (Queue1.Count == 0)
                    // Обработка ситуации - в первой очереди нет элементов,
                    // во второй очереди точно есть элементы (это обеспечивается 
                    // условием цикла)
                    temp = Queue2.Dequeue();
                else if (Queue2.Count == 0)
                    // Обработка ситуации - во второй очереди нет элементов
                    // в первой очереди точно есть элементы (это обеспечивается 
                    // условием цикла)
                    temp = Queue1.Dequeue();
                else
                    // Обработка ситуации - в обеих очередях есть элементы  
                    temp = (Queue1.Peek() < Queue2.Peek())?Queue1.Dequeue():Queue2.Dequeue();

                Queue3.Enqueue(temp);
            } // while
        } // Solve
    } // class Task4
}
