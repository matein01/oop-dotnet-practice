namespace BibliotecaApp
{
  public class Publicacion
  {
    public string Titulo{ get; set; }
    public int Anio { get; set; }
    public string ISBN { get; set; }
    public double Costo { get; set; }
    public string Tipo { get; set; }

    public Publicacion(string titulo, int anio, string isbn, double costo, string tipo)
    {
      Titulo = titulo;
      Anio = anio;
      ISBN = isbn;
      Costo = costo;
      Tipo = tipo;
    }

    public virtual void MostrarInformacion()
    {
      Console.WriteLine($"El isbn es {ISBN} el titulo es {Titulo} el año de publicacion es {Anio} el costo es de {Costo} y es de tipo {Tipo}");
    }
  }
}