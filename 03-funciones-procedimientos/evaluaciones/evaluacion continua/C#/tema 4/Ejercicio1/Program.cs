using System;

class Program
{
    static double CalcularArea(double baseRectangulo, double alturaRectangulo)
    {
        return baseRectangulo * alturaRectangulo;
    }

    static void Main()
    {
        Console.WriteLine("Ingrese la base del rectángulo: ");
        double baseRectangulo = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Ingrese la altura del rectángulo: ");
        double alturaRectangulo = Convert.ToDouble(Console.ReadLine());

        double area = CalcularArea(baseRectangulo, alturaRectangulo);

        Console.WriteLine($"El área del rectángulo es: {area}");
    }
}