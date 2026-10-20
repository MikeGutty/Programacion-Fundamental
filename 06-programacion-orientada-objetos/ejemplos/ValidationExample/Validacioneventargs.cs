// Datos que viajan con el evento ValidacionFallida
public class ValidacionEventArgs : EventArgs
{
    public string Campo { get; }
    public string Mensaje { get; }

    public ValidacionEventArgs(string campo, string mensaje)
    {
        Campo = campo;
        Mensaje = mensaje;
    }
}