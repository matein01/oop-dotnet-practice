namespace BibliotecaApp
{
  public class Revista : Publicacion
  {
    //Atributos de una revista
    public int Paginas { get; set; }

    //Constructor de una revista heredando de publicacion
    public Revista(int paginas, double costo, string tipo, string titulo, int anio, string isbn, int id) : base(titulo, anio, isbn, costo, tipo, id)
    {
      Paginas = paginas;
    }

    //Metodo heredado para mostrar informacion de la revista
    public override void MostrarInformacion()
    {
      base.MostrarInformacion();
      Console.WriteLine($"La cantidad de paginas que tiene la revista son {Paginas}");
      Console.WriteLine($"----------------------------------------------------------------------------------------");
    }
  }
}