Console.Write("Ingrese la edad del cliente: ");
int edad = int.Parse(Console.ReadLine());

Console.Write("Ingrese el monto de la compra: ");
double monto = double.Parse(Console.ReadLine());

Console.Write("¿Tiene membresía activa? (si/no): ");
string membresia = Console.ReadLine().ToLower();

double descuento;
double montoFinal;

if (edad >= 18 && monto >= 50 && membresia == "si")
{
    descuento = monto * 0.15;
    montoFinal = monto - descuento;

    Console.WriteLine("El cliente recibe un descuento del 15%.");
    Console.WriteLine($"Descuento aplicado: ${descuento:F2}");
    Console.WriteLine($"Monto final a pagar: ${montoFinal:F2}");
}
else
{
    montoFinal = monto;

    Console.WriteLine("El cliente no recibe el descuento.");
    Console.WriteLine($"Monto final a pagar: ${montoFinal:F2}");
}