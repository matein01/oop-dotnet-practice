using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BibliotecaApp
{
  public class ConexionDB
  {
    const string connection = @"Server=localhost\SQLEXPRESS;Database=BibliotecaDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public static SqlConnection ObtenerConexion()
    {
      return new SqlConnection(connection);
    }
  }
}