Console.WriteLine("Ingrese un número: ");
        double numero = Convert.ToDouble(Console.ReadLine());

        if (numero > 0)
        {
            Console.WriteLine("El número es POSITIVO.");
        }
        else if (numero < 0)
        {
            Console.WriteLine("El número es NEGATIVO.");
        }
        else
        {
            Console.WriteLine("El número es CERO.");
        }