Console.Write("Ingrese el primer lado: ");
double lado1 = double.Parse(Console.ReadLine());

Console.Write("Ingrese el segundo lado: ");
double lado2 = double.Parse(Console.ReadLine());

Console.Write("Ingrese el tercer lado: ");
double lado3 = double.Parse(Console.ReadLine());

if (lado1 <= 0 || lado2 <= 0 || lado3 <= 0)
{
    Console.WriteLine("Error: todos los lados deben ser mayores que 0.");
}
else if (lado1 == lado2 && lado2 == lado3)
{
    Console.WriteLine("El triángulo es equilátero.");
}
else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
{
    Console.WriteLine("El triángulo es isósceles.");
}
else
{
    Console.WriteLine("El triángulo es escaleno.");
}