string contrasena;
string contrasenaCorrecta = "clave123";
int intentos = 0;

do
{
    Console.Write("Ingrese la contraseña: ");
    contrasena = Console.ReadLine();
    intentos++;

    if (contrasena != contrasenaCorrecta)
    {
        Console.WriteLine("Contraseña incorrecta.");
    }

} while (contrasena != contrasenaCorrecta && intentos < 3);

if (contrasena == contrasenaCorrecta)
{
    Console.WriteLine("¡Bienvenido! Acceso permitido.");
}
else
{
    Console.WriteLine("Ha superado el máximo de 3 intentos. Acceso bloqueado.");
}