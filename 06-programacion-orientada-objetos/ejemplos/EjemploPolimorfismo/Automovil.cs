public class Automovil : Vehiculo
{
    public int NumeroPuertas { get; }

    public Automovil(string marca, int anio, int puertas)
        : base(marca, anio) { NumeroPuertas = puertas; }

    public override void Describir()
        => Console.WriteLine($"Automóvil: {Marca} ({Anio}), {NumeroPuertas} puertas");
}