Console.Write("Ingrese la nota final del estudiante (0-100): ");
        int nota = Convert.ToInt32(Console.ReadLine());

        if (nota < 0 || nota > 100)
        {
            Console.WriteLine("Error: la nota debe estar entre 0 y 100");
        }
        else if (nota >= 90)
        {
            Console.WriteLine("Calificacion: Excelente");
        }
        else if (nota >= 70)
        {
            Console.WriteLine("Calificacion: Bueno");
        }
        else if (nota >= 50)
        {
            Console.WriteLine("Calificacion: Regular");
        }
        else
        {
            Console.WriteLine("Calificacion: Reprobado");
        }