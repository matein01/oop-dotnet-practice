namespace BibliotecaApp
{
  public class Publicacion
  {
    //Atributos de una publicacion
    public string Titulo{ get; set; }
    public int Anio { get; set; }
    public string ISBN { get; set; }
    public double Costo { get; set; }
    public string Tipo { get; set; }
    public int Id{ get; set; }

    //Consturctor de las publicaciones
    public Publicacion(string titulo, int anio, string isbn, double costo, string tipo, int id)
    {
      Titulo = titulo;
      Anio = anio;
      ISBN = isbn;
      Costo = costo;
      Tipo = tipo;
      Id = id;
    }

    //Metodo para mostrar la informacion de una publicacion
    public virtual void MostrarInformacion()
    {
      Console.WriteLine($"----------------------------------------------------------------------------------------");
      Console.WriteLine($"La publicacion es del tipo {Tipo}, tiene el id {Id}, su ISBN es {ISBN}, el titulo es {Titulo}, se publico en el año {Anio} y cuesta {Costo} dolares");
    }
  }
}