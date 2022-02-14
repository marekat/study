using System;

namespace mathTasks
{
    class Program
    {
        static void Main()
        {
            Task1();
        }

        /*Задача 1
        Входные данные:
        - размер матрицы N, где N - нечетное число от 0 до 99 и вводится пользователем
        - X стартовое число
        - направление (по часовой стрелке или против)
        Задача:
        Написать кодешник который будет генерировать матрицу NxN, так чтобы стартовое число было в центре,
        а остальные элементы заполнялись по спирали с увеличением на единицу*/
        private static void Task1()
        {
            var size = new Matrix().GetMatrixSize();
            var startValue = new Matrix().GetStartNumber();
            var matrix = new Matrix().Create(size, startValue);
            new Matrix().Print(size, matrix);
        }
    }
}