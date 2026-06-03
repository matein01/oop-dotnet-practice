using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BibliotecaApp.Models
{
  public class PublicacionRepositorio
  {
    //Metodo para insertar informacion en la base de datos
    public void Guardar(Publicacion publicacion)
    {
      using (SqlConnection con = ConexionDB.ObtenerConexion())
      {
        //Se abre la conexion
        con.Open();

        //Se crea el query que va al SQL
        SqlCommand cmd = new SqlCommand("INSERT INTO Publicaciones (Titulo, Anio, ISBN, Costo, Tipo) VALUES (@titulo, @anio, @isbn, @costo, @tipo); SELECT SCOPE_IDENTITY();", con);

        //Se escriben los AddWithValue para poder pasar paramatros y no strings
        cmd.Parameters.AddWithValue("@titulo", publicacion.Titulo);
        cmd.Parameters.AddWithValue("@anio", publicacion.Anio);
        cmd.Parameters.AddWithValue("@isbn", publicacion.ISBN);
        cmd.Parameters.AddWithValue("@costo", publicacion.Costo);
        cmd.Parameters.AddWithValue("@tipo", publicacion.Tipo);

        //Para tomar el resultado del query y convertirlo a int
        int id = Convert.ToInt32(cmd.ExecuteScalar());

        //Saber si la publicacion es un libro
        if (publicacion is Libro libro)
        {
          //Query para Libros
          SqlCommand cmdl = new SqlCommand("INSERT INTO Libros (Id, Autor) VALUES (@id, @autor)", con);

          //Los AddWithValue de Libros
          cmdl.Parameters.AddWithValue("@id", id);
          cmdl.Parameters.AddWithValue("@autor", libro.Autor);

          //Se ejecuta el query y no se espera ninguna respuesta
          cmdl.ExecuteNonQuery();
        }
        //Saber si la publicacion es una revista
        else if (publicacion is Revista revista)
        {
          //Query para Revistas
          SqlCommand cmdr = new SqlCommand("INSERT INTO Revistas (Id, Paginas) VALUES (@id, @paginas)", con);

          //Los AddWithValue de Revistas
          cmdr.Parameters.AddWithValue("@id", id);
          cmdr.Parameters.AddWithValue("@paginas", revista.Paginas);

          //Se ejecuta el query y no se espera ninguna respuesta
          cmdr.ExecuteNonQuery();
        }
      }
    }
    //Metodo para traer informacion de la base de datos
    public List<Publicacion> ObtenerTodas()
    {
      //Se crea una lista vacia
      List<Publicacion> lstpublicaciones = new List<Publicacion>();

      using (SqlConnection con = ConexionDB.ObtenerConexion())
      {
        //Se abre la coneccion
        con.Open();

        //Query para traer informacion
        SqlCommand cmd = new SqlCommand("SELECT p.Id, p.Titulo, p.Anio, p.ISBN, p.Costo, p.Tipo, l.Autor, r.Paginas FROM Publicaciones p LEFT JOIN Libros l ON p.Id = l.Id LEFT JOIN Revistas r ON p.Id = r.ID", con);

        //Se crea un objeto del tipo SqlDataReader para poder leer las columnas que se obtengan de la BD
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
          //Primero se obtiene el tipo de publicacion para crear el objeto correto
          string tipo = reader["Tipo"].ToString();

          //Saber si es de tipo libro
          if (tipo == "libro")
          {
            //Se guarda el valor de las columnas de la BD en variables para crear el objeto
            string autor = reader["Autor"].ToString();
            double costo = Convert.ToDouble(reader["Costo"]);
            string tipoo = reader["Tipo"].ToString();
            string titulo = reader["Titulo"].ToString();
            int anio = Convert.ToInt32(reader["Anio"]);
            string isbn = reader["ISBN"].ToString();

            //Se crea el objeto
            Libro libro = new Libro(autor, costo, tipoo, titulo, anio, isbn);

            //Se agrea el objeto en la lista que ya no esta vacia
            lstpublicaciones.Add(libro);
          }
          else if (tipo == "revista")
          {
            //Se guarda el valor de las columnas de la BD en variables para crear el objeto
            int paginas = Convert.ToInt32(reader["Paginas"]);
            double costo = Convert.ToDouble(reader["Costo"]);
            string tipoo = reader["Tipo"].ToString();
            string titulo = reader["Titulo"].ToString();
            int anio = Convert.ToInt32(reader["Anio"]);
            string isbn = reader["ISBN"].ToString();

            //Se crea el objeto
            Revista revista = new Revista(paginas, costo, tipoo, titulo, anio, isbn);

            //Se agrea el objeto en la lista que ya no esta vacia
            lstpublicaciones.Add(revista);
          }
        }
      }
      //Se retorna la lista que contiene el objeto correcto con los datos que llegaron de la BD
      return lstpublicaciones;
    }
  }
}