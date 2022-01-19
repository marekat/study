using System;

namespace spiralMatrix
{
    class Program
    {
        /*Входные данные:
        - размер матрицы N, где N - нечетное число от 0 до 99 и вводится пользователем
        - X стартовое число
        - направление (по часовой стрелке или против)
        Задача:
        Написать кодешник который будет генерировать матрицу NxN, так чтобы стартовое число было в центре,
        а остальные элементы заполнялись по спирали с увеличением на единицу*/

        static void Main()
        {
            Console.WriteLine("Введи размерность матрицы N - нечетное число от 1 до 99");
            var n = Console.ReadLine();
            var nConverted = Verification(n, true);

            Console.WriteLine("Введи стартовое число X - цифра от 0 до 9");
            var x = Console.ReadLine();
            var xConverted = Verification(x, false);

            var matrix = new int[nConverted, nConverted];
            var maxNumber = nConverted * nConverted + xConverted - 1;

            matrix[(nConverted / 2), nConverted / 2] = xConverted; // заполняем центр
            for (var i = 0;
                i < (nConverted / 2);
                i++) //заполняем остальное начиная с левого верхнего угла и закручиваем в центр
            {
                for (var j = i; j < (nConverted - i); j++)
                {
                    matrix[i, j] = maxNumber;
                    maxNumber--;
                }

                for (var j = 1; j < (nConverted - i - i); j++)
                {
                    matrix[(j + i), (nConverted - i) - 1] = maxNumber;
                    maxNumber--;
                }

                for (var j = (nConverted - 2) - i; j >= i; j--)
                {
                    matrix[((nConverted - i) - 1), j] = maxNumber;
                    maxNumber--;
                }

                for (var j = ((nConverted - i) - 2); j > i; j--)
                {
                    matrix[j, i] = maxNumber;
                    maxNumber--;
                }
            }

            // Выводим массив
            Console.WriteLine(); // для красоты отступим от ввода Х
            for (var i = 0; i < nConverted; i++)
            {
                for (var j = 0; j < nConverted; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }

                Console.WriteLine();
            }
        }

        private static int Verification(string value, bool isN)
        {
            try
            {
                var valueConverted = Convert.ToInt32(value);
                if (isN)
                {
                    if ((valueConverted is < 1 or > 99) || (valueConverted % 2 == 0))
                    {
                        Console.WriteLine("Число должно быть НЕЧЕТНЫМ в диапазоне ОТ 1 ДО 99");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    if (valueConverted is < 0 or > 9)
                    {
                        Console.WriteLine("Число должно быть в диапазоне ОТ 0 ДО 9");
                        Environment.Exit(0);
                    }
                }

                return valueConverted;
            }
            catch (FormatException)
            {
                Console.WriteLine("Только цифры!");
                throw;
            }
        }
    }
}