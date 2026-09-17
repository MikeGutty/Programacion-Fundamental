Console.WriteLine("Ingrese un número entero: ");
        int numero = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"\nTabla de multiplicar del {numero}:");

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{numero} x {i} = {numero * i}");
        }