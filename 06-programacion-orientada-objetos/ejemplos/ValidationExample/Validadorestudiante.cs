// Validador: publica el evento y lee los datos hasta que sean válidos
public class ValidadorEstudiante
{
    // Evento publicador
    public event EventHandler<ValidacionEventArgs>? ValidacionFallida;

    private void Notificar(string campo, string mensaje) =>
        ValidacionFallida?.Invoke(this, new ValidacionEventArgs(campo, mensaje));

    // Nombre: usa EXCEPCIONES + evento
    public string LeerNombre()
    {
        while (true)
        {
            Console.Write("Nombre: ");
            string? entrada = Console.ReadLine();

            try
            {
                if (string.IsNullOrWhiteSpace(entrada))
                    throw new DatoInvalidoException("Nombre", "El nombre es obligatorio.");

                if (entrada.Trim().Length < 3)
                    throw new DatoInvalidoException("Nombre", "Mínimo 3 caracteres.");

                return entrada.Trim();
            }
            catch (DatoInvalidoException ex)
            {
                Notificar(ex.Campo, ex.Message);
            }
        }
    }

    // Edad: usa TryParse (asignación segura) + rango
    public int LeerEdad()
    {
        while (true)
        {
            Console.Write("Edad: ");

            if (!int.TryParse(Console.ReadLine(), out int edad))
            {
                Notificar("Edad", "Debe ser un número entero.");
                continue;
            }

            if (edad < 15 || edad > 100)
            {
                Notificar("Edad", "Debe estar entre 15 y 100.");
                continue;
            }

            return edad;
        }
    }

    // Correo: formato básico, excepción + evento
    public string LeerCorreo()
    {
        while (true)
        {
            Console.Write("Correo: ");
            string? entrada = Console.ReadLine();

            try
            {
                if (string.IsNullOrWhiteSpace(entrada))
                    throw new DatoInvalidoException("Correo", "El correo es obligatorio.");

                int arroba = entrada.IndexOf('@');
                if (arroba < 1 || entrada.IndexOf('.', arroba) < arroba + 2 || entrada.EndsWith('.'))
                    throw new DatoInvalidoException("Correo", "Formato inválido.");

                return entrada.Trim();
            }
            catch (DatoInvalidoException ex)
            {
                Notificar(ex.Campo, ex.Message);
            }
        }
    }

    // Nota: double.TryParse + rango de 0 a 10
    public double LeerNota()
    {
        while (true)
        {
            Console.Write("Nota (0 a 10): ");

            if (!double.TryParse(Console.ReadLine(), out double nota))
            {
                Notificar("Nota", "Debe ser un número.");
                continue;
            }

            if (nota < 0 || nota > 10)
            {
                Notificar("Nota", "Debe estar entre 0 y 10.");
                continue;
            }

            return nota;
        }
    }
}