using Lib_9;
using LibMas;
using Microsoft.Win32;
using pr_1;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_1
{
    public partial class MainWindow : Window
    {
        private int[,] matrix;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtRows.Text, out int rows) && rows > 0 &&
                int.TryParse(txtCols.Text, out int cols) && cols > 0)
            {
                matrix = new int[rows, cols];
                MatrixOperations.FillMatrix(matrix, 1, 10);
                DisplayMatrixInDataGrid();
                txtResult.Text = "";
            }
            else
            {
                MessageBox.Show("Введите корректные размеры матрицы (целые числа > 0)");
            }
        }
        //ieurhgui
        //ygsdgidgv
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // Полностью удаляем матрицу
            matrix = null;

            // Очищаем DataGrid
            dataGrid.ItemsSource = null;

            // Очищаем результат
            txtResult.Text = "";

            MessageBox.Show("Матрица очищена");
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (matrix == null)
            {
                MessageBox.Show("Сначала заполните матрицу");
                return;
            }

            try
            {
                var result = MatrixCalculations.FindRowWithMaxSum(matrix);
                int rowNumber = result.Item1;
                int maxSum = result.Item2;

                txtResult.Text = $"Строка с наибольшей суммой: №{rowNumber}\nМаксимальная сумма: {maxSum}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при вычислении: {ex.Message}");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (matrix == null)
            {
                MessageBox.Show("Нет данных для сохранения. Сначала заполните матрицу.");
                return;
            }

            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Title = "Сохранить матрицу";
                saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveDialog.DefaultExt = ".txt";
                saveDialog.FileName = "matrix.txt";

                if (saveDialog.ShowDialog() == true)
                {
                    MatrixOperations.SaveMatrix(matrix, saveDialog.FileName);
                    MessageBox.Show($"Матрица успешно сохранена в файл: {saveDialog.FileName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Title = "Загрузить матрицу";
                openDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openDialog.DefaultExt = ".txt";

                if (openDialog.ShowDialog() == true)
                {
                    matrix = MatrixOperations.LoadMatrix(openDialog.FileName);
                    txtRows.Text = matrix.GetLength(0).ToString();
                    txtCols.Text = matrix.GetLength(1).ToString();
                    DisplayMatrixInDataGrid();
                    txtResult.Text = "";
                    MessageBox.Show($"Матрица успешно загружена из файла: {openDialog.FileName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке: {ex.Message}");
            }
        }

        private void DisplayMatrixInDataGrid()
        {
            if (matrix == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            DataTable dt = new DataTable();

            for (int j = 0; j < cols; j++)
            {
                dt.Columns.Add($"{j + 1}", typeof(int));
            }

            for (int i = 0; i < rows; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < cols; j++)
                {
                    dr[j] = matrix[i, j];
                }
                dt.Rows.Add(dr);
            }

            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Выйти из программы?", "Подтверждение",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(   
                "Практическая работа №2\n" +
                "Вариант 9\n" +
                "Разработчик: [Пучков Артем]\n" +
                "Группа: [ИСП-31]\n\n" +
                "Найти строку матрицы с наибольшей суммой элементов",
                "О программе");
        }
    }
}
