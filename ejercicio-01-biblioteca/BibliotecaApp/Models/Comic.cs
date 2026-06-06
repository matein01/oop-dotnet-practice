namespace BibliotecaApp
{
  public class Comic : Publicacion
  {
    //Atributo específico del cómic
    public string Heroe { get; set; }

    //Constructor del cómic heredando de Publicacion
    public Comic(string heroe, double costo, string tipo, string titulo, int anio, string isbn, int id) : base(titulo, anio, isbn, costo, tipo, id)
    {
      Heroe = heroe;
    }

    //Método heredado para mostrar la información del cómic
    public override void MostrarInformacion()
    {
      base.MostrarInformacion();
      Console.WriteLine($"El héroe del cómic es {Heroe}");
      Console.WriteLine($"----------------------------------------------------------------------------------------");
    }
  }
}