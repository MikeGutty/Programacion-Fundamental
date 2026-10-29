public class EmpleadoPorHoras : Empleado
{
    public decimal TarifaPorHora { get; }
    public int HorasTrabajadas { get; }

    public EmpleadoPorHoras(int id, string nombre, decimal tarifaPorHora, int horasTrabajadas)
        : base(id, nombre)
    {
        if (tarifaPorHora < 0)
            throw new ArgumentOutOfRangeException(nameof(tarifaPorHora));
        if (horasTrabajadas < 0)
            throw new ArgumentOutOfRangeException(nameof(horasTrabajadas));
        TarifaPorHora = tarifaPorHora;
        HorasTrabajadas = horasTrabajadas;
    }

    public override decimal CalcularPago() => TarifaPorHora * HorasTrabajadas;
}