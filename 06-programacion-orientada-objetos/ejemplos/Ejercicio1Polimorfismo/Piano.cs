public class Piano : Instrumento
{
   public Piano(string nombre) : base(nombre)
   {
   }

   public override void Tocar()
   {
      Console.WriteLine($"{nombre} (piano): ¡notas de teclas!");
   }
}