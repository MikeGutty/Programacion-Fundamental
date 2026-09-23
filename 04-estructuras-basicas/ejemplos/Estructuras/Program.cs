class Program()
{
    struct Estudiante
    {
        public string nombre;
        public int edad;
        public string carrera;
        public int promedio;
    }

    static void Main(string[] args)
    {
        // Declarando una variable de tipo Estudiante
        Estudiante estudiante;
        estudiante.nombre = "Juan";
        estudiante.edad = 20;
        estudiante.carrera = "Ingeniería";
        estudiante.promedio = 85;

        Console.WriteLine("Nombre: " + estudiante.nombre);
        Console.WriteLine("Edad: " + estudiante.edad);
        Console.WriteLine("Carrera: " + estudiante.carrera);
        Console.WriteLine("Promedio: " + estudiante.promedio);
        Console.WriteLine($"Nombre: {estudiante.nombre}, Edad: {estudiante.edad}, Carrera: {estudiante.carrera}, Promedio: {estudiante.promedio}");
    }
}