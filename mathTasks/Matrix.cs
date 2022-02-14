using System;

namespace mathTasks
{
    public class Matrix
    {
        // ввод размерности
        public int GetMatrixSize()
            => ValueHelper.GetInt("Введи размерность матрицы N - нечетное число от 1 до 99", 1, 99, ValueType.Odd);

        // ввод стартового числа
        public int GetStartNumber()
            => ValueHelper.GetInt("Введи стартовое число X - цифра от 0 до 9", 0, 9, ValueType.All);
        
        // заполнение
        public int[,] Create(int size, int startValue)
        {
            var matrix = new int[size, size];
            var maxNumber = size * size + startValue - 1;

            matrix[(size / 2), size / 2] = startValue; // заполняем центр
            for (var i = 0;
                i < (size / 2);
                i++) //заполняем остальное начиная с левого верхнего угла и закручиваем в центр
            {
                for (var j = i; j < (size - i); j++)
                {
                    matrix[i, j] = maxNumber;
                    maxNumber--;
                }

                for (var j = 1; j < (size - i - i); j++)
                {
                    matrix[(j + i), (size - i) - 1] = maxNumber;
                    maxNumber--;
                }

                for (var j = (size - 2) - i; j >= i; j--)
                {
                    matrix[((size - i) - 1), j] = maxNumber;
                    maxNumber--;
                }

                for (var j = ((size - i) - 2); j > i; j--)
                {
                    matrix[j, i] = maxNumber;
                    maxNumber--;
                }
            }

            return matrix;
        }

        // печать
        public void Print(int size, int[,] matrix)
        {
            Console.WriteLine(); // для красоты отступим от ввода стартового числа
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }

                Console.WriteLine();
            }
        }
    }
}