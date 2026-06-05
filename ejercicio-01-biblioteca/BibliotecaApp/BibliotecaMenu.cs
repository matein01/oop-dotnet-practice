using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaApp.Models;

namespace BibliotecaApp
{
  public class BibliotecaMenu
  {
    //Objeto biblioteca para poder crear publicaciones
    Biblioteca biblioteca = new Biblioteca("Marichuela", "A dos cuadras de mi casa");
    //Objeto repositorio para acceder al CRUD y a la BD
    PublicacionRepositorio repositorio = new PublicacionRepositorio();

    //Metodo que controla el menu
    public void Iniciar()
    {
      //Continuar controla el fin del bucle
      bool continuar = true;
      //Op controla el flujo del switch
      int op = 0;

      //Bucle do while que funciona como menu
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

        //Switch para navegar en el menu
        switch (op)
        {
          //Se llama el metodo CrearPublicacion
          case 1: CrearPublicacion(); break;
          //Se llama el metodo MostrarPublicaciones
          case 2: MostrarPublicaciones(); break;
          //Se llama el metodo ModificarPublicacion
          case 3: ModificarPublicacion(); break;
          //Se llama el metodo EliminarPublicacion
          case 4: EliminarPublicacion(); break;
          //Continuar pasa a false para terminar el bucle
          case 5: continuar = false; break;
          //Se busca capturar un error
          default: Console.WriteLine("Opción inválida"); break;
        }
      }
      while (continuar == true);
    }
    public void CrearPublicacion()
    {
      //Objeto publicacion vacio
      Publicacion? p = null;
      //Continuar controla el fin del bucle
      bool continuar = true;
      //Op controla el flujo del switch
      int op = 0;

      //Submenú de publicación
      Console.WriteLine("Para crear una nueva revista presiona 1");
      Console.WriteLine("Para crear un nuevo libro presiona 2");

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
            //Con el método del objeto p se crea una publicación del tipo revista
            p = PublicacionFactory.Crear("revista");

            //La variable continuarDos pasa a false para salir del bucle
            continuar = false;
          }
          //Si es un libro puede continuar
          else if (op == 2)
          {
            //Con el método del objeto p se crea una publicación del tipo libro
            p = PublicacionFactory.Crear("libro");

            //La variable continuarDos pasa a false para salir del bucle
            continuar = false;
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
      while (continuar == true);

      //Se busca saber si el objeto p es nulo
      if (p != null)
      {
        //Usando el método del objeto biblioteca y como parámetro el objeto p, se crea una publicación nueva
        biblioteca.AgregarPublicacion(p);

        //Se usa el método de repositorio para guardar la publicación en una base de datos
        repositorio.Guardar(p);
      }
    }
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
    //Metodo para modificar publicaciones
    public void ModificarPublicacion()
    {
      //Objeto publicacion vacio
      Publicacion? p = null;
      //Op controla el flujo del switch
      int op = 0;
      //Se crea una variable idIngresado para utilizarla mas adelante
      int idIngresado = 0;
      //Se pide el id para saber qué publicación modificar
      Console.WriteLine("Ingresa el id de la publicación a modificar");

      //Se declara una variable para manejar el bucle
      bool continuar = true;

      //Se crea un bucle para asegurarse que el usuario elija una opción correcta
      do
      {
        //Se crea un try catch en caso de que el usuario no escriba números
        try
        {
          //Se convierte el string en un int para la variable idIngresado
          idIngresado = Convert.ToInt32(Console.ReadLine());

          //La variable continuarTres pasa a false para salir del bucle
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

      //Se crea un objeto publicacion para usar el método de buscar por id
      Publicacion? encontrada = repositorio.BuscarPorId(idIngresado);

      //Si no existe una publicación con ese id no se continúa con la modificación
      if (encontrada == null)
      {
        Console.WriteLine($"No existe una publicación con id {idIngresado}");

        //Se pone el return para salir del metodo
        return;
      }
      else
      {
        //Se muestra la información de la publicación en caso de que se encuentre
        encontrada.MostrarInformacion();
      }
      //Se pide el tipo de publicación a modificar
      Console.WriteLine("Si la publicación es una revista escriba 1, si es un libro escriba 2");

      //Se declara una variable para manejar el bucle
      bool continuarDos = true;

      //Se crea un bucle para asegurarse que el usuario elija una opción correcta
      do
      {
        //Se crea un try catch en caso de que el usuario no escriba números
        try
        {
          //Se convierte el string en un int para la variable opTres
          op = Convert.ToInt32(Console.ReadLine());

          //Si es una revista puede continuar
          if (op == 1)
          {
            //Con el método del objeto p se crea una publicación del tipo revista
            p = PublicacionFactory.Crear("revista");

            //La variable continuarCuatro pasa a false para salir del bucle
            continuarDos = false;
          }
          //Si es un libro puede continuar
          else if (op == 2)
          {
            //Con el método del objeto p se crea una publicación del tipo libro
            p = PublicacionFactory.Crear("libro");

            //La variable continuarCuatro pasa a false para salir del bucle
            continuarDos = false;
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
      while (continuarDos == true);

      //Se busca saber si el objeto p es nulo
      if (p != null)
      {
        //Se le agrega el id ingresado al objeto creado
        p.Id = idIngresado;

        //Se usa el método de repositorio para guardar la publicación en una base de datos
        repositorio.Actualizar(p);
      }
    }
    public void EliminarPublicacion()
    {
      //Se crea la variable idIngresadoDos, para guardar la información ingresada por el usuario
      int idIngresado = 0;
      //Se pide el id de la publicación a eliminar
      Console.WriteLine("Ingresa el id de la publicación a eliminar");

      //Variable para controlar el bucle
      bool continuar = true;

      //Se crea un bucle para asegurarse que el usuario elija una opción correcta
      do
      {
        //Se crea un try catch en caso de que el usuario no escriba números
        try
        {
          //Se convierte el string en un int para la variable idIngresadoDos
          idIngresado = Convert.ToInt32(Console.ReadLine());

          //La variable continuarCinco pasa a false para salir del bucle
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

      //Se crea un objeto publicacion para usar el método de buscar por id
      Publicacion? encontrada = repositorio.BuscarPorId(idIngresado);

      //Si no existe una publicación con ese id no se continúa con la eliminación
      if (encontrada == null)
      {
        Console.WriteLine($"No existe una publicación con id {idIngresado}");

        //Return para salir del metodo
        return;
      }
      else
      {
        //Se envía el id al método eliminar para que sepa qué publicación eliminar
        repositorio.Eliminar(idIngresado);
      }
    }
  }
}