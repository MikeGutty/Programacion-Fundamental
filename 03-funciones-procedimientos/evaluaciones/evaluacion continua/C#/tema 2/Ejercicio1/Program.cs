// Cuatro tipos de datos diferentes
    int edad = 20;
    double promedio = 8.75;
    char inicial = 'M';
    bool aprobado = true;

    // Conversión explícita de string a entero
    string entrada = "150";
    int numeroConvertido = Convert.ToInt32(entrada);

    // Salida usando interpolación de cadenas
    Console.WriteLine($"Edad: {edad} años");
    Console.WriteLine($"Promedio: {promedio}");
    Console.WriteLine($"Inicial: {inicial}");
    Console.WriteLine($"¿Aprobado?: {aprobado}");
    Console.WriteLine($"Valor convertido desde string: {numeroConvertido}");