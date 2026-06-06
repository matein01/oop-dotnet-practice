using Microsoft.Data.SqlClient;

namespace BibliotecaApp.Models
{
  public class PublicacionRepositorio
  {
    //Método para insertar información en la base de datos
    public void Guardar(Publicacion publicacion)
    {
      using (SqlConnection con = ConexionDB.ObtenerConexion())
      {
        //Se abre la conexión
        con.Open();

        //Se crea el query que inserta en la tabla Publicaciones y retorna el Id generado
        SqlCommand cmd = new SqlCommand("INSERT INTO Publicaciones (Titulo, Anio, ISBN, Costo, Tipo) VALUES (@titulo, @anio, @isbn, @costo, @tipo); SELECT SCOPE_IDENTITY();", con);

        //Se escriben los AddWithValue para poder pasar parámetros y no strings
        cmd.Parameters.AddWithValue("@titulo", publicacion.Titulo);
        cmd.Parameters.AddWithValue("@anio", publicacion.Anio);
        cmd.Parameters.AddWithValue("@isbn", publicacion.ISBN);
        cmd.Parameters.AddWithValue("@costo", publicacion.Costo);
        cmd.Parameters.AddWithValue("@tipo", publicacion.Tipo);

        //Se ejecuta el query y se obtiene el Id generado por la base de datos
        int id = Convert.ToInt32(cmd.ExecuteScalar());

        //Se verifica si la publicación es un libro
        if (publicacion is Libro libro)
        {
          //Query para insertar en la tabla Libros
          SqlCommand cmdl = new SqlCommand("INSERT INTO Libros (Id, Autor) VALUES (@id, @autor)", con);

          //Los AddWithValue de Libros
          cmdl.Parameters.AddWithValue("@id", id);
          cmdl.Parameters.AddWithValue("@autor", libro.Autor);

          //Se ejecuta el query y no se espera ninguna respuesta
          cmdl.ExecuteNonQuery();
        }
        //Se verifica si la publicación es una revista
        else if (publicacion is Revista revista)
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
        else if (publicacion is Comic comic)
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
        else if (publicacion is Periodico periodico)
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
    }

    //Método para traer todas las publicaciones de la base de datos
    public List<Publicacion> ObtenerTodas()
    {
      //Se crea una lista vacía
      List<Publicacion> lstpublicaciones = new List<Publicacion>();

      using (SqlConnection con = ConexionDB.ObtenerConexion())
      {
        //Se abre la conexión
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
            lstpublicaciones.Add(new Libro(autor, costo, tipoo, titulo, anio, isbn, id));
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
            lstpublicaciones.Add(new Revista(paginas, costo, tipoo, titulo, anio, isbn, id));
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
            lstpublicaciones.Add(new Comic(heroe, costo, tipoo, titulo, anio, isbn, id));
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
            lstpublicaciones.Add(new Periodico(noticia, costo, tipoo, titulo, anio, isbn, id));
          }
        }
      }
      //Se retorna la lista con todas las publicaciones
      return lstpublicaciones;
    }

    //Método para modificar una publicación existente en la base de datos
    public void Actualizar(Publicacion publicacion)
    {
      using (SqlConnection con = ConexionDB.ObtenerConexion())
      {
        //Se abre la conexión
        con.Open();

        //Query para modificar los datos generales en la tabla Publicaciones
        SqlCommand cmd = new SqlCommand("UPDATE Publicaciones SET Tipo = @tipo, Titulo = @titulo, Anio = @anio, ISBN = @isbn, Costo = @costo WHERE Id = @id", con);

        //Se escriben los AddWithValue para poder pasar parámetros y no strings
        cmd.Parameters.AddWithValue("@titulo", publicacion.Titulo);
        cmd.Parameters.AddWithValue("@anio", publicacion.Anio);
        cmd.Parameters.AddWithValue("@isbn", publicacion.ISBN);
        cmd.Parameters.AddWithValue("@costo", publicacion.Costo);
        cmd.Parameters.AddWithValue("@id", publicacion.Id);
        cmd.Parameters.AddWithValue("@tipo", publicacion.Tipo);

        //Se ejecuta el query y no se espera ninguna respuesta
        cmd.ExecuteNonQuery();

        //Se verifica si la publicación es un libro
        if (publicacion is Libro libro)
        {
          //Query para modificar los datos específicos en la tabla Libros
          SqlCommand cmdl = new SqlCommand("UPDATE Libros SET Autor = @autor WHERE Id = @id", con);

          //Los AddWithValue de Libros
          cmdl.Parameters.AddWithValue("@id", publicacion.Id);
          cmdl.Parameters.AddWithValue("@autor", libro.Autor);

          //Se ejecuta el query y no se espera ninguna respuesta
          cmdl.ExecuteNonQuery();
        }
        //Se verifica si la publicación es una revista
        else if (publicacion is Revista revista)
        {
          //Query para modificar los datos específicos en la tabla Revistas
          SqlCommand cmdr = new SqlCommand("UPDATE Revistas SET Paginas = @paginas WHERE Id = @id", con);

          //Los AddWithValue de Revistas
          cmdr.Parameters.AddWithValue("@id", publicacion.Id);
          cmdr.Parameters.AddWithValue("@paginas", revista.Paginas);

          //Se ejecuta el query y no se espera ninguna respuesta
          cmdr.ExecuteNonQuery();
        }
        //Se verifica si la publicación es un cómic
        else if (publicacion is Comic comic)
        {
          //Query para modificar los datos específicos en la tabla Comics
          SqlCommand cmdc = new SqlCommand("UPDATE Comics SET Heroe = @heroe WHERE Id = @id", con);

          //Los AddWithValue de Comics
          cmdc.Parameters.AddWithValue("@id", publicacion.Id);
          cmdc.Parameters.AddWithValue("@heroe", comic.Heroe);

          //Se ejecuta el query y no se espera ninguna respuesta
          cmdc.ExecuteNonQuery();
        }
        //Se verifica si la publicación es un periódico
        else if (publicacion is Periodico periodico)
        {
          //Query para modificar los datos específicos en la tabla Periodicos
          SqlCommand cmdp = new SqlCommand("UPDATE Periodicos SET Noticia = @noticia WHERE Id = @id", con);

          //Los AddWithValue de Periodicos
          cmdp.Parameters.AddWithValue("@id", publicacion.Id);
          cmdp.Parameters.AddWithValue("@noticia", periodico.Noticia);

          //Se ejecuta el query y no se espera ninguna respuesta
          cmdp.ExecuteNonQuery();
        }
      }
    }

    //Método para buscar una publicación por su Id
    public Publicacion? BuscarPorId(int idIngresado)
    {
      //Se crea un objeto vacío que se llenará si se encuentra la publicación
      Publicacion? p = null;

      using (SqlConnection con = ConexionDB.ObtenerConexion())
      {
        //Se abre la conexión
        con.Open();

        //Query para traer una publicación específica usando su Id
        SqlCommand cmd = new SqlCommand("SELECT p.Id, p.Titulo, p.Anio, p.ISBN, p.Costo, p.Tipo, l.Autor, r.Paginas, c.Heroe, e.Noticia FROM Publicaciones p LEFT JOIN Libros l ON p.Id = l.Id LEFT JOIN Revistas r ON p.Id = r.ID LEFT JOIN Comics c ON p.Id = c.Id LEFT JOIN Periodicos e ON p.Id = e.ID WHERE p.Id = @id", con);

        //Se usa el AddWithValue para pasarle el id ingresado al query
        cmd.Parameters.AddWithValue("@id", idIngresado);

        //Se crea un objeto del tipo SqlDataReader para poder leer las columnas que se obtengan de la BD
        SqlDataReader reader = cmd.ExecuteReader();

        //Se lee solo si la BD devolvió información
        if (reader.Read())
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

            //Se crea el objeto
            p = new Libro(autor, costo, tipoo, titulo, anio, isbn, id);
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

            //Se crea el objeto
            p = new Revista(paginas, costo, tipoo, titulo, anio, isbn, id);
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

            //Se crea el objeto
            p = new Comic(heroe, costo, tipoo, titulo, anio, isbn, id);
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

            //Se crea el objeto
            p = new Periodico(noticia, costo, tipoo, titulo, anio, isbn, id);
          }
        }
      }
      //Se retorna la publicación encontrada o null si no existe
      return p;
    }

    //Método para eliminar una publicación y sus datos específicos de la base de datos
    public void Eliminar(int id)
    {
      using (SqlConnection con = ConexionDB.ObtenerConexion())
      {
        //Se abre la conexión
        con.Open();

        //Se crean los queries para eliminar en cada tabla hija primero y Publicaciones al final
        SqlCommand cmdl = new SqlCommand("DELETE FROM Libros WHERE Id = @id", con);
        SqlCommand cmdr = new SqlCommand("DELETE FROM Revistas WHERE Id = @id", con);
        SqlCommand cmdc = new SqlCommand("DELETE FROM Comics WHERE Id = @id", con);
        SqlCommand cmdp = new SqlCommand("DELETE FROM Periodicos WHERE Id = @id", con);
        SqlCommand cmd = new SqlCommand("DELETE FROM Publicaciones WHERE Id = @id", con);

        //Se asigna el id a cada comando
        cmdl.Parameters.AddWithValue("@id", id);
        cmdr.Parameters.AddWithValue("@id", id);
        cmdc.Parameters.AddWithValue("@id", id);
        cmdp.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@id", id);

        //Se eliminan primero las tablas hijas y al final Publicaciones para respetar las llaves foráneas
        cmdl.ExecuteNonQuery(); // Libros
        cmdr.ExecuteNonQuery(); // Revistas
        cmdc.ExecuteNonQuery(); // Comics
        cmdp.ExecuteNonQuery(); // Periódicos
        cmd.ExecuteNonQuery();  // Publicaciones
      }
    }
  }
}