namespace BibliotecaApp
{
  public class Periodico : Publicacion
  {
    //Atributo específico del periódico
    public string Noticia { get; set; }

    //Constructor del periódico heredando de Publicacion
    public Periodico(string noticia, double costo, string tipo, string titulo, int anio, string isbn, int id) : base(titulo, anio, isbn, costo, tipo, id)
    {
      Noticia = noticia;
    }

    //Método heredado para mostrar la información del periódico
    public override void MostrarInformacion()
    {
      base.MostrarInformacion();
      Console.WriteLine($"La noticia principal del periódico es {Noticia}");
      Console.WriteLine($"----------------------------------------------------------------------------------------");
    }
  }
}