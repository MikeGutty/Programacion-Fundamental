Console.Write("Ingrese el peso del paquete en kg: ");
double peso = double.Parse(Console.ReadLine());

if (peso < 0)
{
    Console.WriteLine("Error: el peso no puede ser negativo.");
}
else if (peso <= 5)
{
    Console.WriteLine("El costo del envío es $5.00");
}
else if (peso <= 15)
{
    Console.WriteLine("El costo del envío es $12.00");
}
else if (peso <= 30)
{
    Console.WriteLine("El costo del envío es $20.00");
}
else
{
    Console.WriteLine("El costo del envío es $35.00");
}