namespace BibliotecaApp
{
  public class Libro : Publicacion
  {
    //Atributos de un libro
    public string Autor{ get; set; }

    //Constructor de un libro heredando de publicacion
    public Libro(string autor, double costo, string tipo, string titulo, int anio, string isbn, int id) : base(titulo, anio, isbn, costo, tipo, id)
    {
      Autor = autor;
    }

    //Metodo heredado para mostrar informacion de un libro
    public override void MostrarInformacion()
    {
      base.MostrarInformacion();
      Console.WriteLine($"El autor del libro es {Autor}");
      Console.WriteLine($"----------------------------------------------------------------------------------------");
    }
  }
}