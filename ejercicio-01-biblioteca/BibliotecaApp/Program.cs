namespace BibliotecaApp
{
  class Program
  {
    static void Main(string[] args)
    {
      bool continuar = true;
      int op;
      Biblioteca biblioteca = new Biblioteca("Biblioteca central", "Calle 123");

      do
      {
        Console.WriteLine("Este es el menu de la biblioteca");
        Console.WriteLine("Para crear una nueva publicacion preciona 1");
        Console.WriteLine("Para mostrar las publicaciones preciona 2");
        Console.WriteLine("Para salir preciona 3");

        op = Convert.ToInt32(Console.ReadLine());
        switch (op)
        {
          case 1:
            Publicacion? p = null;
            
            Console.WriteLine("Para crear una nueva revista preciona 1");
            Console.WriteLine("Para crear un nuevo libro preciona 2");
            op = Convert.ToInt32(Console.ReadLine());

            if (op == 1)
            {
              p = PublicacionFactory.Crear("revista");
            }
            else if (op == 2)
            {
              p = PublicacionFactory.Crear("libro");
            }
            else
            {
              Console.WriteLine("Opcion no valida");
            }
            if (p != null)
            {
              biblioteca.AgregarPublicacion(p);
            }
            break;
          case 2:
            biblioteca.MostrarPublicaciones();
            break;
          case 3:
            Console.WriteLine("Saliendo del programa");
            continuar = false;
            break;
          default:
            Console.WriteLine("Esa opcion no esta en la lista");
            break;
        }
      } while (continuar == true);
    }
  }
}