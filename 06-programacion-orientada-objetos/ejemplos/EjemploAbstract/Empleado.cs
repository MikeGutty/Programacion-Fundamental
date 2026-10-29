public abstract class Empleado
{
    public int Id { get; }
    public string Nombre { get; }

    protected Empleado(int id, string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre es obligatorio.", nameof(nombre));
        Id = id;
        Nombre = nombre;
    }

    public abstract decimal CalcularPago();
}