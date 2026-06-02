namespace BibliotecaApp
{
  public class Biblioteca
  {
    private List<Publicacion> Publicaciones = new List<Publicacion>();
    public string Nombre { get; set; }
    public string Direccion { get; set; }

    public Biblioteca(string nombre, string direccion)
    {
      Nombre = nombre;
      Direccion = direccion;
    }

    public void AgregarPublicacion(Publicacion publicacion)
    {
      Publicaciones.Add(publicacion);
    }

    public void MostrarPublicaciones()
    {
      for (int i = 0; i < Publicaciones.Count; i++)
      {
        Publicaciones[i].MostrarInformacion();
      }
    }
  }
}