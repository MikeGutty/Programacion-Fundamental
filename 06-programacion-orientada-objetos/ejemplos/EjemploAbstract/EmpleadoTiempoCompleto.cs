public class EmpleadoTiempoCompleto : Empleado
{
    public decimal SalarioMensual { get; }

    public EmpleadoTiempoCompleto(int id, string nombre, decimal salarioMensual)
        : base(id, nombre)
    {
        if (salarioMensual < 0)
            throw new ArgumentOutOfRangeException(nameof(salarioMensual));
        SalarioMensual = salarioMensual;
    }

    public override decimal CalcularPago() => SalarioMensual;
}