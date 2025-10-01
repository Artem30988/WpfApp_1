using System;
using System.IO;

namespace LibMas
{
    public class MatrixOperations
    {
        /// <summary>
        /// Заполнение матрицы случайными значениями
        /// </summary>
        public static void FillMatrix(int[,] matrix, int min, int max)
        {
            Random rnd = new Random();
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rnd.Next(min, max + 1);
                }
            }
        }

        /// <summary>
        /// Создание пустой матрицы (все элементы = 0)
        /// </summary>
        public static int[,] CreateEmptyMatrix(int rows, int cols)
        {
            return new int[rows, cols];
        }

        /// <summary>
        /// Очистка матрицы - возвращает новую пустую матрицу
        /// </summary>
        public static int[,] ClearMatrix(int rows, int cols)
        {
            return new int[rows, cols];
        }

        /// <summary>
        /// Сохранение матрицы в файл
        /// </summary>
        public static void SaveMatrix(int[,] matrix, string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);

                writer.WriteLine(rows);
                writer.WriteLine(cols);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        writer.WriteLine(matrix[i, j]);
                    }
                }
            }
        }

        /// <summary>
        /// Загрузка матрицы из файла
        /// </summary>
        public static int[,] LoadMatrix(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                int rows = int.Parse(reader.ReadLine());
                int cols = int.Parse(reader.ReadLine());

                int[,] matrix = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = int.Parse(reader.ReadLine());
                    }
                }

                return matrix;
            }
        }

    }
}