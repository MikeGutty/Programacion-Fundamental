// Modelo con setters que validan (validación mediante asignaciones)
public class Estudiante
{
    private int _edad;
    private double _nota;

    public string Nombre { get; set; } = "";
    public string Correo { get; set; } = "";

    public int Edad
    {
        get => _edad;
        set => _edad = (value >= 15 && value <= 100)
            ? value
            : throw new ArgumentOutOfRangeException(nameof(value), "Edad fuera de rango");
    }

    public double Nota
    {
        get => _nota;
        set => _nota = (value >= 0 && value <= 10)
            ? value
            : throw new ArgumentOutOfRangeException(nameof(value), "Nota fuera de rango");
    }

    public override string ToString() =>
        $"  Nombre: {Nombre}\n  Edad:   {Edad}\n  Correo: {Correo}\n  Nota:   {Nota}";
}