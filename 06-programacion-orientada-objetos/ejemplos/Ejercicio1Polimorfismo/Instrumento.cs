public class Instrumento
{
   protected string nombre; 

   public Instrumento(string nombre)
   {
      this.nombre = nombre;
   }

   public virtual void Tocar()
   {
      Console.WriteLine($"{nombre} produce un sonido generico.");
   }

   public void Afinar()
   {
      Console.WriteLine($"Afinando {nombre}");
   }
}