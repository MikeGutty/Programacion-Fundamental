int numero1, numero2;

        do
        {
            Console.WriteLine("Ingrese el primer número (debe ser menor que el segundo): ");
            numero1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo número: ");
            numero2 = Convert.ToInt32(Console.ReadLine());

            if (numero1 >= numero2)
            {
                Console.WriteLine("Error: el primer número debe ser menor que el segundo. Intente de nuevo.\n");
            }

        } while (numero1 >= numero2);

        int opcion;
        do
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Suma de números pares");
            Console.WriteLine("2. Suma de números impares");
            Console.WriteLine("3. Salir");
            Console.WriteLine("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    int sumaPares = 0;
                    for (int i = numero1; i <= numero2; i++)
                    {
                        if (i % 2 == 0)
                            sumaPares += i;
                            // sumaPares = sumaPares + i; // Otra forma de escribirlo
                    }
                    Console.WriteLine($"La suma de los números pares es: {sumaPares}");
                    break;

                case 2:
                    int sumaImpares = 0;
                    for (int i = numero1; i <= numero2; i++)
                    {
                        if (i % 2 != 0)
                            sumaImpares += i;
                    }
                    Console.WriteLine($"La suma de los números impares es: {sumaImpares}");
                    break;

                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida, intente nuevamente.");
                    break;
            }

        } while (opcion != 3);