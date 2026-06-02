namespace BibliotecaApp
{
  public class Revista : Publicacion
  {
    public string Tipo { get; set; }
    public int Paginas { get; set; }

    public Revista(int paginas, double costo, string tipo, string titulo, int anio, string isbn) : base(titulo, anio, isbn, costo)
    {
      Tipo = tipo;
      Paginas = paginas;
    }

    public override void MostrarInformacion()
    {
      base.MostrarInformacion();
      Console.WriteLine($"La cantidad de paginas que tiene la revista son [{Paginas}] y el tipo de la revista es [{Tipo}]");
    }
  }
}