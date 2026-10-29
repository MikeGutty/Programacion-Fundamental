public class Guitarra : Instrumento
{
   public Guitarra(string nombre) : base(nombre)
    {
    }

   public override void Tocar()
   {
      Console.WriteLine($"{nombre} (guitarra): ¡rasgueo de cuerdas!");
   }
}