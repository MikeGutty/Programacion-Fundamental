public class Program
{
    public static void Main(string[] args)
    {
        // 1.
        Instrumento i = new Guitarra("Fender");
        i.Tocar();

        // 2.
        List<Instrumento> instrumentos = new List<Instrumento>
        {
            new Guitarra("Gibson"),
            new Guitarra("Ibanez"),
            new Piano("Yamaha"),
            new Bateria("Pearl"),
            new Maracas("Latin Percussion")
        };

        // 3.
        foreach (Instrumento instrumento in instrumentos)
        {
            instrumento.Afinar();
            instrumento.Tocar();
        }
    }
}