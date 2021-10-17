using System;

namespace Indexers
{
    // Класс, представляющий двумерный массив - прямоугольную матрицу
    class MyMatrix
    {
        // прямоугольный массивы
        private int[,] _matrix = new int[3, 3];

        // простейший индексатор, без защиты от выхода за пределы массива
        public int this[int row, int column] {
            get => _matrix[row, column];
            set => _matrix[row, column] = value;
        } // indexer

        // Для удобства вводим еще два свойства - количество строк и столбцов
        public int Rows => _matrix.GetLength(0);
        public int Cols => _matrix.GetLength(1);
    } // class MyMatrix
}
