public class Program
{
    static void Main()
    {
        Vehiculo v1 = new Automovil("Toyota", 2022, 4);
        Vehiculo v2 = new Motocicleta("Yamaha", 2021, 250);

        v1.Describir();   // Automóvil: Toyota (2022), 4 puertas
        v2.Describir();   // Motocicleta: Yamaha (2021), 250 cc

        // v1.NumeroPuertas;   // Error: el tipo estático es Vehiculo
        if (v1 is Automovil a)
            Console.WriteLine(a.NumeroPuertas);   // 4
    }
}