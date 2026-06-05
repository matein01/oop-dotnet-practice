using BibliotecaApp.Models;

namespace BibliotecaApp
{
  class Program
  {
    static void Main(string[] args)
    {
      //Variables, continuar es para detener el while, op es para navegar en el switch y id para eliminar publicaciones
      bool continuar = true;
      int op = 0;
      int opDos;
      int opTres;
      int id;
      //Se crea un objeto del tipo biblioteca para utilizar los métodos de biblioteca
      Biblioteca biblioteca = new Biblioteca("Biblioteca central", "Calle 123");
      //Se crea un objeto de publicacion básico para usarlo después dentro de los if
      Publicacion? p = null;

      //Empieza el bucle
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

        //Empieza el switch
        switch (op)
        {
          case 1:
            //Submenú de publicación
            Console.WriteLine("Para crear una nueva revista presiona 1");
            Console.WriteLine("Para crear un nuevo libro presiona 2");

            //Se declara una variable para manejar el bucle
            bool continuarDos = true;

            //Se crea un bucle para asegurarse que el usuario elija una opción correcta
            do
            {
              //Se crea un try catch en caso de que el usuario no escriba números
              try
              {
                //Se convierte el string en un int para la variable op
                opDos = Convert.ToInt32(Console.ReadLine());

                //Si es una revista puede continuar
                if (opDos == 1)
                {
                  //Con el método del objeto p se crea una publicación del tipo revista
                  p = PublicacionFactory.Crear("revista");

                  //La variable continuarDos pasa a false para salir del bucle
                  continuarDos = false;
                }
                //Si es un libro puede continuar
                else if (opDos == 2)
                {
                  //Con el método del objeto p se crea una publicación del tipo libro
                  p = PublicacionFactory.Crear("libro");

                  //La variable continuarDos pasa a false para salir del bucle
                  continuarDos = false;
                }
                else
                {
                  //Mensaje de error
                  Console.WriteLine("Opción inválida");
                  //Submenú de publicación
                  Console.WriteLine("Para crear una nueva revista presiona 1");
                  Console.WriteLine("Para crear un nuevo libro presiona 2");
                }
              }
              catch (Exception e)
              {
                //Se pide ingresar un valor válido
                Console.WriteLine("Por favor ingresa un número válido");

                //Submenú de publicación
                Console.WriteLine("Para crear una nueva revista presiona 1");
                Console.WriteLine("Para crear un nuevo libro presiona 2");
              }
            }
            //Condición del bucle
            while (continuarDos == true);

            //Se busca saber si el objeto p es nulo
            if (p != null)
            {
              //Usando el método del objeto biblioteca y como parámetro el objeto p, se crea una publicación nueva
              biblioteca.AgregarPublicacion(p);

              //Se crea un objeto del tipo PublicacionRepositorio
              PublicacionRepositorio repositorioUno = new PublicacionRepositorio();

              //Se usa el método de repositorio para guardar la publicación en una base de datos
              repositorioUno.Guardar(p);
            }
            break;
          case 2:
            //Se crea un objeto de PublicacionRepositorio que va a tener el método para traer la información de la BD
            PublicacionRepositorio repositorioDos = new PublicacionRepositorio();

            //Se crea una lista de objetos tipo Publicacion, que tendrá la información de la BD
            List<Publicacion> lista = repositorioDos.ObtenerTodas();

            //Método para iterar, que se utiliza para mostrar la información guardada en lista
            foreach (Publicacion ps in lista)
            {
              ps.MostrarInformacion();
            }
            break;
          case 3:
            int idIngresado = 0;
            //Se pide el id para saber qué publicación modificar
            Console.WriteLine("Ingresa el id de la publicación a modificar");

            //Se declara una variable para manejar el bucle
            bool continuarTres = true;

            //Se crea un bucle para asegurarse que el usuario elija una opción correcta
            do
            {
              //Se crea un try catch en caso de que el usuario no escriba números
              try
              {
                //Se convierte el string en un int para la variable idIngresado
                idIngresado = Convert.ToInt32(Console.ReadLine());

                //La variable continuarTres pasa a false para salir del bucle
                continuarTres = false;
              }
              catch (Exception e)
              {
                //Se pide ingresar un valor válido
                Console.WriteLine("Por favor ingresa un número válido");
              }
            }
            //Condición del bucle
            while (continuarTres == true);

            //Se crea un objeto PublicacionRepositorio para usar el método de buscar por id
            PublicacionRepositorio repositorioTres = new PublicacionRepositorio();
            Publicacion? encontrada = repositorioTres.BuscarPorId(idIngresado);

            //Si no existe una publicación con ese id no se continúa con la modificación
            if (encontrada == null)
            {
              Console.WriteLine($"No existe una publicación con id {idIngresado}");

              break;
            }
            else
            {
              //Se muestra la información de la publicación en caso de que se encuentre
              encontrada.MostrarInformacion();
            }

            //Se pide el tipo de publicación a modificar
            Console.WriteLine("Si la publicación es una revista escriba 1, si es un libro escriba 2");

            //Se declara una variable para manejar el bucle
            bool continuarCuatro = true;

            //Se crea un bucle para asegurarse que el usuario elija una opción correcta
            do
            {
              //Se crea un try catch en caso de que el usuario no escriba números
              try
              {
                //Se convierte el string en un int para la variable opTres
                opTres = Convert.ToInt32(Console.ReadLine());

                //Si es una revista puede continuar
                if (opTres == 1)
                {
                  //Con el método del objeto p se crea una publicación del tipo revista
                  p = PublicacionFactory.Crear("revista");

                  //La variable continuarCuatro pasa a false para salir del bucle
                  continuarCuatro = false;
                }
                //Si es un libro puede continuar
                else if (opTres == 2)
                {
                  //Con el método del objeto p se crea una publicación del tipo libro
                  p = PublicacionFactory.Crear("libro");

                  //La variable continuarCuatro pasa a false para salir del bucle
                  continuarCuatro = false;
                }
                else
                {
                  //Mensaje de error
                  Console.WriteLine("Opción inválida");
                  //Submenú de publicación
                  Console.WriteLine("Para modificar una revista presiona 1");
                  Console.WriteLine("Para modificar un libro presiona 2");
                }
              }
              catch (Exception e)
              {
                //Se pide ingresar un valor válido
                Console.WriteLine("Por favor ingresa un número válido");

                //Submenú de publicación
                Console.WriteLine("Para modificar una revista presiona 1");
                Console.WriteLine("Para modificar un libro presiona 2");
              }
            }
            //Condición del bucle
            while (continuarCuatro == true);

            //Se busca saber si el objeto p es nulo
            if (p != null)
            {
              //Se le agrega el id ingresado al objeto creado
              p.Id = idIngresado;

              //Se crea un objeto del tipo PublicacionRepositorio
              PublicacionRepositorio repositorioTresDos = new PublicacionRepositorio();

              //Se usa el método de repositorio para guardar la publicación en una base de datos
              repositorioTresDos.Actualizar(p);
            }
            break;
          case 4:
            //Se crea la variable idIngresadoDos, para guardar la información ingresada por el usuario
            int idIngresadoDos = 0;
            //Se pide el id de la publicación a eliminar
            Console.WriteLine("Ingresa el id de la publicación a eliminar");

            //Variable para controlar el bucle
            bool continuarCinco = true;

            //Se crea un bucle para asegurarse que el usuario elija una opción correcta
            do
            {
              //Se crea un try catch en caso de que el usuario no escriba números
              try
              {
                //Se convierte el string en un int para la variable idIngresadoDos
                idIngresadoDos = Convert.ToInt32(Console.ReadLine());

                //La variable continuarCinco pasa a false para salir del bucle
                continuarCinco = false;
              }
              catch (Exception e)
              {
                //Se pide ingresar un valor válido
                Console.WriteLine("Por favor ingresa un número válido");
              }
            }
            //Condición del bucle
            while (continuarCinco == true);

            //Se crea un objeto PublicacionRepositorio para usar el método de buscar por id
            PublicacionRepositorio repositorioCuatro = new PublicacionRepositorio();
            Publicacion? encontradaDos = repositorioCuatro.BuscarPorId(idIngresadoDos);

            //Si no existe una publicación con ese id no se continúa con la eliminación
            if (encontradaDos == null)
            {
              Console.WriteLine($"No existe una publicación con id {idIngresadoDos}");

              break;
            }
            else
            {
              //Se envía el id al método eliminar para que sepa qué publicación eliminar
              repositorioCuatro.Eliminar(idIngresadoDos);
            }
            break;
          case 5:
            //Mensaje interactivo para el usuario
            Console.WriteLine("Saliendo del programa");
            //La variable continuar cambia a false para cerrar el bucle del while
            continuar = false;
            break;
          default:
            //Se busca capturar un error
            Console.WriteLine("Esa opción no está en la lista");
            break;
        }
        //Si el continuar es true continúa y si no finaliza
      } while (continuar == true);
    }
  }
}