Console.WriteLine("Ingrese la nota final del estudiante: ");
        double nota = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Ingrese el porcentaje de asistencia: ");
        double asistencia = Convert.ToDouble(Console.ReadLine());

        bool cumpleNota = nota >= 51;
        bool cumpleAsistencia = asistencia >= 80;
        bool aprobo = cumpleNota && cumpleAsistencia;

        Console.WriteLine($"a) Nota obtenida: {nota}");
        Console.WriteLine($"b) Porcentaje de asistencia: {asistencia}%");
        Console.WriteLine($"c) ¿Cumple con la nota mínima?: {cumpleNota}");
        Console.WriteLine($"d) ¿Cumple con el porcentaje mínimo de asistencia?: {cumpleAsistencia}");
        Console.WriteLine(aprobo
            ? "e) El estudiante APROBÓ la materia."
            : "e) El estudiante REPROBÓ la materia.");