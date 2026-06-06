using BibliotecaApp.Models;

namespace BibliotecaApp
{
  public class BibliotecaMenu
  {
    //Objeto biblioteca para poder crear publicaciones
    Biblioteca biblioteca = new Biblioteca("Marichuela", "A dos cuadras de mi casa");
    //Objeto repositorio para acceder al CRUD y a la BD
    PublicacionRepositorio repositorio = new PublicacionRepositorio();

    //Método que controla el menú principal
    public void Iniciar()
    {
      //Continuar controla el fin del bucle
      bool continuar = true;
      //Op controla el flujo del switch
      int op = 0;

      //Bucle do while que funciona como menú
      do
      {
        //Menú del bucle
        Console.WriteLine("Este es el menú de la biblioteca");
        Console.WriteLine("Para crear una nueva publicación presiona 1");
        Console.WriteLine("Para mostrar las publicaciones presiona 2");
        Console.WriteLine("Para modificar una publicación presiona 3");
        Console.WriteLine("Para eliminar una publicación presiona 4");
        Console.WriteLine("Para salir presiona 5");

        //Se crea un try catch en caso de que el usuario no escriba números
        try
        {
          //Se convierte el string en un int para la variable op
          op = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
          Console.WriteLine("Por favor ingresa un número válido");
        }

        //Switch para navegar en el menú
        switch (op)
        {
          //Se llama el método CrearPublicacion
          case 1: CrearPublicacion(); break;
          //Se llama el método MostrarPublicaciones
          case 2: MostrarPublicaciones(); break;
          //Se llama el método ModificarPublicacion
          case 3: ModificarPublicacion(); break;
          //Se llama el método EliminarPublicacion
          case 4: EliminarPublicacion(); break;
          //Continuar pasa a false para terminar el bucle
          case 5: continuar = false; break;
          //Se busca capturar un error
          default: Console.WriteLine("Opción inválida"); break;
        }
      }
      while (continuar == true);
    }

    //Método para crear una nueva publicación
    public void CrearPublicacion()
    {
      //Objeto publicación vacío
      Publicacion? p = null;
      //Continuar controla el fin del bucle
      bool continuar = true;
      //Op controla el flujo del if
      int op = 0;

      //Submenú de publicación
      Console.WriteLine("Para crear una nueva revista presiona 1");
      Console.WriteLine("Para crear un nuevo libro presiona 2");
      Console.WriteLine("Para crear un nuevo cómic presiona 3");
      Console.WriteLine("Para crear un nuevo periódico presiona 4");

      //Se crea un bucle para asegurarse que el usuario elija una opción correcta
      do
      {
        //Se crea un try catch en caso de que el usuario no escriba números
        try
        {
          //Se convierte el string en un int para la variable op
          op = Convert.ToInt32(Console.ReadLine());

          //Si es una revista puede continuar
          if (op == 1)
          {
            //Con el método de la fábrica se crea una publicación del tipo revista
            p = PublicacionFactory.Crear("revista");

            //La variable continuar pasa a false para salir del bucle
            continuar = false;
          }
          //Si es un libro puede continuar
          else if (op == 2)
          {
            //Con el método de la fábrica se crea una publicación del tipo libro
            p = PublicacionFactory.Crear("libro");

            //La variable continuar pasa a false para salir del bucle
            continuar = false;
          }
          //Si es un cómic puede continuar
          else if (op == 3)
          {
            //Con el método de la fábrica se crea una publicación del tipo cómic
            p = PublicacionFactory.Crear("comic");

            //La variable continuar pasa a false para salir del bucle
            continuar = false;
          }
          //Si es un periódico puede continuar
          else if (op == 4)
          {
            //Con el método de la fábrica se crea una publicación del tipo periódico
            p = PublicacionFactory.Crear("periodico");

            //La variable continuar pasa a false para salir del bucle
            continuar = false;
          }
          else
          {
            //Mensaje de error
            Console.WriteLine("Opción inválida");
            //Submenú de publicación
            Console.WriteLine("Para crear una nueva revista presiona 1");
            Console.WriteLine("Para crear un nuevo libro presiona 2");
            Console.WriteLine("Para crear un nuevo cómic presiona 3");
            Console.WriteLine("Para crear un nuevo periódico presiona 4");
          }
        }
        catch (Exception e)
        {
          //Se pide ingresar un valor válido
          Console.WriteLine("Por favor ingresa un número válido");

          //Submenú de publicación
          Console.WriteLine("Para crear una nueva revista presiona 1");
          Console.WriteLine("Para crear un nuevo libro presiona 2");
          Console.WriteLine("Para crear un nuevo cómic presiona 3");
          Console.WriteLine("Para crear un nuevo periódico presiona 4");
        }
      }
      //Condición del bucle
      while (continuar == true);

      //Se busca saber si el objeto p es nulo
      if (p != null)
      {
        //Usando el método del objeto biblioteca y como parámetro el objeto p, se agrega la publicación en memoria
        biblioteca.AgregarPublicacion(p);

        //Se usa el método de repositorio para guardar la publicación en la base de datos
        repositorio.Guardar(p);
      }
    }

    //Método para mostrar todas las publicaciones de la base de datos
    public void MostrarPublicaciones()
    {
      //Se crea una lista de objetos tipo Publicacion, que tendrá la información de la BD
      List<Publicacion> lista = repositorio.ObtenerTodas();

      //Método para iterar, que se utiliza para mostrar la información guardada en lista
      foreach (Publicacion p in lista)
      {
        p.MostrarInformacion();
      }
    }

    //Método para modificar una publicación existente
    public void ModificarPublicacion()
    {
      //Objeto publicación vacío
      Publicacion? p = null;
      //Op controla el flujo del if
      int op = 0;
      //Se crea una variable idIngresado para utilizarla más adelante
      int idIngresado = 0;
      //Se pide el id para saber qué publicación modificar
      Console.WriteLine("Ingresa el id de la publicación a modificar");

      //Se declara una variable para manejar el bucle
      bool continuar = true;

      //Se crea un bucle para asegurarse que el usuario ingrese un número válido
      do
      {
        //Se crea un try catch en caso de que el usuario no escriba números
        try
        {
          //Se convierte el string en un int para la variable idIngresado
          idIngresado = Convert.ToInt32(Console.ReadLine());

          //La variable continuar pasa a false para salir del bucle
          continuar = false;
        }
        catch (Exception e)
        {
          //Se pide ingresar un valor válido
          Console.WriteLine("Por favor ingresa un número válido");
        }
      }
      //Condición del bucle
      while (continuar == true);

      //Se busca la publicación en la base de datos usando el id ingresado
      Publicacion? encontrada = repositorio.BuscarPorId(idIngresado);

      //Si no existe una publicación con ese id no se continúa con la modificación
      if (encontrada == null)
      {
        Console.WriteLine($"No existe una publicación con id {idIngresado}");

        //Se pone el return para salir del método
        return;
      }
      else
      {
        //Se muestra la información de la publicación en caso de que se encuentre
        encontrada.MostrarInformacion();
      }

      //Se pide el tipo de publicación a modificar
      Console.WriteLine("Si la publicación es una revista escriba 1, si es un libro escriba 2, si es un cómic escriba 3 y si es un periódico escriba 4");

      //Se declara una variable para manejar el bucle
      bool continuarDos = true;

      //Se crea un bucle para asegurarse que el usuario elija una opción correcta
      do
      {
        //Se crea un try catch en caso de que el usuario no escriba números
        try
        {
          //Se convierte el string en un int para la variable op
          op = Convert.ToInt32(Console.ReadLine());

          //Si es una revista puede continuar
          if (op == 1)
          {
            //Con el método de la fábrica se crea una publicación del tipo revista
            p = PublicacionFactory.Crear("revista");

            //La variable continuarDos pasa a false para salir del bucle
            continuarDos = false;
          }
          //Si es un libro puede continuar
          else if (op == 2)
          {
            //Con el método de la fábrica se crea una publicación del tipo libro
            p = PublicacionFactory.Crear("libro");

            //La variable continuarDos pasa a false para salir del bucle
            continuarDos = false;
          }
          //Si es un cómic puede continuar
          else if (op == 3)
          {
            //Con el método de la fábrica se crea una publicación del tipo cómic
            p = PublicacionFactory.Crear("comic");

            //La variable continuarDos pasa a false para salir del bucle
            continuarDos = false;
          }
          //Si es un periódico puede continuar
          else if (op == 4)
          {
            //Con el método de la fábrica se crea una publicación del tipo periódico
            p = PublicacionFactory.Crear("periodico");

            //La variable continuarDos pasa a false para salir del bucle
            continuarDos = false;
          }
          else
          {
            //Mensaje de error
            Console.WriteLine("Opción inválida");
            //Submenú de publicación
            Console.WriteLine("Para modificar una revista presiona 1");
            Console.WriteLine("Para modificar un libro presiona 2");
            Console.WriteLine("Para modificar un cómic presiona 3");
            Console.WriteLine("Para modificar un periódico presiona 4");
          }
        }
        catch (Exception e)
        {
          //Se pide ingresar un valor válido
          Console.WriteLine("Por favor ingresa un número válido");
          //Submenú de publicación
          Console.WriteLine("Para modificar una revista presiona 1");
          Console.WriteLine("Para modificar un libro presiona 2");
          Console.WriteLine("Para modificar un cómic presiona 3");
          Console.WriteLine("Para modificar un periódico presiona 4");
        }
      }
      //Condición del bucle
      while (continuarDos == true);

      //Se busca saber si el objeto p es nulo
      if (p != null)
      {
        //Se le agrega el id ingresado al objeto creado
        p.Id = idIngresado;

        //Se usa el método de repositorio para actualizar la publicación en la base de datos
        repositorio.Actualizar(p);
      }
    }

    //Método para eliminar una publicación existente
    public void EliminarPublicacion()
    {
      //Variable para guardar el id ingresado por el usuario
      int idIngresado = 0;
      //Se pide el id de la publicación a eliminar
      Console.WriteLine("Ingresa el id de la publicación a eliminar");

      //Variable para controlar el bucle
      bool continuar = true;

      //Se crea un bucle para asegurarse que el usuario ingrese un número válido
      do
      {
        //Se crea un try catch en caso de que el usuario no escriba números
        try
        {
          //Se convierte el string en un int para la variable idIngresado
          idIngresado = Convert.ToInt32(Console.ReadLine());

          //La variable continuar pasa a false para salir del bucle
          continuar = false;
        }
        catch (Exception e)
        {
          //Se pide ingresar un valor válido
          Console.WriteLine("Por favor ingresa un número válido");
        }
      }
      //Condición del bucle
      while (continuar == true);

      //Se busca la publicación en la base de datos usando el id ingresado
      Publicacion? encontrada = repositorio.BuscarPorId(idIngresado);

      //Si no existe una publicación con ese id no se continúa con la eliminación
      if (encontrada == null)
      {
        Console.WriteLine($"No existe una publicación con id {idIngresado}");

        //Return para salir del método
        return;
      }
      else
      {
        //Se envía el id al método Eliminar para que sepa qué publicación eliminar
        repositorio.Eliminar(idIngresado);
      }
    }
  }
}