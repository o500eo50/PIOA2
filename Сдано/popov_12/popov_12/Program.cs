using System;
using System.IO;
using System.Text;

class Program
{
    static string filePath = "clrs.txt";
    static bool isRunning = true;
    static string[] colors = { "красный", "оранжевый", "жёлтый", "зелёный", "голубой", "синий", "фиолетовый" };

    static void ShowHelp()
    {
        string[] menuTexts =
        {
            "1. Создать файл с цветами",
            "2. Показать содержимое файла",
            "h. Подсказка",
            "q. Выход"
        };

        Console.WriteLine("\n--- МЕНЮ ---");
        for (int i = 0; i < menuTexts.Length; i++)
        {
            Console.WriteLine(menuTexts[i]);
        }
    }

    static void ProcessCommand(string input)
    {
        switch (input.ToLower())
        {
            case "1":
                CreateFile();
                break;
            case "2":
                ShowFile();
                break;
            case "h":
                ShowHelp();
                break;
            case "q":
                isRunning = false;
                break;
            default:
                Console.WriteLine("ОШИБКА! Неизвестная команда.");
                break;
        }
    }

    static void CreateFile()
    {
        // Перемешиваем массив случайным образом
        Random rnd = new Random();
        string[] shuffled = new string[colors.Length];
        colors.CopyTo(shuffled, 0);

        for (int i = 0; i < shuffled.Length; i++)
        {
            int j = rnd.Next(i, shuffled.Length);
            string temp = shuffled[i];
            shuffled[i] = shuffled[j];
            shuffled[j] = temp;
        }

        // Пишем в файл
        StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8);
        for (int i = 0; i < shuffled.Length; i++)
        {
            writer.WriteLine(shuffled[i]);
        }
        writer.Close();

        if (File.Exists(filePath))
        {
            Console.WriteLine(" Файл успешно создан!");
        }
        else
        {
            Console.WriteLine(" Ошибка: файл не создан.");
        }
    }

    static void ShowFile()
    {
        if (File.Exists(filePath))
        {
            Console.WriteLine("\n=== СОДЕРЖИМОЕ ФАЙЛА ===");
            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {lines[i]}");
            }

            if (lines.Length == 0)
            {
                Console.WriteLine("Файл пуст.");
            }
        }
        else
        {
            Console.WriteLine(" Файл не найден. Сначала создайте его (пункт 1).");
        }
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        ShowHelp();

        while (isRunning)
        {
            Console.Write("\nВведите команду: ");
            string input = Console.ReadLine().Trim();
            ProcessCommand(input);
        }

        Console.WriteLine("Программа завершена.");
    }
}
