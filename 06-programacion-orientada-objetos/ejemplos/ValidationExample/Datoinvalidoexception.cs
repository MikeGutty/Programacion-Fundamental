// Excepción personalizada: hereda de Exception y agrega el campo que falló
public class DatoInvalidoException : Exception
{
    public string Campo { get; }

    public DatoInvalidoException(string campo, string mensaje) : base(mensaje)
    {
        Campo = campo;
    }
}