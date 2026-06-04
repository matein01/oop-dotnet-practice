using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BibliotecaApp
{
  public class ConexionDB
  {
    //Variable con la ruta y los datos necesario para conectarse a la BD
    const string connection = @"Server=localhost\SQLEXPRESS;Database=BibliotecaDB;Trusted_Connection=True;TrustServerCertificate=True;";

    //Metodo para conectarse a la BD
    public static SqlConnection ObtenerConexion()
    {
      return new SqlConnection(connection);
    }
  }
}