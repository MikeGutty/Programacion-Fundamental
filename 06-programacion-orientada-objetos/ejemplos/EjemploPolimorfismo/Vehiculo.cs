public class Vehiculo
{
    public string Marca { get; }
    public int Anio { get; }

    public Vehiculo(string marca, int anio)
    {
        Marca = marca;
        Anio = anio;
    }

    public virtual void Describir()
        => Console.WriteLine($"Vehículo: {Marca} ({Anio})");
}