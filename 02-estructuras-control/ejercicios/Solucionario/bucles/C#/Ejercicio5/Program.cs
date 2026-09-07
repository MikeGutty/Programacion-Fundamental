int opcion;

do
{
    Console.WriteLine("===== MENÚ DE OPCIONES =====");
    Console.WriteLine("1. Sumar dos números");
    Console.WriteLine("2. Restar dos números");
    Console.WriteLine("3. Salir");
    Console.WriteLine("============================");
    Console.Write("Seleccione una opción: ");

    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            Console.Write("Ingrese el primer número: ");
            double numero1 = double.Parse(Console.ReadLine());

            Console.Write("Ingrese el segundo número: ");
            double numero2 = double.Parse(Console.ReadLine());

            double suma = numero1 + numero2;

            Console.WriteLine($"Resultado: {suma}");
            break;

        case 2:
            Console.Write("Ingrese el primer número: ");
            numero1 = double.Parse(Console.ReadLine());

            Console.Write("Ingrese el segundo número: ");
            numero2 = double.Parse(Console.ReadLine());

            double resta = numero1 - numero2;

            Console.WriteLine($"Resultado: {resta}");
            break;

        case 3:
            Console.WriteLine("Saliendo del programa...");
            break;

        default:
            Console.WriteLine("Error: opción inválida. Intente nuevamente.");
            break;
    }

    Console.WriteLine();

} while (opcion != 3);

Console.WriteLine("¡Gracias por utilizar el programa!");