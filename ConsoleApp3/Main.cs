using System;

class Program
{

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        // Створення і введення даних для першого трикутника
        TRTriangle triangle1 = new TRTriangle();
        Console.WriteLine("Введіть дані для першого трикутника:");
        triangle1.Input();

        // Створення і введення даних для другого трикутника
        TRTriangle triangle2 = new TRTriangle();
        Console.WriteLine("Введіть дані для другого трикутника:");
        triangle2.Input();

        // Порівняння трикутників
        Console.WriteLine("Порівняння трикутників:");
        if (triangle1.Equals(triangle2))
        {
            Console.WriteLine("Трикутники мають однакову площу.");
        }
        else
        {
            Console.WriteLine("Трикутники мають різну площу.");
        }

        try
        {
            // Створення піраміди з першим трикутником, початкова висота = 0
            TRPyramid pyramid = new TRPyramid(triangle1, 0); // Передаємо нульову висоту спочатку

            // Введення висоти піраміди
            pyramid.InputHeight();

            // Якщо введення висоти пройшло успішно, виводимо дані про піраміду
            pyramid.Output();
        }
        catch (Exception ex)
        {
            // Виводимо помилку і завершуємо роботу з пірамідою
            Console.WriteLine($"Помилка під час введення висоти піраміди: {ex.Message}");
            return;  // Завершуємо виконання, якщо сталася помилка
        }
    }
}
