using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaWebApp.Models;
using Microsoft.Data.SqlClient;

namespace BibliotecaWebApp.Repositories
{
    public class PublicacionRepositorio
  {
    private readonly ConexionDB _conexion;

    public PublicacionRepositorio(ConexionDB conexion)
    {
      _conexion = conexion;
    }
    public List<Publicacion> ObtenerTodas()
    {
      List<Publicacion> lstPublicaciones = new List<Publicacion>();

      using (SqlConnection con = _conexion.ObtenerConexion())
      {
        con.Open();

        //Query para traer todas las publicaciones con sus datos específicos usando LEFT JOIN
        SqlCommand cmd = new SqlCommand("SELECT p.Id, p.Titulo, p.Anio, p.ISBN, p.Costo, p.Tipo, l.Autor, r.Paginas, c.Heroe, e.Noticia FROM Publicaciones p LEFT JOIN Libros l ON p.Id = l.Id LEFT JOIN Revistas r ON p.Id = r.ID LEFT JOIN Comics c ON p.Id = c.Id LEFT JOIN Periodicos e ON p.Id = e.Id", con);

        //Se crea un objeto del tipo SqlDataReader para poder leer las columnas que se obtengan de la BD
        SqlDataReader reader = cmd.ExecuteReader();

        //Se itera sobre cada fila que devuelve la base de datos
        while (reader.Read())
        {
          //Se obtiene el tipo de publicación para saber qué objeto crear
          string tipo = reader["Tipo"].ToString();

          //Se verifica si es de tipo libro
          if (tipo == "libro")
          {
            //Se guarda el valor de las columnas de la BD en variables para crear el objeto
            string autor = reader["Autor"].ToString();
            double costo = Convert.ToDouble(reader["Costo"]);
            string tipoo = reader["Tipo"].ToString();
            string titulo = reader["Titulo"].ToString();
            int anio = Convert.ToInt32(reader["Anio"]);
            string isbn = reader["ISBN"].ToString();
            int id = Convert.ToInt32(reader["Id"]);

            //Se crea el objeto y se agrega a la lista
            lstPublicaciones.Add(new Libro
            {
              Id = id,
              Titulo = titulo,
              Anio = anio,
              ISBN = isbn,
              Costo = costo,
              Tipo = tipoo,
              Autor = autor
            });
          }
          //Se verifica si es de tipo revista
          else if (tipo == "revista")
          {
            //Se guarda el valor de las columnas de la BD en variables para crear el objeto
            int paginas = Convert.ToInt32(reader["Paginas"]);
            double costo = Convert.ToDouble(reader["Costo"]);
            string tipoo = reader["Tipo"].ToString();
            string titulo = reader["Titulo"].ToString();
            int anio = Convert.ToInt32(reader["Anio"]);
            string isbn = reader["ISBN"].ToString();
            int id = Convert.ToInt32(reader["Id"]);

            //Se crea el objeto y se agrega a la lista
            lstPublicaciones.Add(new Revista
            {
              Id = id,
              Titulo = titulo,
              Anio = anio,
              ISBN = isbn,
              Costo = costo,
              Tipo = tipoo,
              Paginas = paginas
            });
          }
          //Se verifica si es de tipo cómic
          else if (tipo == "comic")
          {
            //Se guarda el valor de las columnas de la BD en variables para crear el objeto
            string heroe = reader["Heroe"].ToString();
            double costo = Convert.ToDouble(reader["Costo"]);
            string tipoo = reader["Tipo"].ToString();
            string titulo = reader["Titulo"].ToString();
            int anio = Convert.ToInt32(reader["Anio"]);
            string isbn = reader["ISBN"].ToString();
            int id = Convert.ToInt32(reader["Id"]);

            //Se crea el objeto y se agrega a la lista
            lstPublicaciones.Add(new Comic
            {
              Id = id,
              Titulo = titulo,
              Anio = anio,
              ISBN = isbn,
              Costo = costo,
              Tipo = tipoo,
              Heroe = heroe
            });
          }
          //Se verifica si es de tipo periódico
          else if (tipo == "periodico")
          {
            //Se guarda el valor de las columnas de la BD en variables para crear el objeto
            string noticia = reader["Noticia"].ToString();
            double costo = Convert.ToDouble(reader["Costo"]);
            string tipoo = reader["Tipo"].ToString();
            string titulo = reader["Titulo"].ToString();
            int anio = Convert.ToInt32(reader["Anio"]);
            string isbn = reader["ISBN"].ToString();
            int id = Convert.ToInt32(reader["Id"]);

            //Se crea el objeto y se agrega a la lista
            lstPublicaciones.Add(new Periodico
            {
              Id = id,
              Titulo = titulo,
              Anio = anio,
              ISBN = isbn,
              Costo = costo,
              Tipo = tipoo,
              Noticia = noticia
            });
          }
        }
      }

      return lstPublicaciones;
    }
    
    public Publicacion? BuscarPorId(int idIngresado)
    {
      Publicacion? publicacion = null;
      using (SqlConnection con = _conexion.ObtenerConexion())
      {
        con.Open();

        SqlCommand cmd = new SqlCommand("SELECT p.Id, p.Titulo, p.Anio, p.ISBN, p.Costo, p.Tipo, l.Autor, r.Paginas, c.Heroe, e.Noticia FROM Publicaciones p LEFT JOIN Libros l ON p.Id = l.Id LEFT JOIN Revistas r ON p.Id = r.Id LEFT JOIN Comics c ON p.Id = c.Id LEFT JOIN Periodicos e ON p.Id = e.Id Where p.Id = @id", con);

        cmd.Parameters.AddWithValue("@id", idIngresado);

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
          string tipo = reader["Tipo"].ToString();

          if (tipo == "libro")
          {
            //Se guarda el valor de las columnas de la BD en variables para crear el objeto
            string autor = reader["Autor"].ToString();
            double costo = Convert.ToDouble(reader["Costo"]);
            string tipoo = reader["Tipo"].ToString();
            string titulo = reader["Titulo"].ToString();
            int anio = Convert.ToInt32(reader["Anio"]);
            string isbn = reader["ISBN"].ToString();
            int id = Convert.ToInt32(reader["Id"]);

            //Se crea el objeto y se agrega a la lista
            publicacion = (new Libro
            {
              Id = id,
              Titulo = titulo,
              Anio = anio,
              ISBN = isbn,
              Costo = costo,
              Tipo = tipoo,
              Autor = autor
            });
          }
          //Se verifica si es de tipo revista
          else if (tipo == "revista")
          {
            //Se guarda el valor de las columnas de la BD en variables para crear el objeto
            int paginas = Convert.ToInt32(reader["Paginas"]);
            double costo = Convert.ToDouble(reader["Costo"]);
            string tipoo = reader["Tipo"].ToString();
            string titulo = reader["Titulo"].ToString();
            int anio = Convert.ToInt32(reader["Anio"]);
            string isbn = reader["ISBN"].ToString();
            int id = Convert.ToInt32(reader["Id"]);

            //Se crea el objeto y se agrega a la lista
            publicacion = (new Revista
            {
              Id = id,
              Titulo = titulo,
              Anio = anio,
              ISBN = isbn,
              Costo = costo,
              Tipo = tipoo,
              Paginas = paginas
            });
          }
          //Se verifica si es de tipo cómic
          else if (tipo == "comic")
          {
            //Se guarda el valor de las columnas de la BD en variables para crear el objeto
            string heroe = reader["Heroe"].ToString();
            double costo = Convert.ToDouble(reader["Costo"]);
            string tipoo = reader["Tipo"].ToString();
            string titulo = reader["Titulo"].ToString();
            int anio = Convert.ToInt32(reader["Anio"]);
            string isbn = reader["ISBN"].ToString();
            int id = Convert.ToInt32(reader["Id"]);

            //Se crea el objeto y se agrega a la lista
            publicacion = (new Comic
            {
              Id = id,
              Titulo = titulo,
              Anio = anio,
              ISBN = isbn,
              Costo = costo,
              Tipo = tipoo,
              Heroe = heroe
            });
          }
          //Se verifica si es de tipo periódico
          else if (tipo == "periodico")
          {
            //Se guarda el valor de las columnas de la BD en variables para crear el objeto
            string noticia = reader["Noticia"].ToString();
            double costo = Convert.ToDouble(reader["Costo"]);
            string tipoo = reader["Tipo"].ToString();
            string titulo = reader["Titulo"].ToString();
            int anio = Convert.ToInt32(reader["Anio"]);
            string isbn = reader["ISBN"].ToString();
            int id = Convert.ToInt32(reader["Id"]);

            //Se crea el objeto y se agrega a la lista
            publicacion = (new Periodico
            {
              Id = id,
              Titulo = titulo,
              Anio = anio,
              ISBN = isbn,
              Costo = costo,
              Tipo = tipoo,
              Noticia = noticia
            });
          }
        }
      }
      return publicacion;
    }
  }
}