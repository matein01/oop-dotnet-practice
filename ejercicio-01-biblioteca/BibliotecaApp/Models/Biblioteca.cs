namespace BibliotecaApp
{
  public class Biblioteca
  {
    //Atributos de una biblioteca
    private List<Publicacion> Publicaciones = new List<Publicacion>();
    public string Nombre { get; set; }
    public string Direccion { get; set; }

    //Constructor de una biblioteca
    public Biblioteca(string nombre, string direccion)
    {
      Nombre = nombre;
      Direccion = direccion;
    }

    //Metodo para agregar una publicacion al listado de publicaciones
    public void AgregarPublicacion(Publicacion publicacion)
    {
      Publicaciones.Add(publicacion);
    }

    //Metodo para mostrar todas las publicaciones guardadas en la lista de publicaciones
    public void MostrarPublicaciones()
    {
      for (int i = 0; i < Publicaciones.Count; i++)
      {
        Publicaciones[i].MostrarInformacion();
      }
    }
  }
}