public class Program
{
    static void Main(string[] args)
    {
        Empleado empleado = new EmpleadoTiempoCompleto(1, "John Doe", 2000);
        Empleado empleado2 = new EmpleadoTiempoCompleto(2, "Jane Smith", 2500);
        Empleado empleado3 = new EmpleadoTiempoCompleto(3, "Alice Johnson", 3000);
        Empleado empleado4 = new EmpleadoPorHoras(4, "Bob Brown", 20, 80);

        List<Empleado> empleados1 = new List<Empleado> { empleado, empleado2, empleado3, empleado4 };

        List<Empleado> empleados = new()
        {
            new EmpleadoTiempoCompleto(1, "Ana Torres", 3200m),
            new EmpleadoPorHoras(2, "Luis Mamani", 45m, 120),
            new EmpleadoPorHoras(3, "Carla Rojas", 38.5m, 80)
        };

        decimal total = 0m;

        foreach (Empleado e in empleados)
        {
            decimal pago = e.CalcularPago();
            total += pago;
            Console.WriteLine($"{e.Id} | {e.Nombre,-12} | {e.GetType().Name,-21} | {pago,9:N2}");
        }

        Console.WriteLine($"Total nómina: {total:N2}");
    }
}