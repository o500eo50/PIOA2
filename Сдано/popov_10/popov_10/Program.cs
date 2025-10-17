using System;

class Program
{
    static void Main()
    {
        int size;

        // Ввод размерности матрицы с ограничением
        Console.Write("Введите размер квадратной матрицы (не менее 4): ");
        while (!int.TryParse(Console.ReadLine(), out size) || size < 4)
        {
            Console.WriteLine("Ошибка! Размер матрицы должен быть целым числом не меньше 4.");
            Console.Write("Введите размер квадратной матрицы (не менее 4): ");
        }

        // Ввод элементов матрицы
        double[,] matrix = new double[size, size];
        Console.WriteLine("Введите элементы матрицы:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                while (!double.TryParse(Console.ReadLine(), out matrix[i, j]))
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
            }
        }

        // Вычисление определителя
        double determinant = CalculateDeterminant(matrix, size);

        // Вывод результата
        Console.WriteLine("\nМатрица:");
        PrintMatrix(matrix, size);
        Console.WriteLine($"\nОпределитель матрицы = {determinant:F2}");

        Console.ReadKey(true);
    }

    // Метод для вычисления определителя с использованием if/else
    static double CalculateDeterminant(double[,] matrix, int n)
    {
        double det = 0;

        if (n == 1)
        {
            det = matrix[0, 0];
        }
        else
        {
            if (n == 2)
            {
                det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                for (int p = 0; p < n; p++)
                {
                    double[,] subMatrix = new double[n - 1, n - 1];

                    // Формируем подматрицу
                    for (int i = 1; i < n; i++)
                    {
                        int colIndex = 0;
                        for (int j = 0; j < n; j++)
                        {
                            if (j == p) continue;
                            subMatrix[i - 1, colIndex] = matrix[i, j];
                            colIndex++;
                        }
                    }

                    det += matrix[0, p] * Math.Pow(-1, p) * CalculateDeterminant(subMatrix, n - 1);
                }
            }
        }

        return det;
    }

    // Метод для вывода матрицы
    static void PrintMatrix(double[,] matrix, int size)
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write("|");
            for (int j = 0; j < size; j++)
            {
                Console.Write($"{matrix[i, j],8:F2}");
            }
            Console.WriteLine(" |");
        }
    }
}
