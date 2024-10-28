public class TRPyramid
{
    private TRTriangle baseTriangle; // Основний трикутник
    private double height; // Висота піраміди

    // Публічний конструктор з параметрами
    public TRPyramid(TRTriangle baseTriangle, double height)
    {
        if (baseTriangle == null)
            throw new ArgumentNullException(nameof(baseTriangle), "Base triangle cannot be null");

        this.baseTriangle = baseTriangle;
        this.height = Math.Abs(height);
    }

    // Публічний метод для введення висоти піраміди з перевіркою
    public void InputHeight()
    {
        height = InputPositiveValue("Введіть висоту піраміди (більше 0): ");
    }

    // Метод для запиту додатного значення
    private double InputPositiveValue(string message)
    {
        double value;
        do
        {
            Console.WriteLine(message);
            value = Convert.ToDouble(Console.ReadLine());
            if (value <= 0)
            {
                Console.WriteLine("Помилка: Значення повинно бути більше 0. Спробуйте ще раз.");
            }
        } while (value <= 0);
        return value;
    }

    // Публічний метод для обчислення об'єму піраміди
    public double Volume()
    {
        return (1.0 / 3.0) * baseTriangle.Area() * height;
    }

    // Публічний метод для виведення інформації про піраміду
    public void Output()
    {
        baseTriangle.Output();
        Console.WriteLine($"Висота піраміди: {height}");
        Console.WriteLine($"Об'єм піраміди: {Volume()}");
    }
}
