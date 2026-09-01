// Declarando variables
int cantidad, numero;
double suma = 0, promedio;

do
{
    Console.WriteLine("Ingrese la cantidad de numeros a sumar:");
    cantidad = Convert.ToInt32(Console.ReadLine());
    if (cantidad <= 0)
    {
        Console.WriteLine("Debe ingresar un numero mayor a 0");
    }
} while (cantidad <= 0);

for (int i = 1; i <= cantidad; i++)
{
    Console.WriteLine($"Ingrese el numero {i}:");
    numero = Convert.ToInt32(Console.ReadLine());
    suma += numero; // suma = suma + numero
}

promedio = suma / cantidad;
Console.WriteLine($"La suma total es: {suma}");
Console.WriteLine($"El promedio es: {promedio}");