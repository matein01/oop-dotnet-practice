using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BibliotecaApp.Models
{
  public class PublicacionRepositorio
  {
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
  }
}