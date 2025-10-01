using System;

namespace Lib_9
{
    public class MatrixCalculations
    {
        /// <summary>
        /// Находит номер строки с наибольшей суммой элементов и значение суммы
        /// </summary>
        /// <param name="matrix">Исходная матрица</param>
        /// <returns>Кортеж (номер строки, максимальная сумма)</returns>
        public static Tuple<int, int> FindRowWithMaxSum(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int maxSum = int.MinValue;
            int maxRowIndex = -1;

            for (int i = 0; i < rows; i++)
            {
                int rowSum = 0;

                // Вычисляем сумму элементов текущей строки
                for (int j = 0; j < cols; j++)
                {
                    rowSum += matrix[i, j];
                }

                // Проверяем, является ли эта сумма максимальной
                if (rowSum > maxSum)
                {
                    maxSum = rowSum;
                    maxRowIndex = i;
                }
            }

            // Возвращаем номер строки (начиная с 1) и максимальную сумму
            return new Tuple<int, int>(maxRowIndex + 1, maxSum);
        }
    }
}