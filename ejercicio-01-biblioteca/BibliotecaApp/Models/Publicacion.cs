namespace BibliotecaApp
{
  public class Publicacion
  {
    public string Titulo{ get; set; }
    public int Anio { get; set; }
    protected string ISBN { get; set; }
    public double Costo { get; set; }

    public Publicacion(string titulo, int anio, string isbn, double costo)
    {
      Titulo = titulo;
      Anio = anio;
      ISBN = isbn;
      Costo = costo;
    }

    public virtual void MostrarInformacion()
    {
      Console.WriteLine($"El isbn es {ISBN} el titulo es {Titulo} el año de publicacion es {Anio} y el costo es de {Costo}");
    }
  }
}