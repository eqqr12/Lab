using System;

public class TRTriangle
{
    private double a, b;

    // Публічний конструктор без параметрів
    public TRTriangle()
    {
        a = 1;
        b = 1;
    }

    // Публічний конструктор з параметрами
    public TRTriangle(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    // Публічний конструктор копіювання
    public TRTriangle(TRTriangle other)
    {
        this.a = other.a;
        this.b = other.b;
    }

    // Публічний метод для введення даних
    public void Input()
    {
        Console.WriteLine("Введіть довжину катета a: ");
        a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введіть довжину катета b: ");
        b = Convert.ToDouble(Console.ReadLine());
    }

    // Публічний метод для визначення площі
    public double Area()
    {
        return 0.5 * Math.Abs(a) * Math.Abs(b);
    }

    public double Perimeter()
    {
        double c = Math.Sqrt(Math.Abs(a) * Math.Abs(a) + Math.Abs(b) * Math.Abs(b)); // Гіпотенуза
        return Math.Abs(a) + Math.Abs(b) + c;
    }


    // Публічний метод для порівняння площ трикутників
    public bool Equals(TRTriangle other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        return Math.Abs(this.Area() - other.Area()) < 0.001;
    }



    // Публічний метод для виведення інформації про трикутник
    public void Output()
    {
        Console.WriteLine($"Трикутник з катетами a = {a}, b = {b}");
        Console.WriteLine($"Площа: {Area()}");
        Console.WriteLine($"Периметр: {Perimeter()}");
    }
}
