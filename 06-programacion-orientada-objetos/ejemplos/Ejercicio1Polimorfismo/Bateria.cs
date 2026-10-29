public class Bateria : Instrumento
{
   public Bateria(string nombre) : base(nombre)
   {
   }

   public override void Tocar()
   {
      Console.WriteLine($"{nombre} (bateria): ¡ritmo de tambores!");
   }
}