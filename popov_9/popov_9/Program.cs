using System;

class Program
{
    static void Main(string[] args)
    {
        // === Блок объявления всех переменных  ===
        int n = 0;            // Длина массива (целое n >= 1)
        int[] A = null;       // Одномерный массив целых чисел
        bool ok = false;      // Флаг корректности последнего ввода (состояние TryParse)
        int i = 0;            // Счётчик циклов
        int minIndex = 0;     // Индекс первого вхождения минимального элемента
        int maxIndex = 0;     // Индекс первого вхождения максимального элемента
        int diff = 0;         // Разность индексов: maxIndex - minIndex
        string input = "";    // Буфер строки для валидации ввода через TryParse

        // === Ввод n по схеме "ввод до победного" (без возможности прерывания) ===
        // Требование: пользователю предлагается вводить до тех пор, пока значение не станет корректным.
        // Контроль: целое число и ограничение n >= 1.
        ok = false;
        while (ok == false)
        {
            Console.Write("Введите количество элементов одномерного массива: ");
            input = Console.ReadLine();
            ok = Int32.TryParse(input, out n);

            if (ok == true)
            {
                if (n >= 1)
                {
                    // Корректное n — выходим из цикла, ok уже true
                }
                else
                {
                    Console.WriteLine("Ошибка: значение n должно быть не меньше 1. Повторите ввод.");
                    ok = false; // Принудительно продолжаем запрос, прерывания нет
                }
            }
            else
            {
                Console.WriteLine("Ошибка: требуется целое число. Повторите ввод.");
                // ok остаётся false — цикл повторит ввод
            }
        }

        // === Создание массива требуемой длины ===
        A = new int[n];

        // === Ввод элементов массива по схеме "ввод до победного" для каждого A[i] ===
        // Для каждого индекса i запрашиваем значение, пока TryParse не подтвердит корректность.
        for (i = 0; i < A.Length; i++)
        {
            bool elementOk = false; // отдельный флаг для текущего элемента
            while (elementOk == false)
            {
                Console.Write($"Введите {i + 1}-й элемент одномерного массива: ");
                input = Console.ReadLine();
                elementOk = Int32.TryParse(input, out A[i]);

                if (elementOk == false)
                {
                    Console.WriteLine("Ошибка: требуется целое число. Повторите ввод.");
                }
                else
                {
                    // Значение корректно — переходим к следующему элементу
                }
            }
        }

        // === Корректный вывод исходного массива в формате опорной схемы ===
        Console.Write("A = (");
        for (i = 0; i < A.Length; i++)
        {
            Console.Write(A[i]);
            if (i != A.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine(")");

        // === Поиск индексов первого минимума и первого максимума (нулевая индексация) ===
        minIndex = 0;
        maxIndex = 0;
        // Если длина > 1, сравниваем последовательно элементы с текущими экстремумами
        for (i = 1; i < A.Length; i++)
        {
            if (A[i] < A[minIndex])
            {
                minIndex = i;
            }

            if (A[i] > A[maxIndex])
            {
                maxIndex = i;
            }
        }

        // === Разность индексов ===
        diff = maxIndex - minIndex;

        // === Вывод результатов с пояснениями ===
        Console.WriteLine($"Индекс минимального элемента (первое вхождение): {minIndex}");
        Console.WriteLine($"Индекс максимального элемента (первое вхождение): {maxIndex}");
        Console.WriteLine($"Разность индексов (maxIndex - minIndex): {diff}");

        // Пауза для удобства проверки 
        Console.WriteLine("Нажмите любую клавишу для завершения...");
        Console.ReadKey(true);
    }
}
