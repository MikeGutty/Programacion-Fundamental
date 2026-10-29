public class Motocicleta : Vehiculo
{
    public int Cilindrada { get; }

    public Motocicleta(string marca, int anio, int cc)
        : base(marca, anio) { Cilindrada = cc; }

    public override void Describir()
        => Console.WriteLine($"Motocicleta: {Marca} ({Anio}), {Cilindrada} cc");
}