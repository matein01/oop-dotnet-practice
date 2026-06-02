namespace BibliotecaApp
{
  public class PublicacionFactory
  {
    public static Publicacion? Crear(string tipo)
    {
      string tipoo;
      string input;
      string titulo;
      int anio;
      string isbn;
      double costo;
      int pagina;
      string autor;

      //Se pide el titulo
      Console.WriteLine("Escribe el titulo");
      titulo = Console.ReadLine();

      //Se pide el isbn
      Console.WriteLine($"Escribe el isbn de {titulo}");
      isbn = Console.ReadLine();

      //Se pide el año de publicacion y se asegura que sea del tipo int
      Console.WriteLine($"Escribe el año de publicacion de {titulo}");
      input = Console.ReadLine();
      if (input != null && input.Trim() != "")
      {
        anio = int.Parse(input);
      }
      else
      {
        anio = 0;
      }

      //Se pide el costo y se asegura que sea del tipo double
      Console.WriteLine($"Escribe el costo en dolares de {titulo}");
      input = Console.ReadLine();
      if (input != null && input.Trim() != "")
      {
        costo = double.Parse(input);
      }
      else
      {
        costo = 0;
      }

      if (tipo == "libro")
      {
        //Se pide el tipo del libro
        Console.WriteLine($"Escribe el tipo de libro que es {titulo}");
        tipoo = Console.ReadLine();

        //Se pide el autor
        Console.WriteLine($"Escribe el nombre del autor de {titulo}");
        autor = Console.ReadLine();

        Libro libro = new Libro(autor, costo, tipoo, titulo, anio, isbn);
        return libro;

      }
      else if (tipo == "revista")
      {
        //Se pide el tipo de la revista
        Console.WriteLine($"Escribe el tipo de la revista que es{titulo}");
        tipoo = Console.ReadLine();

        //Se pide la cantidad de paginas y se asegura que sea del tipo int
        Console.WriteLine($"Escribe la cantidad de paginas de {titulo}");
        input = Console.ReadLine();
        if (input != null && input.Trim() != "")
        {
          pagina = int.Parse(input);
        }
        else
        {
          pagina = 0;
        }

        Revista revista = new Revista(pagina, costo, tipoo, titulo, anio, isbn);
        return revista;
      }
      return null;
    }
  }
}