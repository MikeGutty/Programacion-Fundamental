using System;

class Program
{
    static int ObtenerMaximo(int a, int b, int c)
    {
        int maximo = a;
        if (b > maximo) maximo = b;
        if (c > maximo) maximo = c;
        return maximo;
    }

    static void Main()
    {
        Console.WriteLine("Ingrese el primer número: ");
        int n1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese el segundo número: ");
        int n2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese el tercer número: ");
        int n3 = Convert.ToInt32(Console.ReadLine());

        int mayor = ObtenerMaximo(n1, n2, n3);

        Console.WriteLine($"El valor mayor es: {mayor}");
    }
}