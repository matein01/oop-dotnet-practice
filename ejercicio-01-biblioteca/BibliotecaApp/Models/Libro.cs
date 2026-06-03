namespace BibliotecaApp
{
  public class Libro : Publicacion
  {
    public string Autor{ get; set; }

    public Libro(string autor, double costo, string tipo, string titulo, int anio, string isbn) : base(titulo, anio, isbn, costo, tipo)
    {
      Autor = autor;
    }

    public override void MostrarInformacion()
    {
      base.MostrarInformacion();
      Console.WriteLine($"El autor es {Autor}");
    }
  }
}