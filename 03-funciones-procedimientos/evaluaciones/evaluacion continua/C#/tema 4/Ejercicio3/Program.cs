using System;

class Program
{
    static void MostrarEncabezado()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("   SISTEMA DE GESTIÓN DE USUARIOS");
        Console.WriteLine("=================================");
    }

    static void MostrarMenu()
    {
        Console.WriteLine("1. Registrar usuario");
        Console.WriteLine("2. Consultar información");
        Console.WriteLine("3. Salir");
    }

    static void Main()
    {
        MostrarEncabezado();
        MostrarMenu();
    }
}