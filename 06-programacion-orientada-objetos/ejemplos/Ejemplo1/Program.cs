class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Este es un ejercicio de Programación Orientada a Objetos");

        // Instanciamos un objeto de la clase Estudiante
        Estudiante e1 = new Estudiante();

        e1.Nombre = "Ana Maria del Barrio";
        e1.Promedio = 85.5;
        e1.MostrarFicha();   // Ana: 85
        
        Estudiante e2 = new Estudiante("Emilio", 80.5);
        e2.MostrarFicha();
    }
}
