using System;  

namespace ClothingSizes  
{  
    // Перечисление размеров одежды с числовыми значениями  
    enum SizeNames  
    {  
        XS = -2,  
        S  = -1,  
        M  = 0,  
        L  = 1,  
        XL = 2,  
        XXL = 3  
    }  

    class Program  
    {  
        static void Main(string[] args)  
        {  
            Console.WriteLine("Введите команду (asc/desc):");  
            string command = Console.ReadLine().ToLower();  

            // Получение всех значений перечисления  
            SizeNames[] sizes = (SizeNames[])Enum.GetValues(typeof(SizeNames));  

            // Сортировка в зависимости от команды  
            if (command == "asc")  
            {  
                Array.Sort(sizes, (a, b) => ((int)a).CompareTo((int)b));  
            }  
            else if (command == "desc")  
            {  
                Array.Sort(sizes, (a, b) => ((int)b).CompareTo((int)a));  
            }  
            else  
            {  
                Console.WriteLine("Неверная команда");  
                return;  
            }  

            // Вывод результатов  
            Console.WriteLine("\nРезультат:");
            for (int i = 0; i < sizes.Length; i++)
            {
                Console.WriteLine(sizes[i]);
            }
        }  
    }  
}  