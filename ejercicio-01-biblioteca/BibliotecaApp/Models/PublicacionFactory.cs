namespace BibliotecaApp
{
  public class PublicacionFactory
  {
    private static Dictionary<string, Func<Publicacion>> creadores = new Dictionary<string, Func<Publicacion>>
    {
      {"revista", CrearRevista},
      {"libro", CrearLibro},
      {"comic", CrearComic},
      {"periodico", CrearPeriodico}
    };
    public static Publicacion? Crear(string tipo)
    {
      if (creadores.ContainsKey(tipo))
      {
        return creadores[tipo]();
      }

      //Se retorna null si el tipo no es válido
      return null;
    }
    private static Publicacion? CrearRevista()
    {
      //Variables para crear una publicación, un libro, una revista, un cómic o un periódico
      string input;
      string titulo;
      int anio;
      string isbn;
      double costo;
      int paginas;
      int id = 0;
      string tipo = "revista";

      //Se pide el título
      Console.WriteLine("Escribe el título");
      titulo = Console.ReadLine();

      //Se pide el ISBN
      Console.WriteLine($"Escribe el ISBN de {titulo}");
      isbn = Console.ReadLine();

      //Se pide el año de publicación y se asegura que sea del tipo int
      Console.WriteLine($"Escribe el año de publicación de {titulo}");
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
      Console.WriteLine($"Escribe el costo en dólares de {titulo}");
      input = Console.ReadLine();
      if (input != null && input.Trim() != "")
      {
        costo = double.Parse(input);
      }
      else
      {
        costo = 0;
      }

      //Se pide la cantidad de páginas y se asegura que sea del tipo int
      Console.WriteLine($"Escribe la cantidad de páginas de {titulo}");
      input = Console.ReadLine();

      if (input != null && input.Trim() != "")
      {
        paginas = int.Parse(input);
      }
      else
      {
        paginas = 0;
      }

      //Se crea la revista pasándole las variables solicitadas
      Revista revista = new Revista(paginas, costo, tipo, titulo, anio, isbn, id);
      //Se retorna la revista
      return revista;
    }

    private static Publicacion? CrearLibro()
    {
      //Variables para crear una publicación, un libro, una revista, un cómic o un periódico
      string input;
      string titulo;
      int anio;
      string isbn;
      double costo;
      string autor;
      int id = 0;
      string tipo = "libro";

      //Se pide el título
      Console.WriteLine("Escribe el título");
      titulo = Console.ReadLine();

      //Se pide el ISBN
      Console.WriteLine($"Escribe el ISBN de {titulo}");
      isbn = Console.ReadLine();

      //Se pide el año de publicación y se asegura que sea del tipo int
      Console.WriteLine($"Escribe el año de publicación de {titulo}");
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
      Console.WriteLine($"Escribe el costo en dólares de {titulo}");
      input = Console.ReadLine();
      if (input != null && input.Trim() != "")
      {
        costo = double.Parse(input);
      }
      else
      {
        costo = 0;
      }

      //Se pide el autor del libro
      Console.WriteLine($"Escribe el nombre del autor de {titulo}");
      autor = Console.ReadLine();

      //Se crea el libro pasándole las variables solicitadas
      Libro libro = new Libro(autor, costo, tipo, titulo, anio, isbn, id);
      //Se retorna el libro
      return libro;
    }

    private static Publicacion? CrearComic()
    {
      //Variables para crear una publicación, un libro, una revista, un cómic o un periódico
      string input;
      string titulo;
      int anio;
      string isbn;
      double costo;
      string heroe;
      int id = 0;
      string tipo = "comic";

      //Se pide el título
      Console.WriteLine("Escribe el título");
      titulo = Console.ReadLine();

      //Se pide el ISBN
      Console.WriteLine($"Escribe el ISBN de {titulo}");
      isbn = Console.ReadLine();

      //Se pide el año de publicación y se asegura que sea del tipo int
      Console.WriteLine($"Escribe el año de publicación de {titulo}");
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
      Console.WriteLine($"Escribe el costo en dólares de {titulo}");
      input = Console.ReadLine();
      if (input != null && input.Trim() != "")
      {
        costo = double.Parse(input);
      }
      else
      {
        costo = 0;
      }

      //Se pide el héroe que aparece en el cómic
      Console.WriteLine($"Escribe el héroe que aparece en {titulo}");
      heroe = Console.ReadLine();

      //Se crea el cómic pasándole las variables solicitadas
      Comic comic = new Comic(heroe, costo, tipo, titulo, anio, isbn, id);
      //Se retorna el cómic
      return comic;
    }

    private static Publicacion? CrearPeriodico()
    {
      //Variables para crear una publicación, un libro, una revista, un cómic o un periódico
      string input;
      string titulo;
      int anio;
      string isbn;
      double costo;
      string noticia;
      int id = 0;
      string tipo = "periodico";

      //Se pide el título
      Console.WriteLine("Escribe el título");
      titulo = Console.ReadLine();

      //Se pide el ISBN
      Console.WriteLine($"Escribe el ISBN de {titulo}");
      isbn = Console.ReadLine();

      //Se pide el año de publicación y se asegura que sea del tipo int
      Console.WriteLine($"Escribe el año de publicación de {titulo}");
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
      Console.WriteLine($"Escribe el costo en dólares de {titulo}");
      input = Console.ReadLine();
      if (input != null && input.Trim() != "")
      {
        costo = double.Parse(input);
      }
      else
      {
        costo = 0;
      }

      //Se pide la noticia principal del periódico
      Console.WriteLine($"Escribe la noticia principal de {titulo}");
      noticia = Console.ReadLine();

      //Se crea el periódico pasándole las variables solicitadas
      Periodico periodico = new Periodico(noticia, costo, tipo, titulo, anio, isbn, id);
      //Se retorna el periódico
      return periodico;
    }
  }
}