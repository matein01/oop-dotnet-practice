using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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

    public Publicacion Guardar(Publicacion p)
    {
      int id = 0;
      using (SqlConnection con = _conexion.ObtenerConexion())
      {
        con.Open();

        SqlCommand cmd = new SqlCommand("INSERT INTO Publicaciones (Titulo, Anio, ISBN, Costo, Tipo) VALUES (@titulo, @anio, @isbn, @costo, @tipo); SELECT SCOPE_IDENTITY();", con);

        cmd.Parameters.AddWithValue("@titulo", p.Titulo);
        cmd.Parameters.AddWithValue("@anio", p.Anio);
        cmd.Parameters.AddWithValue("@isbn", p.ISBN);
        cmd.Parameters.AddWithValue("@costo", p.Costo);
        cmd.Parameters.AddWithValue("@tipo", p.Tipo);

        id = Convert.ToInt32(cmd.ExecuteScalar());

        if (p is Libro libro)
        {
          SqlCommand cmdl = new SqlCommand("INSERT INTO Libros (Id, Autor) VALUES (@id, @autor);", con);

          cmdl.Parameters.AddWithValue("@id", id);
          cmdl.Parameters.AddWithValue("@autor", libro.Autor);

          cmdl.ExecuteNonQuery();
        }
        else if (p is Revista revista)
        {
          //Query para insertar en la tabla Revistas
          SqlCommand cmdr = new SqlCommand("INSERT INTO Revistas (Id, Paginas) VALUES (@id, @paginas)", con);

          //Los AddWithValue de Revistas
          cmdr.Parameters.AddWithValue("@id", id);
          cmdr.Parameters.AddWithValue("@paginas", revista.Paginas);

          //Se ejecuta el query y no se espera ninguna respuesta
          cmdr.ExecuteNonQuery();
        }
        //Se verifica si la publicación es un cómic
        else if (p is Comic comic)
        {
          //Query para insertar en la tabla Comics
          SqlCommand cmdc = new SqlCommand("INSERT INTO Comics (Id, Heroe) VALUES (@id, @heroe)", con);

          //Los AddWithValue de Comics
          cmdc.Parameters.AddWithValue("@id", id);
          cmdc.Parameters.AddWithValue("@heroe", comic.Heroe);

          //Se ejecuta el query y no se espera ninguna respuesta
          cmdc.ExecuteNonQuery();
        }
        //Se verifica si la publicación es un periódico
        else if (p is Periodico periodico)
        {
          //Query para insertar en la tabla Periodicos
          SqlCommand cmdp = new SqlCommand("INSERT INTO Periodicos (Id, Noticia) VALUES (@id, @noticia)", con);

          //Los AddWithValue de Periodicos
          cmdp.Parameters.AddWithValue("@id", id);
          cmdp.Parameters.AddWithValue("@noticia", periodico.Noticia);

          //Se ejecuta el query y no se espera ninguna respuesta
          cmdp.ExecuteNonQuery();
        }
      }

      p.Id = id;
      return p;
    }
  }
}