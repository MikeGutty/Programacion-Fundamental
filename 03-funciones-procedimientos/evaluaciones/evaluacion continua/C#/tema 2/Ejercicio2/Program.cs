Console.WriteLine("Ingrese el primer número entero: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el segundo número entero: ");
        int b = Convert.ToInt32(Console.ReadLine());

        int suma = a + b;
        int resta = a - b;
        int multiplicacion = a * b;
        int cocienteEntero = a / b;
        int residuo = a % b;

        Console.WriteLine($"Suma: {suma}");
        Console.WriteLine($"Resta: {resta}");
        Console.WriteLine($"Multiplicación: {multiplicacion}");
        Console.WriteLine($"Cociente entero: {cocienteEntero}");
        Console.WriteLine($"Residuo: {residuo}");

        // El operador módulo (%) devuelve el residuo de una división entera.
        // Es muy útil, por ejemplo, para saber si un número es par o impar
        // (residuo 0 o 1 al dividir entre 2), o para validar límites cíclicos.