int numero;

do
{
    Console.Write("Ingrese un número entero no negativo: ");
    numero = int.Parse(Console.ReadLine());
} while (numero < 0);

int factorial = 1;

for (int i = 1; i <= numero; i++)
{
    factorial = factorial * i;
}

Console.WriteLine($"El factorial de {numero} es: {factorial}");