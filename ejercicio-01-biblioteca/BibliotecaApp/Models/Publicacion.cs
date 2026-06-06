namespace BibliotecaApp
{
  public class Publicacion
  {
    //Atributos de una publicación
    public string Titulo { get; set; }
    public int Anio { get; set; }
    public string ISBN { get; set; }
    public double Costo { get; set; }
    public string Tipo { get; set; }
    public int Id { get; set; }

    //Constructor de las publicaciones
    public Publicacion(string titulo, int anio, string isbn, double costo, string tipo, int id)
    {
      Titulo = titulo;
      Anio = anio;
      ISBN = isbn;
      Costo = costo;
      Tipo = tipo;
      Id = id;
    }

    //Método virtual para mostrar la información de una publicación
    public virtual void MostrarInformacion()
    {
      Console.WriteLine($"----------------------------------------------------------------------------------------");
      Console.WriteLine($"La publicación es del tipo {Tipo}, tiene el id {Id}, su ISBN es {ISBN}, el título es {Titulo}, se publicó en el año {Anio} y cuesta {Costo} dólares");
    }
  }
}