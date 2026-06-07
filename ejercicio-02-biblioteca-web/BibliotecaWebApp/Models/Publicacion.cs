namespace BibliotecaWebApp.Models
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
  }
}