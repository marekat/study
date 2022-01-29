using System;

namespace spiralMatrix
{
    class Program
    {
        static void Main()
            /*Входные данные:
            - размер матрицы N, где N - нечетное число от 0 до 99 и вводится пользователем
            - X стартовое число
            - направление (по часовой стрелке или против)
            Задача:
            Написать кодешник который будет генерировать матрицу NxN, так чтобы стартовое число было в центре,
            а остальные элементы заполнялись по спирали с увеличением на единицу*/
        {
            // требования к размерности матрицы
            var borderFromToMatrixDimension = 1;
            var borderUpToMatrixDimension = 99;
            var matrixDimensionMustBeOdd = true;

            // требования к стартовому числу
            var borderFromToStartingNumber = 0;
            var borderUpToStartingNumber = 9;
            var startingNumberMustBeOdd = false;

            var n = InputNumber(true, matrixDimensionMustBeOdd, borderFromToMatrixDimension, borderUpToMatrixDimension);
            var x = InputNumber(false, startingNumberMustBeOdd, borderFromToStartingNumber, borderUpToStartingNumber);
            var matrix = CreateMatrix(n, x);
            PrintMatrix(n, matrix);
        }

        // ввод значения
        private static int InputNumber(bool isMatrixDimension, bool mustBeOdd, int borderFrom, int borderUp)
        {
            var isEven = mustBeOdd ? "нечетное" : "";
            var text = isMatrixDimension ? "размерность матрицы N" : "стартовое число";

            Console.WriteLine("Введи {0} - {1} число от {2} до {3}", text, isEven, borderFrom, borderUp);
            var value = Console.ReadLine();
            return Verification(value, borderFrom, borderUp, mustBeOdd);
        }

        // создание матрицы
        private static int[,] CreateMatrix(int matrixDimension, int startingNumber)
        {
            var matrix = new int[matrixDimension, matrixDimension];
            var maxNumber = matrixDimension * matrixDimension + startingNumber - 1;

            matrix[(matrixDimension / 2), matrixDimension / 2] = startingNumber; // заполняем центр
            for (var i = 0;
                i < (matrixDimension / 2);
                i++) //заполняем остальное начиная с левого верхнего угла и закручиваем в центр
            {
                for (var j = i; j < (matrixDimension - i); j++)
                {
                    matrix[i, j] = maxNumber;
                    maxNumber--;
                }

                for (var j = 1; j < (matrixDimension - i - i); j++)
                {
                    matrix[(j + i), (matrixDimension - i) - 1] = maxNumber;
                    maxNumber--;
                }

                for (var j = (matrixDimension - 2) - i; j >= i; j--)
                {
                    matrix[((matrixDimension - i) - 1), j] = maxNumber;
                    maxNumber--;
                }

                for (var j = ((matrixDimension - i) - 2); j > i; j--)
                {
                    matrix[j, i] = maxNumber;
                    maxNumber--;
                }
            }

            return matrix;
        }

        // печать матрицы
        private static void PrintMatrix(int matrixDimension, int[,] matrix)
        {
            Console.WriteLine(); // для красоты отступим от ввода стартового числа
            for (var i = 0; i < matrixDimension; i++)
            {
                for (var j = 0; j < matrixDimension; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }

                Console.WriteLine();
            }
        }

        private static int Verification(string value, int borderFrom, int borderUp, bool mustBeOdd)
        {
            int valueConverted;
            var success = int.TryParse(value, out valueConverted);
            if (success)
            {
                if ((borderFrom > valueConverted) || (valueConverted > borderUp))
                {
                    Console.WriteLine("Число должно быть в диапазоне ОТ {0} ДО {1}", borderFrom, borderUp);
                    Environment.Exit(0);
                }

                if (mustBeOdd)
                {
                    if (valueConverted % 2 == 0)
                    {
                        Console.WriteLine("Число должно быть НЕЧЕТНЫМ");
                        Environment.Exit(0);
                    }
                }

                return valueConverted;
            }
            else
            {
                Console.WriteLine("Вводить надо цифры");
                Environment.Exit(0);
            }

            throw new InvalidOperationException();
        }
    }
}