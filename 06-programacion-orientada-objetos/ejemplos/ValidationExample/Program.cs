public class Program
{
    public static void Main(string[] args)
    {
        // El código principal ya está fuera de Main, pero se puede invocar aquí si se desea
        // Caso práctico: Registro de Estudiantes (.NET 10, aplicación de consola)
        // Integra asignaciones (TryParse), eventos (ValidacionFallida) y excepciones (DatoInvalidoException)

        var validador = new ValidadorEstudiante();

        // Suscripción al evento: qué hacer cuando una validación falla
        validador.ValidacionFallida += (sender, e) =>
            Console.WriteLine($"  ⚠ [{e.Campo}] {e.Mensaje}");

        Console.WriteLine("=== Registro de Estudiantes ===");

        var estudiante = new Estudiante
        {
            Nombre = validador.LeerNombre(),
            Edad = validador.LeerEdad(),
            Correo = validador.LeerCorreo(),
            Nota = validador.LeerNota()
        };

        Console.WriteLine("\nEstudiante registrado correctamente:");
        Console.WriteLine(estudiante);
    }
}