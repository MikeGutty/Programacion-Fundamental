public class Vehiculo
{
    public string Marca { get; set; } = "";
    public int Anio { get; set; }

    public void Describir() =>
        Console.WriteLine($"{Marca} ({Anio})");
}