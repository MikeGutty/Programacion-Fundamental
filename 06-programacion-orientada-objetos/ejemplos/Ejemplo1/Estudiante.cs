public class Estudiante
{
    // Atributos
    public string Nombre = "";
    public double Promedio;

    // Constructores
    public Estudiante()
    {
        Nombre = "Sin nombre";
        Promedio = 0.0;
    }
    public Estudiante(string nombre, double promedio)
    {
        Nombre = nombre;
        Promedio = promedio;
    }

    // Métodos
    public void MostrarFicha() =>
        Console.WriteLine($"{Nombre}: {Promedio}");
}