Console.WriteLine("===== MENÚ DE OPERACIONES =====");
Console.WriteLine("1. Sumar");
Console.WriteLine("2. Restar");
Console.WriteLine("3. Multiplicar");
Console.WriteLine("4. Dividir");
Console.WriteLine("===============================");

Console.Write("Seleccione una opción: ");
int opcion = int.Parse(Console.ReadLine());

switch (opcion)
{
    case 1:
        Console.Write("Ingrese el primer número: ");
        double numero1 = double.Parse(Console.ReadLine());

        Console.Write("Ingrese el segundo número: ");
        double numero2 = double.Parse(Console.ReadLine());

        Console.WriteLine($"Resultado: {numero1 + numero2}");
        break;

    case 2:
        Console.Write("Ingrese el primer número: ");
        numero1 = double.Parse(Console.ReadLine());

        Console.Write("Ingrese el segundo número: ");
        numero2 = double.Parse(Console.ReadLine());

        Console.WriteLine($"Resultado: {numero1 - numero2}");
        break;

    case 3:
        Console.Write("Ingrese el primer número: ");
        numero1 = double.Parse(Console.ReadLine());

        Console.Write("Ingrese el segundo número: ");
        numero2 = double.Parse(Console.ReadLine());

        Console.WriteLine($"Resultado: {numero1 * numero2}");
        break;

    case 4:
        Console.Write("Ingrese el primer número: ");
        numero1 = double.Parse(Console.ReadLine());

        Console.Write("Ingrese el segundo número: ");
        numero2 = double.Parse(Console.ReadLine());

        if (numero2 == 0)
        {
            Console.WriteLine("Error: no se puede dividir entre cero.");
        }
        else
        {
            Console.WriteLine($"Resultado: {numero1 / numero2}");
        }

        break;

    default:
        Console.WriteLine("Error: la opción ingresada no es válida.");
        break;
}