using System;

class Program
{
    static void Main(string[] args)
    {
        // Переменные
        int n;                 // количество членов ряда (n > 1)
        double c = 0.0;        // сумма ряда
        double fact = 1.0;     // текущее значение факториала (k!)

        // Ввод n с проверкой корректности
        while (true)
        {
            Console.Write("Введите n (целое число, n > 1): ");
            string input = Console.ReadLine();
            bool ok = int.TryParse(input, out n);

            if (ok)
            {
                if (n > 1)
                {
                    // корректное значение, выходим из цикла
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка: n должно быть больше 1. Попробуйте ещё раз.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: введите целое число. Пример: 5");
            }
        }

        // Вычисление суммы ряда
        // Формула: c = 1/1! + 1/2! + ... + 1/n!
        for (int k = 1; k <= n; k++)
        {
            fact *= k;                  // вычисляем факториал (k!)
            double term = 1.0 / fact;   // очередной член ряда
            c += term;                  // добавляем к сумме

            Console.WriteLine($"k = {k}, {k}! = {fact}, 1/{k}! = {term:F9}, текущая сумма = {c:F9}");
        }

        // Итоговый вывод
        Console.WriteLine();
        Console.WriteLine($"Сумма ряда из 1..{n}! равна: {c:F9}");

        Console.ReadKey(true);
    }
}
