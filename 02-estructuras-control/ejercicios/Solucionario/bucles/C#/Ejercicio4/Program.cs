Console.Write("Ingrese el número inicial: ");
int numeroInicial = int.Parse(Console.ReadLine());

Console.Write("Ingrese el número final: ");
int numeroFinal = int.Parse(Console.ReadLine());

if (numeroInicial > numeroFinal)
{
    Console.WriteLine("Error: el número inicial debe ser menor o igual al número final.");
}
else
{
    int suma = 0;

    for (int i = numeroInicial; i <= numeroFinal; i++)
    {
        if (i % 2 == 0)
        {
            suma += i;
        }
    }

    Console.WriteLine($"La suma de los números pares es: {suma}");
}