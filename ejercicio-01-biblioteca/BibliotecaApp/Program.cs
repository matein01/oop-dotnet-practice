using BibliotecaApp.Models;

namespace BibliotecaApp
{
  class Program
  {
    static void Main(string[] args)
    {
      //Variables, continuar es para detener el while y op es para navegar en el switch
      bool continuar = true;
      int op;
      //Se crea un objeto del tipo biblioteca para utilizar los metodos de biblioteca
      Biblioteca biblioteca = new Biblioteca("Biblioteca central", "Calle 123");
      //Se crea un objeto de publicacion basio para usarlo despues dentro de los if
      Publicacion? p = null;

      //Empieza el bucle
      do
      {
        //Menu del bucle
        Console.WriteLine("Este es el menu de la biblioteca");
        Console.WriteLine("Para crear una nueva publicacion preciona 1");
        Console.WriteLine("Para mostrar las publicaciones preciona 2");
        Console.WriteLine("Para modificar una publicacion preciona 3");
        Console.WriteLine("Para salir preciona 4");

        //Se convierte el string en un int para la variable op
        op = Convert.ToInt32(Console.ReadLine());

        //Empieza el switch
        switch (op)
        {
          case 1:
            //Sub menu de publicacion
            Console.WriteLine("Para crear una nueva revista preciona 1");
            Console.WriteLine("Para crear un nuevo libro preciona 2");

            //Se convierte el string en un int para la variable op
            op = Convert.ToInt32(Console.ReadLine());

            //Se quiere saber si la publicacion es una revista
            if (op == 1)
            {
              //Con el metodo del objeto p se crea una publicacion del tipo revista
              p = PublicacionFactory.Crear("revista");
            }
            //Se quiere saber si la publicacion es un libro
            else if (op == 2)
            {
              //Con el metodo del objeto p se crea una publicacion del tipo libro
              p = PublicacionFactory.Crear("libro");
            }
            //Se busca atrapar un error
            else
            {
              //Se busca atrapar un error
              Console.WriteLine("Opcion no valida");
            }
            //Se busca saber si el objeto p es nulo
            if (p != null)
            {
              //Usando el metodo del objeto biblioteca y como parametor el objeto p, se crea una publicacion nueva
              biblioteca.AgregarPublicacion(p);

              //Se crera un objeto del tipo PublicacionRepositorio
              PublicacionRepositorio repositorio = new PublicacionRepositorio();

              //Se usa el metodo de repositorio para guardar la publicacion en una base de datos
              repositorio.Guardar(p);
            }
            break;
          case 2:
            //Se crea un objeto de PublicacionRepositorio que va a tener el metodo para traer la informacion de la BD
            PublicacionRepositorio repositoriom = new PublicacionRepositorio();

            //Se crea una lista de objetos tipo Publicacion, que tendra la infromacion de la BD
            List<Publicacion> lista = repositoriom.ObtenerTodas();

            //Metodo para iterar que se utiliza para mostrar la informacion guardada en lista
            foreach (Publicacion ps in lista)
            {
              ps.MostrarInformacion();
            }
            break;
          case 3:
            //Se pide el tipo de publicacion a modificar
            Console.WriteLine("Para modificar una revista escriba 1, para modificar un libro escriba 2");

            //Se convierte el string en un int para la variable op
            op = Convert.ToInt32(Console.ReadLine());

            //Se pide el id para saber que publicacion modificar
            Console.WriteLine("Ingresar el id de la publicacion a modificar");
            int idIngresado = Convert.ToInt32(Console.ReadLine());

            //Si es un libro se crea una publicacion de tipo libro
            if (op == 1)
            {
              p = PublicacionFactory.Crear("revista");
            }
            //Si es una revista se crea una publicacion de tipo revista
            else if (op == 2)
            {
              p = PublicacionFactory.Crear("libro");
            }
            //Se busca atrapar un error
            else
            {
              //Se busca atrapar un error
              Console.WriteLine("Opcion no valida");
            }
            //Se busca saber si el objeto p es nulo
            if (p != null)
            {
              //Se le agrega el id ingresado al objeto creado
              p.Id = idIngresado;
              //Se crera un objeto del tipo PublicacionRepositorio
              PublicacionRepositorio repositorio = new PublicacionRepositorio();

              //Se usa el metodo de repositorio para guardar la publicacion en una base de datos
              repositorio.Actualizar(p);
            }
            break;
          case 4:
            //Mensaje interactivo para el usuario
            Console.WriteLine("Saliendo del programa");
            //La variable continuar cambia a false para cerrar el bucle del while
            continuar = false;
            break;
          default:
            //Se busca capturar un error
            Console.WriteLine("Esa opcion no esta en la lista");
            break;
        }
        //Si el continuar es true continua y si no finaliza
      } while (continuar == true);
    }
  }
}