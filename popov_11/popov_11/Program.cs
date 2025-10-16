using System;

namespace task11_var03
{
    class Program
    {
        /// <summary>
        /// Масштабирование псевдослучайного числа с сдвигом
        /// </summary>
        /// <param name="number">Число для масштабирования (по ссылке)</param>
        /// <param name="scale">Коэффициент усиления</param>
        /// <param name="shift">Сдвиг относительно нуля</param>
        static void _cScale(ref float number, int scale, int shift)
        {
            Random rnd = new Random();
            float randomValue = (float)rnd.NextDouble(); // [0,1)
            number = randomValue * scale + shift;        // масштабирование и сдвиг
        }

        static void Main(string[] args)
        {
            float myNumber = 0f;   // неинициализированная переменная
            int scale = 20;         // коэффициент усиления
            int shift = 10;         // сдвиг относительно нуля

            Console.WriteLine("До масштабирования: " + myNumber);

            // Вызов метода масштабирования
            _cScale(ref myNumber, scale, shift);

            Console.WriteLine("После масштабирования: " + myNumber.ToString("0.00"));
            Console.ReadKey(true);
        }
    }
}
